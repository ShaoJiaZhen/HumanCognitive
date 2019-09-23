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
	public class UI_Sh_3Data : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class UI_Sh_3 : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UI_Sh_3Data ?? new UI_Sh_3Data();
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
                UIMgr.OpenPanel<UI_Sh_4>(UILevel.Common, prefabName: "Resources/UI_Sh_4");
                CloseSelf();
            });
            upPage.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_Sh_2>(UILevel.Common, prefabName: "Resources/UI_Sh_2");
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
			Debug.Log("[ UI_Sh_3:]" + content);
		}

		UI_Sh_3Data mData = null;
	}
}