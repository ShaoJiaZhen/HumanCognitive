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
	public class UI_StartData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class UI_Start : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UI_StartData ?? new UI_StartData();
			//please add init code here
		}

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
			throw new System.NotImplementedException ();
		}

		protected override void RegisterUIEvent()
		{

            myStartBtn.onClick.AddListener(() =>
            {
                UIMgr.OpenPanel<UI_Main>(UILevel.Common, prefabName: "Resources/UI_Main");
                CloseSelf();
                Debug.Log("显示其他，关闭自己");
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
			Debug.Log("[ UI_Start:]" + content);
		}
       
        

        UI_StartData mData = null;
	}
}