using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseEvent : MonoBehaviour {

    private Button bt;
    void Start()
    {
         bt = GetComponent<Button>();
    }

    public void OnMouseOver()
    {
        Debug.Log("放在物体上");
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
