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
	public class TestData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class Test : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as TestData ?? new TestData();
			//please add init code here
		}

		protected override void ProcessMsg (int eventId,QMsg msg)
		{
			throw new System.NotImplementedException ();
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
			base.OnHide();
		}

		protected override void OnClose()
		{
			base.OnClose();
		}

		void ShowLog(string content)
		{
			Debug.Log("[ Test:]" + content);
		}

		TestData mData = null;
	}
}