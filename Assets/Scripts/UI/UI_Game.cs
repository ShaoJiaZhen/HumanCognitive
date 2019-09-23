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
    public class UI_GameData : UIPanelData
    {
        // TODO: Query Mgr's Data
    }

    public partial class UI_Game : UIPanel
    {
        private GameObject barbagesPoints;

        protected override void InitUI(IUIData uiData = null)
        {
            mData = uiData as UI_GameData ?? new UI_GameData();
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
                GameObject obj = GameObject.Find("GarbagePoints(Clone)");
                obj.SetActive(false);
                if (obj != null)
                {
                    Destroy(obj);
                }
                UIMgr.OpenPanel<UI_PreventiveCare>(UILevel.Common, prefabName: "Resources/UI_Main");
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

        UI_GameData mData = null;
    }
}