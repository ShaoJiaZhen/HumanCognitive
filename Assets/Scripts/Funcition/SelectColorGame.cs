using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class SelectColorGame : MonoBehaviour
{

    //花朵路径
    private string path = "";
    private bool create = true;
    private int number;
    //花朵列表
    private List<Flower> flowers = new List<Flower>();
    //游戏时长
    private float duration = 90F;
    //游戏状态
    public enum GameState
    {
        INIT,
        START,
        PAUSE,
        FINISH,
        OVER,
        RESTART
    }
    public GameState gameState;

    private ResLoader mResLoader = ResLoader.Allocate();
    private void Start()
    {
        //初始化状态
        //gameState = GameState.INIT;
    }

    private void Update()
    {
        if (number == 45) {
            gameState = GameState.FINISH;
        }
        switch (gameState)
        {

            case GameState.START:
                if (create)
                {
                    Debug.Log("开始游戏");
                    StartCoroutine(StartGame());
                    create = false;
                }
                break;
            case GameState.PAUSE:
                gameState = GameState.START;
                break;
            case GameState.FINISH:
                Debug.Log("完成");
                break;
            case GameState.OVER:
                break;
            case GameState.RESTART:
                break;
            default:
                break;
        }

    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2F);
        number++;
        int random = Random.Range(1, 9);
        mResLoader.LoadSync<GameObject>("Resources/UI/Flower_" + random)
                    .Instantiate()
                    .Name("Flower_" + random);
        Debug.Log("开始");
        create = true;
    }

    public void Recycle()
    {
        mResLoader.Recycle2Cache();
        mResLoader = null;
        Debug.Log("回收");
    }
}
