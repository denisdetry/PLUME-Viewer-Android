﻿using PLUME.Sample;
using PLUME.Sample.Unity;
using UnityEngine;
using UnityEngine.Rendering;

namespace PLUME
{
    public class GraphicsSettingsPlayerModule : PlayerModule
    {
        public override void PlaySample(PlayerContext ctx, UnpackedSample sample)
        {
            if (sample.Payload is GraphicsSettingsUpdate graphicsSettingsUpdate)
            {
                GraphicsSettings.defaultRenderPipeline = ctx.GetOrDefaultAssetByIdentifier<RenderPipelineAsset>(graphicsSettingsUpdate.DefaultRenderPipelineAssetId);
            }
        }
    }
}