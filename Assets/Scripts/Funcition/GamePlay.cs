using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamePlay : MonoBehaviour
{

    private void Start()
    {
        
    }
    private void Update()
    {
        this.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x - (this.GetComponent<RectTransform>().sizeDelta.x / 2),
           Input.mousePosition.y - (this.GetComponent<RectTransform>().sizeDelta.y / 2)
           , 0);

    }
}