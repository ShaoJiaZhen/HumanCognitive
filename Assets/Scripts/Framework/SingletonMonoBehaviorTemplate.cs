﻿using UnityEngine;
/// <summary>
/// 需要使用Unity生命周期的单例模式
/// </summary>
/// 使用的时候直接继承此类就行了
namespace LyNameSpace
{
    public abstract class QMonoSingleton<T> : MonoBehaviour where T : QMonoSingleton<T>
    {
        protected static T instance = null;
        public static T Instance()
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (FindObjectsOfType<T>().Length > 1)
                {
                    return instance;
                }

                if (instance == null)
                {
                    string instanceName = typeof(T).Name;
                    GameObject instanceGO = GameObject.Find(instanceName);

                    if (instanceGO == null)
                        instanceGO = new GameObject(instanceName);
                    instance = instanceGO.AddComponent<T>();
                    DontDestroyOnLoad(instanceGO);
                }
            }

            return instance;
        }

        protected virtual void OnDestroy()
        {
            instance = null;
        }
    }

}