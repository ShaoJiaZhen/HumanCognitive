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
    public class UI_TopData : UIPanelData
    {
        // TODO: Query Mgr's Data
    }

    public partial class UI_Top : UIPanel
    {
        protected override void InitUI(IUIData uiData = null)
        {
            mData = uiData as UI_TopData ?? new UI_TopData();
            //please add init code here
        }

        protected override void ProcessMsg(int eventId, QMsg msg)
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterUIEvent()
        {
            myBtn.onClick.AddListener(() =>
            {
                GameObject obj = UIMgr.OpenPanel<UI_Main>(prefabName: "Resources/UI_Main").GetComponent<GameObject>();

                CloseSelf();
            });

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

        void ShowLog(string content)
        {
            Debug.Log("[ UI_Top:]" + content);
        }

        UI_TopData mData = null;
    }
}