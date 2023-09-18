﻿using System;
using System.Collections.Generic;
using Google.Protobuf.Reflection;
using PLUME.Sample;

namespace PLUME
{
    public class FilteredRecordLoader : IDisposable
    {
        private readonly RecordReader _reader;
        private readonly TypeRegistry _typeRegistry;

        private readonly OrderedSamplesList _loadedSamples;
        private readonly Func<PackedSample, bool> _filter;

        private int _sampleCount;
        private bool _loaded;
        private bool _closed;

        public FilteredRecordLoader(RecordReader reader, Func<PackedSample, bool> filter, TypeRegistry typeRegistry)
        {
            _reader = reader;
            _filter = filter;
            _loadedSamples = new OrderedSamplesList();
            _typeRegistry = typeRegistry;
        }

        public void Load()
        {
            if (_loaded)
                return;

            _reader.ReadFileSignature();

            PackedSample sample;

            do
            {
                sample = _reader.ReadNextSample();

                if (sample == null || !_filter.Invoke(sample)) continue;

                // Unpack the sample
                var payload = sample.Payload.Unpack(_typeRegistry);
                var unpackedSample = UnpackedSample.InstantiateUnpackedSample(sample.Header, payload);
                var idx = _loadedSamples.FirstIndexAfterOrAtTime(sample.Header.Time);
                _loadedSamples.Insert(idx, unpackedSample);
                _sampleCount++;
            } while (sample != null);

            _loaded = true;
        }

        public UnpackedSample SampleAtIndex(int index)
        {
            if (!_loaded)
                Load();

            if (index < 0 || index >= _sampleCount)
            {
                return null;
            }

            if (index < _loadedSamples.Count)
            {
                return _loadedSamples[index] as UnpackedSample;
            }

            return null;
        }

        public int FirstSampleIndexAfterOrAtTime(ulong time)
        {
            if (!_loaded)
                Load();

            return _loadedSamples.FirstIndexAfterOrAtTime(time);
        }

        public IEnumerable<UnpackedSample> SamplesInTimeRange(ulong startTime, ulong endTime)
        {
            var startIdx = FirstSampleIndexAfterOrAtTime(startTime);

            if (startIdx < 0)
                yield break;

            var idx = startIdx;

            do
            {
                var sample = SampleAtIndex(idx);

                if (sample == null)
                    yield break;

                if (sample.Header.Time > endTime)
                    yield break;

                yield return sample;
                idx++;
            } while (true);
        }

        public void Close()
        {
            if (_closed)
                return;

            _loadedSamples.Clear();
            _closed = true;
        }

        public void Dispose()
        {
            Close();
        }
    }
}