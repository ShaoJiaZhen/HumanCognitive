/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
    public class UI_MainData : UIPanelData
    {
        // TODO: Query Mgr's Data
    }

    public partial class UI_Main : UIPanel
    {
        protected override void InitUI(IUIData uiData = null)
        {
            mData = uiData as UI_MainData ?? new UI_MainData();
            //please add init code here
        }

        protected override void ProcessMsg(int eventId, QMsg msg)
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterUIEvent()
        {
            //简述原理
            Icon1.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_Sketch>(UILevel.Common, prefabName: "Resources/UI_Sketch");
                CloseSelf();
            });

            //预防护理
            Icon2.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_PreventiveCare>(UILevel.Common, prefabName: "Resources/UI_PreventiveCare");
                CloseSelf();
            });

            //病理演示
            Icon3.onClick.AddListener(() =>
            {
                CloseSelf();
                UIMgr.OpenPanel<UI_Video>(UILevel.Common, prefabName: "Resources/UI_Video");
                NotificationCenter.Instance().sendPublicMessage(new NotificationData() { mType = NotificationType.NT_OPEN_PlAY });

            });

            //真实体验
            Icon4.onClick.AddListener(() =>
            {
                CloseSelf();
                UIMgr.ClosePanel<UI_Video>();
                UIPanel ui = UIMgr.GetPanel<UI_Video>();

                NotificationCenter.Instance().sendPublicMessage(new NotificationData() { mType = NotificationType.UI_VIDEO_CLOSE });

                GameObject obj = Instantiate(Resources.Load("Model/UI_Dry_Obj") as GameObject);

                UIMgr.OpenPanel<UI_Dry>(UILevel.Common, prefabName: "Resources/UI_Dry");
            });

            //颜色认知
            Icon5.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_Game>(UILevel.AlwayTop, prefabName: "Resources/UI_Indro");
                CloseSelf();
            });

            //自检
            Icon6.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_SelfTest>(UILevel.Common, prefabName: "Resources/UI_SelfTest");
                CloseSelf();
            });

            //知识问答
            Icon7.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_Knowledge>(UILevel.AlwayTop, prefabName: "Resources/UI_Knowledge");
                CloseSelf();
            });

            //退出应用
            Exit.onClick.AddListener(() =>
            {
                Application.Quit();
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
            Debug.Log("[ UI_Main:]" + content);
        }

        UI_MainData mData = null;

        public FadeInOut fadeOut;
    }
}