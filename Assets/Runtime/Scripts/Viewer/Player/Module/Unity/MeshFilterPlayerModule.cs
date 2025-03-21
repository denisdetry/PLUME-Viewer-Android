﻿using PLUME.Sample;
using PLUME.Sample.Unity;
using UnityEngine;

namespace PLUME.Viewer.Player.Module.Unity
{
    public class MeshFilterPlayerModule : PlayerModule
    {
        public override void PlaySample(PlayerContext ctx, RawSample rawSample)
        {
            switch (rawSample.Payload)
            {
                case MeshFilterCreate meshFilterCreate:
                {
                    ctx.GetOrCreateComponentByIdentifier<MeshFilter>(meshFilterCreate.Component);
                    break;
                }
                case MeshFilterDestroy meshFilterDestroy:
                {
                    ctx.TryDestroyComponentByIdentifier(meshFilterDestroy.Component);
                    break;
                }
                case MeshFilterUpdate meshFilterUpdate:
                {
                    var meshFilter = ctx.GetOrCreateComponentByIdentifier<MeshFilter>(meshFilterUpdate.Component);

                    if (meshFilterUpdate.Mesh != null)
                    {
                        meshFilter.sharedMesh = ctx.GetOrDefaultAssetByIdentifier<Mesh>(meshFilterUpdate.Mesh);
                        ctx.TryAddAssetIdentifierCorrespondence(meshFilterUpdate.Mesh, meshFilter.sharedMesh);
                    }

                    break;
                }
            }
        }
    }
}