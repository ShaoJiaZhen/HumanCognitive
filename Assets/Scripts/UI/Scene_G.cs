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
	public class Scene_GData : UIPanelData
	{
		// TODO: Query Mgr's Data
	}

	public partial class Scene_G : UIPanel
	{
		protected override void InitUI(IUIData uiData = null)
		{
			mData = uiData as Scene_GData ?? new Scene_GData();
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
                //Debug.Log("测试");
              
                SceneManager.LoadScene("Eye1.0");
                UIMgr.OpenPanel<UI_Main>(UILevel.Common, prefabName: "Resources/UI_Main");
                CloseSelf();
                Destroy(this.gameObject);
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
			Debug.Log("[ Scene_G:]" + content);
		}

		Scene_GData mData = null;
	}
}