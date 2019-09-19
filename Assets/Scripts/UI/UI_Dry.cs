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
    public class UI_DryData : UIPanelData
    {
        // TODO: Query Mgr's Data
    }

    public partial class UI_Dry : UIPanel
    {
        protected override void InitUI(IUIData uiData = null)
        {
            mData = uiData as UI_DryData ?? new UI_DryData();
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
                CloseSelf();
                GameObject obj = GameObject.Find("UI_Dry_Obj(Clone)");
                obj.SetActive(false);
                if (obj != null)
                {
                    Destroy(obj);
                }
                UIMgr.OpenPanel<UI_Video>(UILevel.Common, prefabName: "Resources/UI_Video");
                UIMgr.OpenPanel<UI_PreventiveCare>(UILevel.Common, prefabName: "Resources/UI_Main");
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
            Debug.Log("[ UI_Dry:]" + content);
        }

        UI_DryData mData = null;
    }
}