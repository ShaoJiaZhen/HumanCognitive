using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradeInfo : MonoBehaviour
{
    public List<Toggle> options = new List<Toggle>();
    private List<Toggle> rights = new List<Toggle>();
    private int scoreContent = 1;
    public GameObject scoreUI;
    public Text scoreInfo;

    private void Start()
    {
        options[0].onValueChanged.AddListener((bool isOn) => { OnToogleOne(options[0], isOn); });
        options[1].onValueChanged.AddListener((bool isOn) => { OnToogleTwo(options[01], isOn); });
        options[2].onValueChanged.AddListener((bool isOn) => { OnToogleThr(options[2], isOn); });
        options[3].onValueChanged.AddListener((bool isOn) => { OnToogleLastA(options[3], isOn); });

        options[4].onValueChanged.AddListener((bool isOn) => { OnToogleLastB(options[4], isOn); });
        options[5].onValueChanged.AddListener((bool isOn) => { OnToogleLastC(options[5], isOn); });
    }

    //正确得答案
    private void OnToogleOne(Toggle toogle, bool isOn)
    {

    }
    private void OnToogleTwo(Toggle toogle, bool isOn)
    {

    }
    private void OnToogleThr(Toggle toogle, bool isOn)
    {

    }

    //最后三个  点击任何一个  都会结束做题  显示答案
    private void OnToogleLastA(Toggle toogle, bool isOn)
    {
        //4——A
        GetGrade();
        CountGrade();
        int best = scoreContent - 1;
        DisplayGradeInfo(best * 25);
    }
    private void OnToogleLastB(Toggle toogle, bool isOn)
    {
        //4——B
        GetGrade();
        CountGrade();
        int best = scoreContent - 2;
        DisplayGradeInfo(best * 25);
    }
    private void OnToogleLastC(Toggle toogle, bool isOn)
    {
        //4——C
        GetGrade();
        CountGrade();
        int best = scoreContent - 1;
        DisplayGradeInfo(best * 25);
    }

    private void GetGrade()
    {
        for (int i = 0; i < options.Count - 1; i++)
        {
            if (options[i].isOn == true)
            {
                int info = scoreContent++;
                rights.Add(options[i]);
            }

        }
    }
    private void CountGrade()
    {
        for (int i = 0; i < rights.Count; i++)
        {


            if (rights[i].isOn == true)
            {

                int info = 1;
                int result = info++;
                //Debug.Log("显示成绩" + result);

            }
        }
    }
    private void DisplayGradeInfo(int grade)
    {
        if (scoreUI) { scoreUI.transform.gameObject.SetActive(true); }
        scoreInfo.text = grade.ToString()+ "分" ;
    }

}