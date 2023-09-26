﻿using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PLUME.UI
{
    [RequireComponent(typeof(MainWindowUI))]
    public class MainWindowPresenter : MonoBehaviour
    {
        public Player player;
        public FreeCamera freeCamera;

        private MainWindowUI _mainWindowUI;

        private void Awake()
        {
            _mainWindowUI = GetComponent<MainWindowUI>();
        }

        private void Start()
        {
            _mainWindowUI.PreviewRenderAspectRatio.RegisterCallback<FocusInEvent>(OnPreviewRenderFocused);
            _mainWindowUI.PreviewRenderAspectRatio.RegisterCallback<FocusOutEvent>(OnPreviewRenderUnfocused);
            _mainWindowUI.PreviewRenderAspectRatio.RegisterCallback<NavigationMoveEvent>(OnPreviewRenderNavigationMove);
            _mainWindowUI.PreviewRenderAspectRatio.RegisterCallback<KeyDownEvent>(OnPreviewRenderKeyDown);
            _mainWindowUI.PreviewRender.style.backgroundImage = Background.FromRenderTexture(freeCamera.GetRenderTexture());
            
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

            _mainWindowUI.CreatePhysiologicalTracks();
            
            _mainWindowUI.RefreshTimelineScale();
            _mainWindowUI.RefreshTimelineTimeIndicator();
            _mainWindowUI.RefreshTimelineCursor();
            _mainWindowUI.RefreshPlayPauseButton();
            _mainWindowUI.RefreshSpeed();

            _mainWindowUI.Timeline.focusable = true;
            _mainWindowUI.Timeline.Focus();

            player.GetPlayerContext().updatedHierarchy += OnHierarchyUpdateEvent;
        }

        private void OnHierarchyUpdateEvent(IHierarchyUpdateEvent evt)
        {
            var controller = _mainWindowUI.HierarchyTree.viewController;

            switch (evt)
            {
                case HierarchyUpdateCreateTransformEvent createEvt:
                {
                    var t = ObjectExtensions.FindObjectFromInstanceID(createEvt.transformId) as Transform;
                    var item = new TreeViewItemData<Transform>(createEvt.transformId, t);
                    _mainWindowUI.HierarchyTree.AddItem(item);
                    break;
                }
                case HierarchyUpdateDestroyTransformEvent destroyEvt:
                {
                    _mainWindowUI.HierarchyTree.TryRemoveItem(destroyEvt.transformId);
                    break;
                }
                case HierarchyUpdateSiblingIndexEvent siblingUpdateEvt:
                {
                    var t = _mainWindowUI.HierarchyTree.GetItemDataForId<Transform>(siblingUpdateEvt.transformId);
                    controller.Move(siblingUpdateEvt.transformId, t.parent == null ? -1 : t.parent.GetInstanceID(),
                        siblingUpdateEvt.newSiblingIndex);
                    break;
                }
                case HierarchyUpdateEnabledEvent enabledUpdateEvt:
                {
                    var index = controller.GetIndexForId(enabledUpdateEvt.transformId);
                    _mainWindowUI.HierarchyTree.RefreshItem(index);
                    break;
                }
                case HierarchyUpdateParentEvent updateParentEvt:
                {
                    if (updateParentEvt.newParentTransformId == 0)
                        controller.Move(updateParentEvt.transformId, -1, updateParentEvt.siblingIdx);
                    else
                        controller.Move(updateParentEvt.transformId, updateParentEvt.newParentTransformId,
                            updateParentEvt.siblingIdx);
                    break;
                }
            }
        }

        private void OnTimeIndicatorChanged(ChangeEvent<ulong> evt)
        {
            player.JumpToTime(Math.Clamp(evt.newValue, 0, player.GetRecordDurationInNanoseconds()));
        }

        private void OnTimeScaleDragged(ulong time)
        {
            player.JumpToTime(Math.Clamp(time, 0, player.GetRecordDurationInNanoseconds()));
        }

        private void OnTimeScaleClicked(ulong time)
        {
            player.JumpToTime(Math.Clamp(time, 0, player.GetRecordDurationInNanoseconds()));
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

        private void OnPreviewRenderFocused(FocusInEvent evt)
        {
            if (freeCamera != null)
            {
                freeCamera.Disabled = false;
            }
        }

        private void OnPreviewRenderUnfocused(FocusOutEvent evt)
        {
            if (freeCamera != null)
            {
                freeCamera.Disabled = true;
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

        public void Update()
        {
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