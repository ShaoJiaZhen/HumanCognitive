using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UniRx;
using QFramework;
using LyNameSpace;

public class TestPlayVideo : MonoBehaviour
{
    private VideoPlayer video;
    private RawImage raw;
    private Camera camera;


    private GameObject Came() {

        return gameObject;
    }

    void OnEnable()
    {

        video = GetComponent<VideoPlayer>();
        camera = GameObject.Find("UICamera").GetComponent<Camera>();
        video.targetCamera = camera;
        raw = GetComponent<RawImage>();
        SetPattern = SetVideoModel.PLAY;
        StartCoroutine(StartPlay());
        NotificationCenter.Instance().subscribePublic(NotificationType.NT_OPEN_PlAY, SetPlayVideo);
        NotificationCenter.Instance().subscribePublic(NotificationType.NT_OPEN_PAUSE, SetPauseVideo);
        NotificationCenter.Instance().subscribePublic(NotificationType.NT_OPEN_STOP, SetStopVideo);

    }

    public void SetPlayVideo(NotificationData data)
    {
        SetPattern = SetVideoModel.PLAY;
    }
    public void SetPauseVideo(NotificationData data)
    {
        SetPattern = SetVideoModel.PAUSE;
    }
    public void SetStopVideo(NotificationData data)
    {
        SetPattern = SetVideoModel.STOP;
    }
    public enum SetVideoModel
    {
        NONE,
        PLAY,
        PAUSE,
        STOP,
        LOOP,
        REASU,
    }
    public SetVideoModel SetPattern;
    private void OnDestroy()
    {
        NotificationCenter.Instance().unSubscribePublic(NotificationType.NT_OPEN_PlAY, SetPlayVideo);

        NotificationCenter.Instance().unSubscribePublic(NotificationType.NT_OPEN_PlAY, SetPauseVideo);

        NotificationCenter.Instance().unSubscribePublic(NotificationType.NT_OPEN_PlAY, SetStopVideo);
    }
    void Update()
    {
        raw.texture = video.texture;
        switch (SetPattern)
        {
            case SetVideoModel.PLAY:
                video.Play();
                break;
            case SetVideoModel.PAUSE:
                video.Pause();
                break;
            case SetVideoModel.STOP:
                video.Stop();
                break;
            case SetVideoModel.REASU:
                break;
            case SetVideoModel.LOOP:
                break;
            default:
                break;
        }
    }
    IEnumerator StartPlay()
    {
        yield return new WaitForSeconds(0.27F);
        SetPattern = SetVideoModel.PAUSE;
        NotificationCenter.Instance().sendPublicMessage(new NotificationData() { mType = NotificationType.NT_OPEN_PAUSE });
    }
}