using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionBasket : MonoBehaviour
{

    public int IDEgg;

    public int GetIDSign()
    {
        Debug.Log("获取蛋的自身ID");
        return IDEgg;
    } 
    private void Start()
    {
        StartCoroutine(TimeDestroy());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Cube")
        {
            string id = collision.collider.name.ToString().Substring(0, 7);

            string index = id.Substring(id.Length - 1, 1);

            if (IDEgg.ToString() == index)
            {

                Destroy(this.gameObject);
            }

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(4F);
        Destroy(this.gameObject);
    }

}
