/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    public class UI_VideoData : UIPanelData
    {
        // TODO: Query Mgr's Data
    }

    public partial class UI_Video : UIPanel
    {
        private void Start()
        {
            NotificationCenter.Instance().subscribePublic(NotificationType.UI_VIDEO_CLOSE, ClosePerson);
        }

        protected override void InitUI(IUIData uiData = null)
        {
            mData = uiData as UI_VideoData ?? new UI_VideoData();
            //please add init code here
        }

        protected override void ProcessMsg(int eventId, QMsg msg)
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterUIEvent()
        {
            myBack.onClick.AddListener(() =>
            {
                NotificationCenter.Instance().sendPublicMessage(new NotificationData() { mType = NotificationType.NT_OPEN_PAUSE });
                UIMgr.OpenPanel<UI_Main>(UILevel.Common, prefabName: "Resources/UI_Main");

            });
        }

        private void ClosePerson(NotificationData data)
        {
            CloseSelf();
        }
        private void HidePerson(NotificationData data)
        {
            OnHide();
        }


        protected override void OnShow()
        {
            base.OnShow();
        }

        protected override void OnHide()
        {
            base.OnHide();
        }

        protected override void OnClose()
        {
            base.OnClose();
        }

        UI_VideoData mData = null;

        protected override void OnBeforeDestroy()
        {
            NotificationCenter.Instance().unSubscribePublic(NotificationType.UI_VIDEO_CLOSE, ClosePerson);
            NotificationCenter.Instance().unSubscribePublic(NotificationType.UI_VIDEO_CLOSE, HidePerson);
            base.OnBeforeDestroy();
        }
    }
}