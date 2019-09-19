using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{

    private Flower flower;

    //判断是否正确
    public Image rightIE;
    public Image erroeIE;

    //标记自身
    public int indexSelf;


    //显示图片 根据传入的索引  显示相对应的图片
    private void DisplayState(int index)
    {
        if (index == 1) { rightIE.transform.gameObject.SetActive(true); erroeIE.transform.gameObject.SetActive(false); }
        if (index == 2) { erroeIE.transform.gameObject.SetActive(true); rightIE.transform.gameObject.SetActive(false); }

        StartCoroutine(HideFlower());
    }
    //三秒之后图片回复原始状态
    private void OriginState()
    {



    }


    //篮子的三种状态
    public enum SelectDir
    {
        INIT,
        RIGHT,
        ERROW,
        ORIGIN,
    }
    public SelectDir selectDit;


    private void PairState()
    {



    }


    private void Start()
    {
        erroeIE.transform.gameObject.SetActive(false); rightIE.transform.gameObject.SetActive(false);
        selectDit = SelectDir.INIT;
    }

    //判断状态
    private void Update()
    {
        switch (selectDit)
        {
            case SelectDir.RIGHT:
                DisplayState(1);
                break;
            case SelectDir.ERROW:
                DisplayState(2);
                break;
            case SelectDir.ORIGIN:
                erroeIE.transform.gameObject.SetActive(false); rightIE.transform.gameObject.SetActive(false);

                break;
            default:
                break;

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        DisposeTriggerStay(collision);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        DisposeTriggerEnter(collision);
    }


    private void DisposeTriggerEnter(Collider2D collision)
    {

    }


    private void DisposeTriggerStay(Collider2D collision)
    {
        if (collision.GetComponent<Flower>())
        {
            flower = collision.GetComponent<Flower>();
            if (indexSelf == flower.GetIndexs)
            {
                if (flower.StateMouse == false)
                {
                    selectDit = SelectDir.RIGHT;
                }
            }
            else if (indexSelf != flower.GetIndexs)
            {
                selectDit = SelectDir.ERROW;
            }
        }
    }


    //根据状态选择是否消失
    IEnumerator HideFlower()
    {
        if (flower) { flower.transform.gameObject.SetActive(false); }
        yield return new WaitForSeconds(0.25F);
        selectDit = SelectDir.ORIGIN;
    }
}
