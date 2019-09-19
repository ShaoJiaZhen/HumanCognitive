using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{

    private float x;
    private float y=0;
    private float z;

    void Start()
    {
        CreateGameModel();
    }

    private void CreateGameModel()
    {
       
        for (int i = 0; i <2000; i++)
        {
            float randomX = Random.Range(0,10);
            float randomY = Random.Range(0,10);
            float randomZ = Random.Range(0,10);
           
            y++;
            x++;
            z++;
            GameObject sphere = Instantiate(Resources.Load("Prefabs/Sphere") as GameObject);
            sphere.transform.position = new Vector3(x/10+randomX, y/randomY, randomZ/2);
        }
    }
}
