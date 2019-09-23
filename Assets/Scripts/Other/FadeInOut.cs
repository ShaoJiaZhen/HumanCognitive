using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeInOut : MonoBehaviour
{


    [Header("淡出速度")]
    public float fadeSpeed;
    [Header("需要淡出的UI")]
    public Image image;
    private bool isStartFade;
    public bool IsStartFade
    {
        get
        {
            return isStartFade;
        }

        set
        {
            isStartFade = value;
        }
    }
    private void FadeToIn()
    {
        image.color = Color.Lerp(image.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    private void FadeToOut()
    {
        image.color = Color.Lerp(image.color, new Color(255, 255, 255), fadeSpeed * Time.deltaTime);
    }
    public enum FadeEffect
    {
        In,
        Out
    }
    public FadeEffect fadeEffect;

   

    private void Update()
    {
        if (IsStartFade)
        {
            Debug.Log("开始淡入淡出");
            switch (fadeEffect)
            {
                case FadeEffect.In:
                    FadeToIn();
                    if (image.color.a <= 0.01F) IsStartFade = false;
                    break;
                case FadeEffect.Out:
                    FadeToOut();
                    if (image.color.a >= 0.99F) IsStartFade = false;
                    break;
                default:
                    break;
            }


        }

    }
}
