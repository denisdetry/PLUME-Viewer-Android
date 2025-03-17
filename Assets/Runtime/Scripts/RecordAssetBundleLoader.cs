using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PLUME.Viewer.Player
{
    public class BundleLoader
    {
        private readonly string _bundlePath;
        private AssetBundleCreateRequest _assetBundleCreateRequest;
        private AssetBundleCreateRequest _sceneBundleCreateRequest;

        private LoadingStatus _loadingStatus;

        public BundleLoader(string bundlePath)
        {
            Debug.Log("DenisPlumeLog - Initializing BundleLoader");
            _loadingStatus = LoadingStatus.NotLoading;
            _bundlePath = bundlePath;
            
            if (!bundlePath.EndsWith(".zip"))
                throw new System.Exception("DenisPlumeLog - Bundle path should be a zip file");

            Debug.Log("DenisPlumeLog - BundleLoader Initialized");         
        }

        public async UniTask<RecordAssetBundle> LoadAsync()
        {
            Debug.Log("DenisPlumeLog - Call: AssetBungleLoader.LoadAsync");
            // Unzip the bundlePath zip file in the temporary directory
            var tempDirectory = Path.Combine(Application.persistentDataPath, "tmp");
            tempDirectory = Path.Combine(tempDirectory, "plume_bundle");
            Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: tempDirectory set to " + tempDirectory);
            try {
                if (Directory.Exists(tempDirectory))
                    Directory.Delete(tempDirectory, true);
                Directory.CreateDirectory(tempDirectory);
            } catch (Exception ex) {
                Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: Exception thrown when opening temp directory: " + ex.Message);
            }
            

            Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: Begin unzipping");
            await UniTask.RunOnThreadPool(() => ZipFile.ExtractToDirectory(_bundlePath, tempDirectory));
            Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: Finished unzipping");

            var assetBundlePath = Path.Combine(tempDirectory, "plume_assets");
            var sceneBundlePath = Path.Combine(tempDirectory, "plume_scenes");
            
            Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: Get file names for asset bundle and scene bundle paths");
            var assetBundleName = Path.GetFileName(assetBundlePath);
            var sceneBundleName = Path.GetFileName(sceneBundlePath);
            Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: Get all loaded asset Bundles");
            var assetBundle = AssetBundle.GetAllLoadedAssetBundles()
                .FirstOrDefault(bundle => bundle.name == assetBundleName);
            Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: Get all loaded scene Bundles");
            var sceneBundle = AssetBundle.GetAllLoadedAssetBundles()
                .FirstOrDefault(bundle => bundle.name == sceneBundleName);

            if (assetBundle == null)
            {
                _loadingStatus = LoadingStatus.Loading;
                Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: Bundle create request await");
                _assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(assetBundlePath);
                _sceneBundleCreateRequest = AssetBundle.LoadFromFileAsync(sceneBundlePath);
                await _assetBundleCreateRequest;
                await _sceneBundleCreateRequest;
                Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: Bundle create request finished");
                assetBundle = _assetBundleCreateRequest.assetBundle;
                sceneBundle = _sceneBundleCreateRequest.assetBundle;
                Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: asset bundle load await");
                await _assetBundleCreateRequest.assetBundle.LoadAllAssetsAsync();
                Debug.Log("DenisPlumeLog - AssetBungleLoader.LoadAsync: asset bundle load finished");
                _loadingStatus = LoadingStatus.Done;
            }

            Debug.Log("DenisPlumeLog - Exit: AssetBungleLoader.LoadAsync");
            return new RecordAssetBundle(_assetBundleCreateRequest.assetBundle, _sceneBundleCreateRequest.assetBundle);
        }

        public float GetLoadingProgress()
        {
            return _loadingStatus switch
            {
                LoadingStatus.Done => 1,
                LoadingStatus.NotLoading => 0,
                _ => (_assetBundleCreateRequest.progress + _sceneBundleCreateRequest.progress) / 2
            };
        }

        public bool IsLoaded()
        {
            return _loadingStatus == LoadingStatus.Done;
        }

        public enum LoadingStatus
        {
            NotLoading,
            Loading,
            Done
        }
    }
}