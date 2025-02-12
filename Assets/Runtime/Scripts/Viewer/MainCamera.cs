#define USE_INPUT_SYSTEM
using System;
using System.Linq;
using PLUME.Viewer.Player;
using UnityEngine;

namespace PLUME.Viewer
{
    [RequireComponent(typeof(Camera))]
    public class MainCamera : PreviewCamera
    {
        // The camera we will copy the settings to.
        private Camera _camera;

        private Camera _followedMainCamera;

        public void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        public override Camera GetCamera()
        {
            if (_camera == null)
                _camera = GetComponent<Camera>();

            return _camera;
        }

        public void FixedUpdate()
        {
            var mainCamera = Camera.main;

            if (mainCamera != _followedMainCamera)
            {
                if (mainCamera != null)
                {
                    // Main camera changed, copy all of its properties except target texture.
                    var prevTargetTexture = _camera.targetTexture;
                    _camera.CopyFrom(mainCamera);
                    _camera.targetTexture = prevTargetTexture;
                }

                _followedMainCamera = mainCamera;
            }
        }

        public void LateUpdate()
        {
            if (_followedMainCamera != null)
            {
                // Copy world transform.
                _followedMainCamera.transform.GetPositionAndRotation(out var position, out var rotation);
                transform.SetPositionAndRotation(position, rotation);
            }
        }

        public override void SetEnabled(bool enabled)
        {
            GetCamera().targetTexture = enabled ? PreviewRenderTexture : null;
            GetCamera().enabled = enabled;
        }

        public override PreviewCameraType GetCameraType()
        {
            return PreviewCameraType.Main;
        }

        public override void ResetView()
        {
        }
    }
}