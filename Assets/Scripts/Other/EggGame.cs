using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EggGame : MonoBehaviour
{
    #region
    private string eggPath = "Prefabs/Egg";
    private bool timeKeeping = true;
    private GameObject eggParent;
    private RectTransform rectTrandform;
    #endregion



    private void Start()
    {
        eggParent = Instantiate(Resources.Load("Prefabs/EggGame") as GameObject);
        rectTrandform = transform.GetComponent<RectTransform>();
        InstiationFactroy("Prefabs/Basket");

    }


    //拖拽篮子
    public void OnDrag(PointerEventData eventData)

    {
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTrandform, eventData.position,
        eventData.pressEventCamera, out globalMousePos))
        {
            rectTrandform.position = globalMousePos;
        }
    }

    private void Update()
    {
        if (timeKeeping)
        {
            StartCoroutine(StartCreaterEgg());
            timeKeeping = false;
        }


    }

    IEnumerator StartCreaterEgg()
    {
        yield return new WaitForSeconds(1);
        CreateEgg();
        timeKeeping = true;
    }
    //加载资源
    private void CreateEgg()
    {
        int randomEgg = Random.Range(1, 3);
        string path = eggPath + randomEgg.ToString();
        GameObject egg = Instantiate(Resources.Load(path) as GameObject);
        egg.gameObject.transform.SetParent(eggParent.transform);
        int randomNumber = Random.Range(-370, 390);
        egg.transform.localPosition = new Vector3(randomNumber, 165, 0);
        Rigidbody2D rigidbody = egg.GetComponent<Rigidbody2D>();
        //rigidbody.gravityScale = 20;
        rigidbody.gravityScale = 0;
    }
    private void InstiationFactroy(string path)
    {
        int randomNumber = Random.Range(1, 3);
        GameObject model = Instantiate(Resources.Load(path + randomNumber) as GameObject);
        model.transform.SetParent(eggParent.transform);
        model.transform.localPosition = new Vector3(0, -394, 0);
    }
}
