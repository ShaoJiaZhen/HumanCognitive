using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObject : MonoBehaviour
{

    public Camera cam;
    float speed = 400;
    float x, y;
    float rotationY;
    float minimumY = -60;
    float maximumY = 90;
    bool isOpen;
    bool isStart = true;
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            isOpen = true;
            isStart = false;
            selfX = transform.eulerAngles.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isOpen = false;
            Debug.Log("结束旋转");
            isStart = true;

        }
        if (isOpen)
        {
          
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 20;
            float valueY= transform.eulerAngles.x;
            valueY += Input.GetAxis("Mouse Y") * 20;
            valueY = Mathf.Clamp(valueY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(valueY, 0, 0);


            Debug.Log("计算后的值" + rotationY);
        }
        if (isStart)
        {
            AutoRotate();
        }
    }
    private float selfX;
    private void AutoRotate()
    {
        transform.Rotate(new Vector3(1 * 20 * Time.deltaTime, 0, 0));

    }
}
