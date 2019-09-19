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
	public class UI_Sh_2Data : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class UI_Sh_2 : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UI_Sh_2Data ?? new UI_Sh_2Data();
			//please add init code here
		}

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
			throw new System.NotImplementedException ();
		}

		protected override void RegisterUIEvent()
		{

            myBack.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_Main>(UILevel.Common, prefabName: "Resources/UI_Main");
                CloseSelf();
            });
            nextPage.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_Main>(UILevel.Common, prefabName: "Resources/UI_Sh_3");
                CloseSelf();
            });
            upPage.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_Main>(UILevel.Common, prefabName: "Resources/UI_Sketch");
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
			Debug.Log("[ UI_Sh_2:]" + content);
		}

		UI_Sh_2Data mData = null;
	}
}