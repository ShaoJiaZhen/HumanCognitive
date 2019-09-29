using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Illness : MonoBehaviour
{
    public Button loadBtn;
    public Text nameIllness;

    private void Start()
    {
        loadBtn = this.GetComponent<Button>();
        this.nameIllness = this.transform.GetChild(0).GetComponent<Text>();
        loadBtn.onClick.AddListener(Loaded);
    }
    private void Loaded()
    {
        Debug.Log("名字" + nameIllness.text);
        SceneManager.LoadScene(nameIllness.text);
    }
}
