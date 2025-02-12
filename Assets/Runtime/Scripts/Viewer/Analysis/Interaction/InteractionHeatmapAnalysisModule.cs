using System;
using System.Collections.Generic;
using System.Linq;
using PLUME.Sample.Unity;
using PLUME.Sample.Unity.XRITK;
using PLUME.Viewer.Player;
using UnityEngine;
using UnityEngine.UI;

namespace PLUME.Viewer.Analysis.Interaction
{
    public class InteractionHeatmapAnalysisModule : AnalysisModuleWithResults<InteractionHeatmapAnalysisResult>
    {
        public Player.Player player;

        public Shader interactionHeatmapShader;
        public Shader defaultHeatmapShader;

        public Color startColor = Color.white;
        public Color endColor = Color.red;

        private Material _interactionHeatmapMaterial;
        private Material _defaultHeatmapMaterial;

        private InteractionHeatmapAnalysisResult _visibleResult;

        private static readonly int StartColor = Shader.PropertyToID("_StartColor");
        private static readonly int EndColor = Shader.PropertyToID("_EndColor");
        private static readonly int InteractionCount = Shader.PropertyToID("_InteractionCount");
        private static readonly int MaxInteractionCount = Shader.PropertyToID("_MaxInteractionCount");

        private readonly Dictionary<int, MaterialPropertyBlock> _cachedInteractionsPropertyBlocks = new();

        private void Awake()
        {
            _defaultHeatmapMaterial = new Material(defaultHeatmapShader);
            _interactionHeatmapMaterial = new Material(interactionHeatmapShader);

            _defaultHeatmapMaterial.SetColor(StartColor, startColor);
            _interactionHeatmapMaterial.SetColor(StartColor, startColor);
            _interactionHeatmapMaterial.SetColor(EndColor, endColor);
        }

        public void GenerateHeatmap(Record record,
            InteractionAnalysisModuleParameters parameters,
            Action<InteractionHeatmapAnalysisResult> finishCallback)
        {
            Dictionary<Guid, int> interactions = new();

            var totalInteractionsCount = 0;
            var maxInteractionsCount = 0;

            if (parameters.EndTime < parameters.StartTime)
            {
                throw new Exception(
                    $"{nameof(parameters.EndTime)} should be less or equal {nameof(parameters.StartTime)}.");
            }

            var frameSamples = record.Frames.GetInTimeRange(parameters.StartTime, parameters.EndTime);
            var interactionSamples = frameSamples.SelectMany(frameSample => frameSample.Data)
                .Where(s => s.Payload is XRITKInteraction).Select(s => s.Payload).Cast<XRITKInteraction>();
            
            foreach (var interaction in interactionSamples)
            {
                var interactorGameObjectIdentifier = interaction.Interactor.GameObject;
                var interactableGameObjectIdentifier = interaction.Interactable.GameObject;

                if (parameters.InteractionType == InteractionType.Hover &&
                    interaction.Type != XRITKInteractionType.HoverEnter)
                    continue;
                if (parameters.InteractionType == InteractionType.Select &&
                    interaction.Type != XRITKInteractionType.SelectEnter)
                    continue;
                if (parameters.InteractionType == InteractionType.Activate &&
                    interaction.Type != XRITKInteractionType.ActivateEnter)
                    continue;

                var interactorGameObjectGuid = Guid.Parse(interactorGameObjectIdentifier.Guid);
                var interactableGameObjectGuid = Guid.Parse(interactableGameObjectIdentifier.Guid);

                if (!parameters.InteractorsIds.Contains(interactorGameObjectGuid)) continue;

                if (parameters.InteractablesIds.Length > 0 &&
                    !parameters.InteractablesIds.Contains(interactableGameObjectGuid)) continue;

                var nInteractions = interactions.GetValueOrDefault(interactableGameObjectGuid, 0);
                interactions[interactableGameObjectGuid] = nInteractions + 1;

                maxInteractionsCount = Math.Max(maxInteractionsCount, interactions[interactableGameObjectGuid]);
                totalInteractionsCount++;
            }

            var result = new InteractionHeatmapAnalysisResult(parameters, interactions, totalInteractionsCount,
                maxInteractionsCount);

            finishCallback(result);
        }

        private void LateUpdate()
        {
            var activeContext = PlayerContext.GetActiveContext();

            if (activeContext == null)
                return;

            if (_visibleResult != null)
            {
                ApplyHeatmapMaterials(activeContext);
            }
        }

        private void RestoreRecordMaterials(PlayerContext ctx)
        {
            var gameObjects = ctx.GetAllGameObjects();

            foreach (var go in gameObjects)
            {
                if (go.TryGetComponent<Graphic>(out var graphic))
                {
                    graphic.enabled = true;
                }

                if (!go.TryGetComponent<Renderer>(out var goRenderer))
                    continue;
                goRenderer.SetSharedMaterials(new List<Material>());
            }

            var frames = player.Record.Frames.GetInTimeRange(0, player.GetCurrentPlayTimeInNanoseconds());
            foreach (var frame in frames)
            {
                foreach (var sample in frame.Data)
                {
                    if (sample.Payload is TerrainUpdate)
                    {
                        foreach (var playerModule in player.PlayerModules)
                        {
                            playerModule.PlaySample(ctx, sample);
                        }
                    }

                    if (sample.Payload is RendererUpdate)
                    {
                        foreach (var playerModule in player.PlayerModules)
                        {
                            playerModule.PlaySample(ctx, sample);
                        }
                    }
                }
            }
        }

        private void ApplyHeatmapMaterials(PlayerContext ctx)
        {
            var gameObjects = ctx.GetAllGameObjects();

            // For GameObjects with interactions, apply the custom heatmap material to its render and its children
            foreach (var go in gameObjects)
            {
                if (go.TryGetComponent<Terrain>(out var terrain))
                {
                    // Disable trees and grass
                    terrain.treeDistance = 0;
                    terrain.detailObjectDensity = 0;
                    terrain.materialTemplate = _defaultHeatmapMaterial;
                }

                if (go.TryGetComponent<Graphic>(out var graphic))
                {
                    graphic.enabled = false;
                }

                if (!go.TryGetComponent<Renderer>(out var goRenderer))
                    continue;

                var nSharedMaterials = goRenderer.sharedMaterials.Length;
                goRenderer.sharedMaterials = Enumerable.Repeat(_defaultHeatmapMaterial, nSharedMaterials).ToArray();
                goRenderer.SetPropertyBlock(null);

                var gameObjectGuid = ctx.GetRecordIdentifier(go.GetInstanceID());

                if (gameObjectGuid == Guid.Empty)
                    continue;

                var renderers = new List<Renderer>();
                renderers.Add(goRenderer);
                renderers.AddRange(go.GetComponentsInChildren<Renderer>());

                if (_visibleResult == null ||
                    !_visibleResult.Interactions.TryGetValue(gameObjectGuid, out var interactionsCount) ||
                    interactionsCount == 0)
                    continue;

                foreach (var r in renderers)
                {
                    var propertyBlock = GetOrCreateInteractionsPropertyBlock(r);
                    propertyBlock.SetInt(InteractionCount, interactionsCount);
                    propertyBlock.SetInt(MaxInteractionCount, _visibleResult.MaxInteractionCount);

                    var nRendererSharedMaterials = r.sharedMaterials.Length;
                    r.sharedMaterials = Enumerable.Repeat(_interactionHeatmapMaterial, nRendererSharedMaterials)
                        .ToArray();
                    r.SetPropertyBlock(propertyBlock);
                }
            }
        }

        private MaterialPropertyBlock GetOrCreateInteractionsPropertyBlock(Renderer r)
        {
            if (_cachedInteractionsPropertyBlocks.TryGetValue(r.GetInstanceID(), out var propertyBlock))
            {
                return propertyBlock;
            }

            var newPropertyBlock = new MaterialPropertyBlock();
            _cachedInteractionsPropertyBlocks.Add(r.GetInstanceID(), newPropertyBlock);
            return newPropertyBlock;
        }

        public override void RemoveResult(InteractionHeatmapAnalysisResult result)
        {
            base.RemoveResult(result);

            if (result == _visibleResult)
            {
                _cachedInteractionsPropertyBlocks.Clear();
                SetVisibleResult(null);
            }
        }

        public void SetVisibleResult(InteractionHeatmapAnalysisResult result)
        {
            var prevVisibleResult = _visibleResult;

            _visibleResult = result;

            if (result == null && prevVisibleResult != null)
            {
                RestoreRecordMaterials(player.GetMainPlayerContext());
            }
        }

        public InteractionHeatmapAnalysisResult GetVisibleResult()
        {
            return _visibleResult;
        }
    }
}