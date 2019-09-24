using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemBtn : MonoBehaviour
{

    public List<Button> singleBtn = new List<Button>();
    public Button selfBtn;
    public Image darkImage;
    public Image tintImage;
    void Start()
    {
        selfBtn = GetComponent<Button>();

        tintImage = this.gameObject.transform.GetChild(0).GetComponent<Image>();
        darkImage = this.gameObject.transform.GetChild(1).GetComponent<Image>();
        darkImage.enabled = false;
        selfBtn.onClick.AddListener(OnClickShow);

    }
    private void OnClickShow()
    {
        ShowImage(true,false);
    }
    private void ShowImage(bool dark, bool tint)
    {
        darkImage.enabled = dark;
        tintImage.enabled = tint;
    }
}
