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
    public class UI_HomeData : UIPanelData
    {
        // TODO: Query Mgr's Data
    }

    public partial class UI_Home : UIPanel
    {
        protected override void InitUI(IUIData uiData = null)
        {
            mData = uiData as UI_HomeData ?? new UI_HomeData();
            //please add init code here
        }

        protected override void ProcessMsg(int eventId, QMsg msg)
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterUIEvent()
        {

        }

        protected override void OnShow()
        {
            base.OnShow();
        }

        protected override void OnHide()
        {
            Debug.Log("显示");
            base.OnHide();
        }

        protected override void OnClose()
        {
            base.OnClose();
        }

        void ShowLog(string content)
        {
            Debug.Log("[ UI_Home:]" + content);
        }
        private void Start()
        {
            Invoke("Auto", 2F);
        }
        void Auto()
        {
            CloseSelf();
            UIMgr.OpenPanel<UI_Top>(prefabName: "Resources/UI_Main");
        }
        UI_HomeData mData = null;
    }
}