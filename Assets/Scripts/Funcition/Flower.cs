using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Flower : MonoBehaviour, IDragHandler
{

    //自身状态

    private bool stateSelf;

    //鼠标状态
    private bool stateMouse;
    public bool StateMouse
    {
        get
        {
            return stateMouse;
        }
    }
    //自身标记
    public int indexSelf;
    public int GetIndexs
    {
        get
        {
            return indexSelf;
        }
    }

    //限制的区域
    private float minX = -9000;
    private float maxX = 9000;

    private float minY = -490;
    private float maxY = 490;
    private Vector3 pos = new Vector2();
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(GetComponent<RectTransform>(), eventData.position, Camera.main, out pos);
        transform.position = pos;
        // transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), 0);
        flowerState = FlowerState.DRAG;
    }

    //开始自动移动
    private void AutoMove()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime *50, Space.World);
        if (this.transform.localPosition.x <= -820) {

            this.transform.gameObject.SetActive(false);
        }
    }

    //Fl的状态
    public enum FlowerState
    {
        INIT,//初始化
        MOVE,//开始移动
        DRAG,//被拖动
        DOWN,//按下鼠标
        UP,//抬起鼠标
        REPLACE,
    }
    public FlowerState flowerState;



    private void Start()
    {

    }
    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            flowerState = FlowerState.REPLACE;

        }
        switch (flowerState)
        {
            case FlowerState.INIT:
                AutoMove();
                break;
            case FlowerState.MOVE:
                break;
            case FlowerState.DRAG:
                break;
            case FlowerState.DOWN:
                stateMouse = true;
                break;
            case FlowerState.UP:
                stateMouse = false;
                flowerState = FlowerState.INIT;
                break;
            case FlowerState.REPLACE:
                ReplaceMove();
                break;

        }
    }
    private void ReplaceMove()
    {
        Rigidbody2D rig = this.gameObject.GetComponent<Rigidbody2D>();
        rig.simulated = true;
        rig.gravityScale = 20;
        if (rig.transform.localPosition.y <= -361)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, -361, this.transform.localPosition.z);
            rig.simulated = false;
            flowerState = FlowerState.INIT;
        }
    }


}
