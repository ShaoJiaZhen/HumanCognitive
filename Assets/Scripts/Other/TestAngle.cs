using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAngle : MonoBehaviour
{


    public Transform rotateTarget;      //限制旋转对象

    [Header("旋转速度")]
    public float moveSpeed = 10;
    [Header("限制旋转角度")]
    [Header("最小")]
    public float minAngleY = -50;
    [Header("最大")]
    public float maxAngleY = 80;

    private float rotationY = 0;
    private float rotationX = 0;

    private void ControllerPro()
    {

        rotationX += -Input.GetAxis("Mouse X") * moveSpeed;
        rotationY += Input.GetAxis("Mouse Y") * moveSpeed;
        rotationY = Mathf.Clamp(rotationY, minAngleY, maxAngleY);
        rotateTarget.localEulerAngles = new Vector3(-rotationY, rotationX, rotateTarget.rotation.z);
    }
}