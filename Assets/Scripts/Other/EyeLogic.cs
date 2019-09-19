using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLogic : MonoBehaviour
{
    #region Variable
    private bool isAutorotation = true;
    private bool isOriginPos = true;
    private bool isUIPlane = false;
    private bool isOpen = false;
    private bool isRotation = true;
    private float startTime;
    private float endTime;
    private float rotationY;
    private float rotationX;
    private Camera cameraMain;
    #endregion
    [Header("旋转轴向")]
    public AxialRotation axial;
    public enum AxialRotation
    {
        Axial_X,
        Axial_Y,
        Axial_Z,
    }
    [Header("鼠标旋转速度")]
    public float mouseSpeed;
    [Header("自动旋转速度")]
    public float autoSpeed;
    [Header("返回原点速度")]
    public float originSpeed;
    [Header("X轴最小旋转角度")]
    public float minAngleY = -50;
    [Header("X轴最大旋转角度")]
    public float maxAngleY = 80;
    [Header("图标")]
    public GameObject skipbutton;
    private void Start()
    {
        if (skipbutton == null) return; skipbutton.SetActive(false);
        cameraMain = GameObject.Find("Camera").GetComponent<Camera>();
        if (!cameraMain) startTime = Time.time;
    }

    private float storageX;
    //自动旋转
    private void AutoRotation()
    {
        switch (axial)
        {
            case AxialRotation.Axial_X:
                 
                break;
            case AxialRotation.Axial_Y:
                transform.Rotate(new Vector3(0, 1 * autoSpeed * Time.deltaTime, 0));
                break;
            case AxialRotation.Axial_Z:
                transform.Rotate(new Vector3(0, 0, 1 * autoSpeed * Time.deltaTime));
                break;
            default:
                break;
        }

    }


    Vector3 offset;
    Vector3 StartPosition;
    Vector3 previousPosition;
    Vector3 screenPoint;
    //鼠标控制旋转
    private void ControllerRotate()
    {
        GetNewPos();

        RotationX += -Input.GetAxis("Mouse X") * mouseSpeed;
        RotationY += Input.GetAxis("Mouse Y") * mouseSpeed;
        RotationY = Mathf.Clamp(RotationY, minAngleY, maxAngleY);

        Debug.Log("X"+RotationX);
        //Vector3 offsetX = Input.mousePosition;
        transform.eulerAngles = new Vector3(-RotationY, RotationX, this.transform.rotation.z);
     
    }
    //角度复位
    private void RestorationAngle()
    {
        Quaternion target = Quaternion.Euler(0, 90, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, originSpeed);

        if (transform.rotation.eulerAngles.x == 0)
        {
            StartCoroutine(SetRestorationTime());
        }
    }
    IEnumerator SetRestorationTime()
    {
        yield return new WaitForEndOfFrame();
        isAutorotation = true;
        isOriginPos = true;
        isOpen = false;
    }
    //双击检测
    private void ClickEye()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.name == "Eye")
                {

                    endTime = Time.realtimeSinceStartup;
                    if (endTime - startTime < 0.5F)
                    {
                        if (isUIPlane == false)
                        {

                            ShowSkipButton(true);
                            isUIPlane = true;
                        }
                        else if (isUIPlane == true)
                        {
                            ShowSkipButton(false);
                            isUIPlane = false;
                        }

                    }
                    startTime = endTime;
                }
            }
        }
    }
    //显示UI
    private void ShowSkipButton(bool isActive)
    {

        if (!skipbutton)
            skipbutton.SetActive(isActive);
        isUIPlane = isActive;
    }
    private bool isGetNewPos;

    public float RotationX
    {
        get
        {
            return rotationX;
        }

        set
        {
            rotationX = value;
        }
    }

    public float RotationY
    {
        get
        {
            return rotationY;
        }

        set
        {
            rotationY = value;
        }
    }

    //获取最新位置
    private void GetNewPos()
    {
        if (isGetNewPos)
        {
            RotationX = this.gameObject.transform.eulerAngles.x;
            RotationY = this.gameObject.transform.eulerAngles.y;
        }
    }



    float minimumY = -60;
    float maximumY = 90;
    private void ControllerRo()
    {

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 20;
        rotationY += Input.GetAxis("Mouse Y") * 20;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

    private void Update()
    {
        if (isOriginPos)
        {
            if (isAutorotation)
            {
                Debug.Log("开始自动旋转");
                AutoRotation();

            }
        }
        if (Input.GetMouseButton(0))
        {
            //先获取位置信息
            //控制转动
            isGetNewPos = true;
            isOriginPos = false;
            isAutorotation = false;

            //ControllerRotate();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isOpen = true;
            isGetNewPos = false;
        }

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 20;
        rotationY += Input.GetAxis("Mouse Y") * 20;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        float value = rotationY + this.transform.eulerAngles.x;
        if (isGetNewPos)
        {
            transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        }

        if (isOpen)
        {
            RestorationAngle();

        }
    }

}