﻿/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	public class UI_PreventiveCareData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class UI_PreventiveCare : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as UI_PreventiveCareData ?? new UI_PreventiveCareData();
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

		void ShowLog(string content)
		{
			Debug.Log("[ UI_PreventiveCare:]" + content);
		}

		UI_PreventiveCareData mData = null;
	}
}