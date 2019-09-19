using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GarbagePoints : MonoBehaviour
{
    //开始
    private string pathFlower = "UI/Flower_";

    //储存花
    private List<GameObject> flowers = new List<GameObject>();

    private bool creatStart = false;
    private bool pauseGame = false;
    public GameObject uiFinish;
    public Button playBtn;
    
    private float timer = 60f;
    private void Start()
    {
        autoState = AutoState.INIT;
        playBtn.onClick.AddListener(Init);
    }

    private void Init()
    {
        creatStart = true;
        playBtn.transform.gameObject.SetActive(false);
        InstiationFactroy(pathFlower);
        autoState = AutoState.START;
    }

    IEnumerator CreateFlower()
    {
        yield return new WaitForSeconds(3);
        InstiationFactroy(pathFlower);
        creatStart = true;
    }

    private void Update()
    {
        #region
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameOver();
        }
        if (creatStart && pauseGame == false)
        {
            StartCoroutine(CreateFlower());
            creatStart = false;

        }
        #endregion


        switch (autoState)
        {
            case AutoState.INIT:
                break;
            case AutoState.START:
                break;
            case AutoState.PAUSE:
                break;
            case AutoState.OVER:
                break;
        }
    }

    //删除花朵
    private void DestroyFlowers()
    {

        for (int i = 0; i < flowers.Count; i++)
        {
            GameObject obj = flowers[i].gameObject;
            Destroy(flowers[i].gameObject);
        }
    }
    //游戏结束
    private void GameOver()
    {
        pauseGame = true;

        DisplayFinish();

        DestroyFlowers();
    }
    //显示完成界面
    private void DisplayFinish()
    {
        uiFinish.SetActive(true);
    }
    //实例化花朵
    private void InstiationFactroy(string path)
    {
        int randomNumber = Random.Range(1, 9);
        GameObject model = Instantiate(Resources.Load(path + randomNumber) as GameObject);
        if (!model) return;
        model.transform.SetParent(this.transform);
        model.transform.localPosition = new Vector3(723, -360, 0);
        flowers.Add(model);
    }


    public enum AutoState
    {

        INIT,
        START,
        PAUSE,
        OVER,
        RESTART
    }
    public AutoState autoState;
}