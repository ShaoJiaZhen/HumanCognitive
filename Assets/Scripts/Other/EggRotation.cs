  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggRotation : MonoBehaviour
{
    #region Variable
    private bool isAutorotation = true;
    private float t;
    private float t1;
    public float speedRotation;
    public float mouseRotation = 30F;
 
    private Camera cameraMain;
  
    #endregion

    public enum AxialRotation
    {
        Axial_X,
        Axial_Y,
        Axial_Z,
    }
    public AxialRotation encompassmentPoint;

    private void Start()
    {
        cameraMain = GameObject.Find("Camera").GetComponent<Camera>();
        //this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        t = Time.time;
    }

    private void Update()
    {
        #region
        if (isAutorotation)
        {
            AutoRotation();
        }
        if (Input.GetMouseButton(0))
        {
            isAutorotation = false;
            MouseControl();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isAutorotation = true;
        }
        #endregion
    }


    #region 旋转
    private void AutoRotation()
    {
        switch (encompassmentPoint)
        {
            case AxialRotation.Axial_X:
                transform.Rotate(new Vector3(1 * speedRotation * Time.deltaTime, 0, 0));
                break;
            case AxialRotation.Axial_Y:
                transform.Rotate(new Vector3(0, 1 * speedRotation, 0));
                break;
            case AxialRotation.Axial_Z:
                transform.Rotate(new Vector3(0, 0, 1));
                break;
            default:
                break;
        }

    }
    private void MouseControl()
    {
        Vector3 fwd = cameraMain.transform.forward;
        Vector3 vaxis = Vector3.Cross(fwd, Vector3.right);
        transform.Rotate(0, -Input.GetAxis("Mouse X") * mouseRotation, 0);

        //Vector3 haxis = Vector3.Cross(fwd, Vector3.up);
        //transform.Rotate(haxis, -Input.GetAxis("Mouse Y") * 45, Space.World);
    }

       
    #endregion

}