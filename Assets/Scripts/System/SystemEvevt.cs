using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemEvevt : MonoBehaviour
{
    //骨骼
    private List<Button> singleBtn = new List<Button>();
    //提示
    public List<Image> tipImage = new List<Image>();
    //器官
    public List<Transform> partBody = new List<Transform>();
    //滑动框
    public RectTransform rectTransform;
    //控制条
    public Scrollbar scrollbar;
    [Header("呼吸")]
    public List<string> breathe = new List<string>();
    public List<string> nerve = new List<string>();
    public List<string> sleleton = new List<string>();
    public List<string> metabolism = new List<string>();
    public List<string> digestion = new List<string>();
    public List<string> internalSecretion = new List<string>();
    public List<string> angiocarpy = new List<string>();
    public List<string> urinary = new List<string>();

    public Transform bodyParent;
    public Transform illnessParent;
    public Transform tipParent;
    private void Start()
    {
        foreach (Transform trans in transform)
        {
            Button btn = trans.GetComponent<Button>();
            if (btn != null) { singleBtn.Add(btn); }
        }
        foreach (Transform trans in bodyParent)
        {
            partBody.Add(trans);
        }
        foreach (Transform trans in tipParent)
        {
            Image img = trans.GetComponent<Image>();
            tipImage.Add(img);
        }
        singleBtn[0].onClick.AddListener(OnClickBreathe);
        singleBtn[1].onClick.AddListener(OnClickNerve);
        singleBtn[2].onClick.AddListener(OnClickSkeleton);
        singleBtn[3].onClick.AddListener(OnClickMetabolism);
        singleBtn[4].onClick.AddListener(OnClickDigestion);
        singleBtn[5].onClick.AddListener(OnClickInternalSecretion);
        singleBtn[6].onClick.AddListener(OnClickAngiocarpy);
        singleBtn[7].onClick.AddListener(OnClickUrinary);
        HideAll();
        CreateIllness(breathe);
        HideOther(0);
    }
    //呼吸
    private void OnClickBreathe()
    {
        HideOther(0);
        ShowBody(0);
        ShowLeftTip(0);
        CreateIllness(breathe);
    }
    //神经
    private void OnClickNerve()
    {
        HideOther(1);
        ShowBody(1);
        ShowLeftTip(1);
        CreateIllness(nerve);
    }
    //骨骼
    private void OnClickSkeleton()
    {
        HideOther(2);
        ShowBody(2);
        ShowLeftTip(2);
        CreateIllness(sleleton);
    }
    //代谢
    private void OnClickMetabolism()
    {
        HideOther(3);
        ShowBody(3);
        ShowLeftTip(3);
        CreateIllness(metabolism);
    }
    //消化
    private void OnClickDigestion()
    {
        HideOther(4);
        ShowBody(4);
        ShowLeftTip(4);
        CreateIllness(digestion);
    }
    //内分泌
    private void OnClickInternalSecretion()
    {
        HideOther(5);
        ShowBody(5);
        ShowLeftTip(5);
        CreateIllness(internalSecretion);
    }
    //心血管
    private void OnClickAngiocarpy()
    {
        HideOther(6);
        ShowBody(6);
        ShowLeftTip(6);
        CreateIllness(angiocarpy);
    }
    //泌尿
    private void OnClickUrinary()
    {
        HideOther(7);
        ShowBody(7);
        ShowLeftTip(7);
        CreateIllness(urinary);
    }

    private void HideOther(int index)
    {
        for (int i = 0; i < singleBtn.Count; i++)
        {
            Image img = singleBtn[i].gameObject.transform.GetChild(1).GetComponent<Image>();
            img.enabled = false;
        }
        singleBtn[index].gameObject.transform.GetChild(1).GetComponent<Image>().enabled = true;
    }

    private void HideAll()
    {
        for (int i = 0; i < singleBtn.Count; i++)
        {
            Image img = singleBtn[i].gameObject.transform.GetChild(1).GetComponent<Image>();
            img.enabled = false;
        }
    }
    private void ShowAll()
    {
        foreach (Transform trans in bodyParent)
        {
            Transform obj = trans.GetComponent<Transform>();
            partBody.Add(obj);
        }
    }
    private void ShowBody(int index)
    {
        number = index;
        for (int i = 0; i < partBody.Count; i++)
        {
            Transform obj = partBody[i].GetComponent<Transform>();
            HighlightableObject ho = obj.root.GetComponentInChildren<HighlightableObject>();
            if (ho != null)
            {
                ho.enabled = false;
            }
            obj.gameObject.SetActive(false);
        }
        partBody[index].gameObject.SetActive(true);
        HighlightableObject hight = partBody[index].root.GetComponentInChildren<HighlightableObject>();
        if (hight != null)
        {
           hight.enabled = true;
           hight.On(Color.red);
        }
    }
    public int number;

    private void Update()
    {
        ShowBody(number);
    }

    private void CreateIllness(List<string> system)
    {
        foreach (Transform ill in illnessParent)
        {
            Destroy(ill.gameObject);
        }
        for (int i = 0; i < system.Count; i++)
        {
            GameObject illness = Instantiate(Resources.Load("HumanCongitive/Illness") as GameObject);

            Text text = illness.transform.GetChild(0).GetComponent<Text>();
            text.text = system[i];
            illness.transform.SetParent(illnessParent);
            illness.transform.localPosition = new Vector3(0, 0, 0);
            illness.transform.localScale = new Vector3(1, 1, 1);
            illness.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
    public void ShowLeftTip(int index)
    {
        for (int i = 0; i < tipImage.Count; i++)
        {
            tipImage[i].enabled = false;
            tipImage[index].enabled = true;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, tipImage[index].transform.GetComponent<RectTransform>().sizeDelta.y);
            scrollbar.value = 1F;
        }
    }
}
