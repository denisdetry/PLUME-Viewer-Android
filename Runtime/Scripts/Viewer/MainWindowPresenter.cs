﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace PLUME.Viewer
{
    // TODO: refactor by splitting into multiple classes
    [RequireComponent(typeof(MainWindowUI))]
    public class MainWindowPresenter : MonoBehaviour
    {
        public Player.Player player;

        private MainWindowUI _mainWindowUI;

        private bool _loading = true;

        private void Awake()
        {
            _mainWindowUI = GetComponent<MainWindowUI>();
        }

        private void Start()
        {
            _mainWindowUI.PreviewRenderAspectRatio.RegisterCallback<FocusInEvent>(OnPreviewRenderFocused);
            _mainWindowUI.PreviewRenderAspectRatio.RegisterCallback<FocusOutEvent>(OnPreviewRenderUnfocused);

            _mainWindowUI.PreviewRender.RegisterCallback<MouseEnterEvent>(OnPreviewRenderMouseEnter);
            _mainWindowUI.PreviewRender.RegisterCallback<MouseLeaveEvent>(OnPreviewRenderMouseLeave);

            _mainWindowUI.PreviewRenderAspectRatio.RegisterCallback<NavigationMoveEvent>(OnPreviewRenderNavigationMove);
            _mainWindowUI.PreviewRenderAspectRatio.RegisterCallback<KeyDownEvent>(OnPreviewRenderKeyDown);
            _mainWindowUI.PreviewRender.style.backgroundImage =
                Background.FromRenderTexture(player.PreviewRenderTexture);

            _mainWindowUI.Timeline.RegisterCallback<KeyDownEvent>(OnPlayPauseKeyDown);
            _mainWindowUI.PlayPauseButton.RegisterCallback<KeyDownEvent>(OnPlayPauseKeyDown);

            _mainWindowUI.PlayPauseButton.toggled += OnTogglePlayPause;
            _mainWindowUI.TimeIndicator.timeChanged += OnTimeIndicatorChanged;
            _mainWindowUI.TimeScale.dragged += OnTimeScaleDragged;
            _mainWindowUI.TimeScale.clicked += OnTimeScaleClicked;
            _mainWindowUI.StopButton.clicked += OnClickStop;
            _mainWindowUI.DecreaseSpeedButton.clicked += OnClickDecreaseSpeed;
            _mainWindowUI.IncreaseSpeedButton.clicked += OnClickIncreaseSpeed;
            _mainWindowUI.ToggleMaximizePreviewButton.toggled += OnClickToggleMaximizePreview;

            _mainWindowUI.CameraEnumField.SetValueWithoutNotify(player.GetCurrentPreviewCamera().GetCameraType());
            _mainWindowUI.CameraEnumField.RegisterValueChangedCallback(OnCameraSelectionChanged);

            RefreshResetViewButton();
            _mainWindowUI.ResetViewButton.clicked += OnClickResetView;

            player.GetPlayerContext().updatedHierarchy += OnHierarchyUpdateEvent;
        }

        private void OnClickResetView()
        {
            var cam = player.GetCurrentPreviewCamera();

            if (cam != null)
            {
                cam.ResetView();
            }
        }

        private void RefreshResetViewButton()
        {
            _mainWindowUI.ResetViewButton.SetEnabled(player.GetCurrentPreviewCamera().GetCameraType() !=
                                                     PreviewCameraType.Main);
        }

        private void OnCameraSelectionChanged(ChangeEvent<Enum> evt)
        {
            var cameraType = (PreviewCameraType)evt.newValue;

            switch (cameraType)
            {
                case PreviewCameraType.Free:
                    player.SetCurrentPreviewCamera(player.GetFreeCamera());
                    break;
                case PreviewCameraType.TopView:
                    player.SetCurrentPreviewCamera(player.GetTopViewCamera());
                    break;
                case PreviewCameraType.Main:
                    player.SetCurrentPreviewCamera(player.GetMainCamera());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            RefreshResetViewButton();
        }

        public void OnHierarchyUpdateEvent(IHierarchyUpdateEvent evt)
        {
            var controller = _mainWindowUI.HierarchyTree.viewController;
            var ctx = player.GetPlayerContext();
            
            // switch (evt)
            // {
            //     case HierarchyUpdateCreateTransformEvent createEvt:
            //     {
            //         var instanceId = player.GetPlayerContext()
            //             .GetReplayInstanceId(createEvt.gameObjectIdentifier.GameObjectId);
            //
            //         if (!instanceId.HasValue)
            //             return;
            //
            //         var go = ObjectExtensions.FindObjectFromInstanceID(instanceId.Value) as GameObject;
            //
            //         if (go == null)
            //             return;
            //
            //         var itemData = new TreeViewItemData<GameObject>(instanceId.Value, go);
            //         _mainWindowUI.HierarchyTree.AddItem(itemData);
            //
            //         break;
            //     }
            //     case HierarchyUpdateDestroyTransformEvent destroyEvt:
            //     {
            //         var instanceId = player.GetPlayerContext()
            //             .GetReplayInstanceId(destroyEvt.gameObjectIdentifier.GameObjectId);
            //
            //         if (!instanceId.HasValue)
            //             return;
            //
            //         _mainWindowUI.HierarchyTree.TryRemoveItem(instanceId.Value);
            //         break;
            //     }
            //     case HierarchyUpdateSiblingIndexEvent siblingUpdateEvt:
            //     {
            //         var instanceId = player.GetPlayerContext()
            //             .GetReplayInstanceId(siblingUpdateEvt.gameObjectIdentifier.GameObjectId);
            //         
            //         if (!instanceId.HasValue)
            //             return;
            //
            //         var go = _mainWindowUI.HierarchyTree.GetItemDataForId<GameObject>(instanceId.Value);
            //
            //         if (go != null)
            //         {
            //             if (go.transform.parent == null)
            //             {
            //                 controller.Move(instanceId.Value, -1, siblingUpdateEvt.siblingIndex);
            //             }
            //             else
            //             {
            //                 var parentId = go.transform.parent.gameObject.GetInstanceID();
            //                 controller.Move(instanceId.Value, parentId, siblingUpdateEvt.siblingIndex);
            //             }
            //         }
            //
            //         break;
            //     }
            //     case HierarchyUpdateEnabledEvent enabledUpdateEvt:
            //     {
            //         var instanceId = player.GetPlayerContext()
            //             .GetReplayInstanceId(enabledUpdateEvt.gameObjectIdentifier.GameObjectId);
            //         
            //         if (!instanceId.HasValue)
            //             return;
            //         
            //         var index = controller.GetIndexForId(instanceId.Value);
            //         if (index != -1)
            //         {
            //             _mainWindowUI.HierarchyTree.RefreshItem(index);
            //         }
            //
            //         break;
            //     }
            //     case HierarchyUpdateParentEvent updateParentEvt:
            //     {
            //         var instanceId = player.GetPlayerContext()
            //             .GetReplayInstanceId(updateParentEvt.gameObjectIdentifier.GameObjectId);
            //
            //         if (!instanceId.HasValue)
            //             return;
            //
            //         // Null Guid
            //         if (updateParentEvt.parentIdentifier.GameObjectId == "00000000000000000000000000000000")
            //         {
            //             controller.Move(instanceId.Value, -1, updateParentEvt.siblingIdx);
            //         }
            //         else
            //         {
            //             var parentId = player.GetPlayerContext()
            //                 .GetReplayInstanceId(updateParentEvt.parentIdentifier.GameObjectId);
            //             
            //             if(!parentId.HasValue)
            //                 return;
            //             
            //             controller.Move(instanceId.Value, parentId.Value, updateParentEvt.siblingIdx);
            //         }
            //
            //         break;
            //     }
            //     case HierarchyUpdateResetEvent:
            //     {
            //         _mainWindowUI.HierarchyTree.ClearSelection();
            //         _mainWindowUI.HierarchyTree.SetRootItems(new List<TreeViewItemData<GameObject>>());
            //         _mainWindowUI.HierarchyTree.Rebuild();
            //         break;
            //     }
            // }
        }

        private void OnTimeIndicatorChanged(ChangeEvent<ulong> evt)
        {
            player.JumpToTime(Math.Clamp(evt.newValue, 0, player.Record.Duration));
        }

        private void OnTimeScaleDragged(ulong time)
        {
            player.JumpToTime(Math.Clamp(time, 0, player.Record.Duration));
        }

        private void OnTimeScaleClicked(ulong time)
        {
            player.JumpToTime(Math.Clamp(time, 0, player.Record.Duration));
        }

        private void OnPlayPauseKeyDown(KeyDownEvent evt)
        {
            if (evt.keyCode == KeyCode.Space)
            {
                player.TogglePlaying();
                _mainWindowUI.RefreshPlayPauseButton();
            }
        }

        private void OnPreviewRenderKeyDown(KeyDownEvent evt)
        {
            if (evt.keyCode == KeyCode.Escape)
            {
                _mainWindowUI.PreviewRenderAspectRatio.Blur();
                _mainWindowUI.Timeline.Focus();
            }
        }

        private void OnPreviewRenderNavigationMove(NavigationMoveEvent evt)
        {
            // Prevent navigation keys to change focus to another pane (WASD, arrows, joystick, ...)
            evt.PreventDefault();
        }

        private void OnPreviewRenderMouseEnter(MouseEnterEvent evt)
        {
            if (player.GetTopViewCamera() != null)
            {
                player.GetTopViewCamera().ZoomDisabled = false;
            }
        }

        private void OnPreviewRenderMouseLeave(MouseLeaveEvent evt)
        {
            if (player.GetTopViewCamera() != null)
            {
                player.GetTopViewCamera().ZoomDisabled = true;
            }
        }

        private void OnPreviewRenderFocused(FocusInEvent evt)
        {
            if (player.GetFreeCamera() != null)
            {
                player.GetFreeCamera().InputDisabled = false;
            }

            if (player.GetTopViewCamera() != null)
            {
                player.GetTopViewCamera().InputDisabled = false;
            }
        }

        private void OnPreviewRenderUnfocused(FocusOutEvent evt)
        {
            if (player.GetFreeCamera() != null)
            {
                player.GetFreeCamera().InputDisabled = true;
            }

            if (player.GetTopViewCamera() != null)
            {
                player.GetTopViewCamera().InputDisabled = true;
                player.GetTopViewCamera().ZoomDisabled = true;
            }
        }

        private void OnClickToggleMaximizePreview(bool state)
        {
            if (state)
                _mainWindowUI.CollapseSidePanels();
            else
                _mainWindowUI.InflateSidePanels();
        }

        private void OnClickDecreaseSpeed()
        {
            player.SetPlaySpeed(Mathf.Max(0.25f, player.GetPlaySpeed() - 0.25f));
            _mainWindowUI.RefreshSpeed();
        }

        private void OnClickIncreaseSpeed()
        {
            player.SetPlaySpeed(Mathf.Min(5, player.GetPlaySpeed() + 0.25f));
            _mainWindowUI.RefreshSpeed();
        }

        private void OnTogglePlayPause(bool state)
        {
            if (state && !player.IsPlaying())
                player.StartPlaying();
            else if (!state && player.IsPlaying())
                player.PausePlaying();
        }

        private void OnClickStop()
        {
            player.StopPlaying();
            _mainWindowUI.RefreshPlayPauseButton();
        }

        private void ShowViewerPanel()
        {
            _mainWindowUI.ViewerPanel.style.display = DisplayStyle.Flex;
            _mainWindowUI.LoadingPanel.style.display = DisplayStyle.None;

            _mainWindowUI.RefreshTimelineScale();
            _mainWindowUI.RefreshTimelineTimeIndicator();
            _mainWindowUI.RefreshTimelineCursor();
            _mainWindowUI.RefreshPlayPauseButton();
            _mainWindowUI.RefreshSpeed();

            _mainWindowUI.RefreshMarkers();
            _mainWindowUI.RefreshPhysiologicalTracks();

            // By default, show 30s of the record in the timeline
            _mainWindowUI.Timeline.ShowTimePeriod(0, 60_000_000_000);
            _mainWindowUI.Timeline.Focus();

            _mainWindowUI.HierarchyTree.ClearSelection();
        }

        public void FixedUpdate()
        {
            if (_loading)
            {
                var isLoading = !player.IsRecordAssetBundleLoaded || !player.IsRecordLoaded;

                if (isLoading)
                {
                    _mainWindowUI.ViewerPanel.style.display = DisplayStyle.None;
                    _mainWindowUI.LoadingPanel.style.display = DisplayStyle.Flex;

                    if (!player.IsRecordAssetBundleLoaded)
                    {
                        _mainWindowUI.LoadingPanel.Q<ProgressBar>("progress-bar").value =
                            player.GetRecordAssetBundleLoadingProgress();
                        _mainWindowUI.LoadingPanel.Q<ProgressBar>("progress-bar").title = "Loading asset bundle...";
                    }
                    else if (!player.IsRecordLoaded)
                    {
                        _mainWindowUI.LoadingPanel.Q<ProgressBar>("progress-bar").value = player.GetRecordLoadingProgress();
                        _mainWindowUI.LoadingPanel.Q<ProgressBar>("progress-bar").title = $"Loading record... {player.GetRecordLoadingProgress():P}%";
                    }
                }
                else
                {
                    ShowViewerPanel();
                    _loading = false;
                }
            }

            var isGenerating = player.GetModuleGenerating() != null;
            _mainWindowUI.PlayPauseButton.SetEnabled(!isGenerating);
            _mainWindowUI.StopButton.SetEnabled(!isGenerating);
            _mainWindowUI.DecreaseSpeedButton.SetEnabled(!isGenerating);
            _mainWindowUI.IncreaseSpeedButton.SetEnabled(!isGenerating);

            _mainWindowUI.PreviewRender.Q<Label>("generating-label").style.display =
                isGenerating ? DisplayStyle.Flex : DisplayStyle.None;

            _mainWindowUI.PreviewRender.Q<Label>("free-camera-instructions").style.display =
                player.GetCurrentPreviewCamera() is FreeCamera ? DisplayStyle.Flex : DisplayStyle.None;
            _mainWindowUI.PreviewRender.Q<Label>("top-view-camera-instructions").style.display =
                player.GetCurrentPreviewCamera() is TopViewCamera ? DisplayStyle.Flex : DisplayStyle.None;

            if (!_mainWindowUI.IsTimeIndicatorFocused())
            {
                _mainWindowUI.RefreshTimelineTimeIndicator();
            }

            if (player.IsPlaying() != _mainWindowUI.PlayPauseButton.GetState())
            {
                _mainWindowUI.RefreshPlayPauseButton();
            }

            _mainWindowUI.RefreshTimelineCursor();
        }
    }
}