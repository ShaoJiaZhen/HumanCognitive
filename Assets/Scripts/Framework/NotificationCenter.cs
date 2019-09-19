using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LyNameSpace;
//消息类型
public enum NotificationType
{
    NT_NONE,
    NT_OPEN_PlAY,
    NT_OPEN_PAUSE,
    NT_OPEN_STOP,


    UI_VIDEO_CLOSE,
    UI_VIDEO_HIDE,
}

//消息参数
public class NotificationData
{
    public object mPara;
    public NotificationType mType;
}

public delegate void HandleMessageDelegate(NotificationData data);

//callback结构
public class NotificationCallBack
{
    public NotificationData mData;
    public event HandleMessageDelegate handleMessageEvent;
    public int mDelegateCount;

    public NotificationCallBack()
    {
        mDelegateCount = 0;
        mData = new NotificationData();
    }

    // 添加
    public void addNewDelegate(HandleMessageDelegate handler)
    {
        handleMessageEvent += handler;
        mDelegateCount++;
    }

    public void deleteOneDelegate(HandleMessageDelegate handler, out bool needToDelete)
    {
        handleMessageEvent -= handler;
        --mDelegateCount;
        if (mDelegateCount <= 0)
        {
            needToDelete = true;
        }
        needToDelete = false;
    }

    public void executeOnce(object para)
    {
        mData.mPara = para;
        if (handleMessageEvent != null)
        {
            handleMessageEvent(mData);
        }
    }
}

//消息中心
public class NotificationCenter : QSingleton<NotificationCenter>
{

    //构造函数
    private NotificationCenter()
    {

    }

    private Dictionary<NotificationType, NotificationCallBack> mPublicMessages = new Dictionary<NotificationType, NotificationCallBack>();
    private Dictionary<NotificationType, Dictionary<Object, NotificationCallBack>> mPrivateMessages = new Dictionary<NotificationType, Dictionary<Object, NotificationCallBack>>();

    //订阅公有函数
    public void subscribePublic(NotificationType type, HandleMessageDelegate handler)
    {
        if (!mPublicMessages.ContainsKey(type))
        {
            mPublicMessages.Add(type, new NotificationCallBack());
        }

        mPublicMessages[type].addNewDelegate(handler);
    }

    //取消公有函数订阅
    public void unSubscribePublic(NotificationType type, HandleMessageDelegate handler)
    {
        if (!mPublicMessages.ContainsKey(type))
        {
            Debug.LogError("public dictionary doesn't has the key: " + type.ToString());
        }
        bool needToDelete;
        mPublicMessages[type].deleteOneDelegate(handler, out needToDelete);
        if (needToDelete)
        {
            mPublicMessages.Remove(type);
        }
    }
    //订阅私有函数
    public void subscribePrivate(NotificationType type, HandleMessageDelegate handler, Object _obj)
    {
        if (!mPrivateMessages.ContainsKey(type))
        {
            mPrivateMessages.Add(type, new Dictionary<Object, NotificationCallBack>());
        }
        if (!mPrivateMessages[type].ContainsKey(_obj))
        {
            mPrivateMessages[type].Add(_obj, new NotificationCallBack());
        }

        mPrivateMessages[type][_obj].addNewDelegate(handler);
    }
    //取消私有函数订阅
    public void unSubscribePrivate(NotificationType type, HandleMessageDelegate handler, Object _obj)
    {
        if (!mPrivateMessages.ContainsKey(type))
        {
            Debug.LogError("private dictionary doesn't has the key: " + type.ToString());
        }

        if (!mPrivateMessages[type].ContainsKey(_obj))
        {
            Debug.LogError("private dictionary doesn't has the object: " + _obj.name);
        }

        bool needToDelete;
        mPrivateMessages[type][_obj].deleteOneDelegate(handler, out needToDelete);
        if (needToDelete)
        {
            mPrivateMessages[type].Remove(_obj);
            if (mPrivateMessages[type].Count == 0)
            {
                mPrivateMessages.Remove(type);
            }
        }
    }
    //发送公有函数消息
    public void sendPublicMessage(NotificationData data)
    {
        if (mPublicMessages.ContainsKey(data.mType))
        {
            mPublicMessages[data.mType].executeOnce(data.mPara);
        }
    }
    //发送私有函数消息
    public void sendPrivateMessage(NotificationData data, Object _obj)
    {
        if (mPrivateMessages.ContainsKey(data.mType))
        {
            if (mPrivateMessages[data.mType].ContainsKey(_obj))
            {
                mPrivateMessages[data.mType][_obj].executeOnce(data.mPara);
            }
        }
    }
}
