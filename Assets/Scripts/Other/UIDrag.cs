
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class UIDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        print("start drag");
        print(Input.mousePosition);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;//eventData就是屏幕坐标下的鼠标位置
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        print("end drag");
    }
}