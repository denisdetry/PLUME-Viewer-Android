using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using K4os.Compression.LZ4.Streams;
using PLUME.Sample;
using PLUME.Sample.Common;
using PLUME.Sample.LSL;
using PLUME.Sample.Unity;
using PLUME.Sample.Unity.Settings;
using PLUME.Sample.Unity.XRITK;
using UnityEngine;
using UnityEngine.Profiling;

namespace PLUME
{
    public class RecordLoader : IDisposable
    {
        private const uint LZ4MagicNumber = 0x184D2204;

        private Stream _baseStream;
        private Stream _stream;

        public float Progress { get; private set; }

        public LoadingStatus Status { get; private set; }

        private readonly TypeRegistry _sampleTypeRegistry;

        public RecordLoader(string recordPath, TypeRegistry sampleTypeRegistry)
        {
            Status = LoadingStatus.NotLoading;
            Progress = 0;

            _sampleTypeRegistry = sampleTypeRegistry;
            Debug.Log("DenisPlumeLog - RecordLoader: try open recordPath");
            try {
                var pathpath = System.IO.Path.Combine(recordPath, "record_2025-02-25T13-35-01+00.plm");
                _baseStream = File.Open(pathpath, FileMode.Open, FileAccess.Read, FileShare.Read);
            } catch (Exception e) {
                Debug.Log("DenisPlumeLog - RecordLoader: error while loading baseStream: " + e.Message);
                throw e;
            }
            
            Debug.Log("DenisPlumeLog - RecordLoader: recordPath opened");

            if (IsLZ4Compressed(_baseStream))
                _stream = LZ4Stream.Decode(_baseStream);
            else
                _stream = _baseStream;
        }

        public async UniTask<Record> LoadAsync()
        {
            Debug.Log("DenisPlumeLog - LoadAsync: Begin");
            Status = LoadingStatus.Loading;
            Progress = 0;

            Debug.Log("DenisPlumeLog - LoadAsync: Begin Parse Metadata");
            var packedMetadata = PackedSample.Parser.ParseDelimitedFrom(_stream);
            var metadata = packedMetadata.Payload.Unpack<RecordMetadata>();
            Debug.Log("DenisPlumeLog - LoadAsync: Finished Parse Metadata");


            if(metadata == null)
                throw new Exception("DenisPlumeLog - LoadAsync: Failed to load metadata from record file");

            Debug.Log("DenisPlumeLog - LoadAsync: Begin Parse Graphic Settings");
            var packedGraphicsSettings = PackedSample.Parser.ParseDelimitedFrom(_stream);
            var graphicsSettings = packedGraphicsSettings.Payload.Unpack<GraphicsSettings>();
            Debug.Log("DenisPlumeLog - LoadAsync: Finished Parse Graphic Settings");
            
            if(graphicsSettings == null)
                throw new Exception("DenisPlumeLog - LoadAsync: Failed to load graphics settings from record file");
            
            var record = new Record(metadata, graphicsSettings);

            var loadingThread = new Thread(() =>
            {
                Debug.Log("DenisPlumeLog - LoadAsync: Begin loadingThread");
                Profiler.BeginThreadProfiling("PLUME", "RecordLoader.LoadAsync");

                while (_baseStream.Position < _baseStream.Length)
                {
                    try
                    {
                        var packedSample = PackedSample.Parser.ParseDelimitedFrom(_stream);
                        ulong? timestamp = packedSample.HasTimestamp ? packedSample.Timestamp : null;
                        var payload = packedSample.Payload;
                        var unpackedSample = RawSampleUtils.UnpackAsRawSample(timestamp, payload, _sampleTypeRegistry);
                        //Debug.Log("DenisPlumeLog - LoadAsync: Sample unpacked");

                        switch (unpackedSample)
                        {
                            case RawSample<Frame> frame:
                                // Unpack frame
                                var frameSample = UnpackFrame(frame);
                                record.AddFrame(frameSample);
                                break;
                            case RawSample<Marker> marker:

                                record.AddMarkerSample(marker);
                                break;
                            case RawSample<InputAction> inputAction:
                                record.AddInputActionSample(inputAction);
                                break;
                            case RawSample<StreamSample> streamSample:
                                record.AddStreamSample(streamSample);
                                break;
                            case RawSample<StreamOpen> streamOpen:
                                record.AddStreamOpenSample(streamOpen);
                                break;
                            case RawSample<StreamClose> streamClose:
                                record.AddStreamCloseSample(streamClose);
                                break;
                            case null:
                                break;
                            default:
                                record.AddOtherSample(unpackedSample);
                                break;
                        }

                        Progress = _baseStream.Position / (float)_baseStream.Length;
                        //Debug.Log("\r DenisPlumeLog - LoadAsync: Progress = " + Progress.ToString());
                    }
                    catch (InvalidProtocolBufferException ex)
                    {
                        Debug.Log("DenisPlumeLog - LoadAsync: InvalidProtocolBufferException: " + ex.Message);
                        break;
                    }
                   
                }

                Profiler.EndThreadProfiling();
            })
            {
                Name = "RecordLoader.LoadAsync"
            };

            loadingThread.Start();

            // Wait until thread finishes loading the record.
            await UniTask.WaitUntil(() => !loadingThread.IsAlive);
            
            Status = LoadingStatus.Done;
            Progress = 1;

            _stream.Close();
            _stream = null;
             Debug.Log("DenisPlumeLog - Exit LoadAsync");
            return record;
        }

        private FrameSample UnpackFrame(ISample<Frame> frame)
        {
            var unpackedFrameData = frame.Payload.Data.Select(frameData =>
                RawSampleUtils.UnpackAsRawSample(frame.Timestamp, frameData, _sampleTypeRegistry)).ToList();
            return new FrameSample(frame.Timestamp, frame.Payload.FrameNumber, unpackedFrameData);
        }

        private static bool IsLZ4Compressed(Stream fileStream)
        {
            // Read magic number
            var magicNumber = new byte[4];
            _ = fileStream.Read(magicNumber, 0, 4);
            fileStream.Seek(0, SeekOrigin.Begin);
            var compressed = BitConverter.ToUInt32(magicNumber, 0) == LZ4MagicNumber;
            return compressed;
        }

        public void Dispose()
        {
            _stream?.Dispose();
        }

        public enum LoadingStatus
        {
            NotLoading,
            Loading,
            Done
        }
    }
}