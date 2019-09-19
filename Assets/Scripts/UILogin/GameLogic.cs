using UnityEngine;
using System;

namespace QFramework.UIExample
{
    public class GameLogic : MonoBehaviour
    {
        private void Awake()
        {

            GameObject ui = GameObject.Find("UIRoot");
            GameObject obj = GameObject.Find("GarbagePoints");
            if (ui&& obj)
            {
                ui.SetActive(false);
                obj.SetActive(false);
            }


            UIMgr.OpenPanel<UIMenuPanel>(prefabName: "Resources/UI_Video");
            UIMgr.OpenPanel<UIMenuPanel>(prefabName: "Resources/UI_Home");
            Instantiate(Resources.Load("Model/Rubbish"));
        }
    }
}
