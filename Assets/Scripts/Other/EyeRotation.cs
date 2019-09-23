using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRotation : MonoBehaviour
{


    private Camera cameraObj;

    //眼球数组
    private List<GameObject> EyeObjs = new List<GameObject>();




    //根据UI显示相对应的眼睛结构图层
    private void HideEyeObj()
    {



    }

    //控制眼球旋转
    private void MouseControlEye()
    { }




    private void Update()
    {
        Vector3 fwd = cameraObj.transform.forward;
        fwd.Normalize();
        if (Input.GetMouseButton(0))
        {
            Vector3 vaxis = Vector3.Cross(fwd, Vector3.right);
            transform.Rotate(vaxis, -Input.GetAxis("Mouse X"), Space.World);
            Vector3 haxis = Vector3.Cross(fwd, Vector3.up);
            transform.Rotate(haxis, -Input.GetAxis("Mouse Y"), Space.World);
            Debug.Log("测试");
        }
    }
















}
