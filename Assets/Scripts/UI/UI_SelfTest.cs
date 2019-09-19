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
    public class UI_SelfTestData : UIPanelData
    {
        // TODO: Query Mgr's Data
    }

    public partial class UI_SelfTest : UIPanel
    {
        protected override void InitUI(IUIData uiData = null)
        {
            mData = uiData as UI_SelfTestData ?? new UI_SelfTestData();
            //please add init code here
        }

        protected override void ProcessMsg(int eventId, QMsg msg)
        {
            throw new System.NotImplementedException();
        }


        private bool record = true;
        public Image normal;
        public Image Abnormal;
        protected override void RegisterUIEvent()
        {
            myBack.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_PreventiveCare>(UILevel.Common, prefabName: "Resources/UI_Main");
                CloseSelf();
            });
            switchBtn.onClick.AddListener(() =>
            {

                if (record)
                {
                    Abnormal.transform.gameObject.SetActive(true);
                    normal.transform.gameObject.SetActive(false);
                    record = false;
                    return;
                }
                if (record == false)
                {

                    normal.transform.gameObject.SetActive(true);
                    Abnormal.transform.gameObject.SetActive(false);
                    record = true;
                }

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
            Debug.Log("[ UI_SelfTest:]" + content);
        }

        UI_SelfTestData mData = null;
    }
}