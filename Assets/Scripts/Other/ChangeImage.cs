using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{


    [Header("鼠标滚轮灵敏度度设置")]
    public float sensitivitySet;

    private float scrollWheelValue = 0;
    [Header("需要替换的UI")]
    public List<Image> notePlane = new List<Image>();

    private struct ControlleShow
    {
        public bool isActiveOne;
        public bool isActiveTwo;
        public bool isActiveThree;
        public bool isActiveFour;
    }
    private ControlleShow controlleSshow;
    public enum NoteUIState
    {

        SHOW_ONE,
        SHOW_TWO,
        SHOW_THREE,
        SHOW_FOUR,
        SHOW_INIT,
    }
    private NoteUIState noteUiState;

    public float ScrollWheelValue
    {
        get
        {
            return scrollWheelValue;
        }

        set
        {
            scrollWheelValue = value;
        }
    }

    private void Start()
    {
        controlleSshow.isActiveOne = true;
    }
    void Update()
    {
        ScrollWheelValue -= Input.GetAxis("Mouse ScrollWheel");
        #region
        //switch (noteUiState)
        //{
        //    case NoteUIState.SHOW_ONE:
        //        ReplaceNoteUI((int)NoteUIState.SHOW_ONE);
        //        break;
        //    case NoteUIState.SHOW_TWO:
        //        ReplaceNoteUI((int)NoteUIState.SHOW_TWO);
        //        break;
        //    case NoteUIState.SHOW_THREE:
        //        ReplaceNoteUI((int)NoteUIState.SHOW_THREE);
        //        break;
        //    case NoteUIState.SHOW_FOUR:
        //        ReplaceNoteUI((int)NoteUIState.SHOW_FOUR);
        //        break;

        //    default:
        //        break;
        // }
        #endregion
        #region
        //if (number > 0.1)
        //{
        //    Debug.Log("大于0.1");
        //    //noteUiState = NoteUIState.SHOW_ONE;
        //}
        //if (number >= 0.2)
        //{
        //    Debug.Log("大于0.2");
        //    //noteUiState = NoteUIState.SHOW_TWO;
        //}
        //if (number >= 0.3)
        //{
        //    Debug.Log("大于0.3");
        //    //noteUiState = NoteUIState.SHOW_THREE;
        //}
        //if (number == 0.4)
        //{
        //    Debug.Log("大于0.4");
        //    //noteUiState = NoteUIState.SHOW_FOUR;
        //}
        #endregion

        if (ScrollWheelValue <= 0)
        {
            ScrollWheelValue = 0.1F * sensitivitySet;
        }
        if (ScrollWheelValue >= 0.1 * sensitivitySet)
        {
            if (controlleSshow.isActiveOne)
            {
                ReplaceNoteUI(0);
                notePlane[1].gameObject.SetActive(false);
                controlleSshow.isActiveTwo = true;
            }
        }
        if (ScrollWheelValue >= 0.2 * sensitivitySet)
        {
            controlleSshow.isActiveOne = false;
            if (controlleSshow.isActiveTwo)
            {
                ReplaceNoteUI(1);
                controlleSshow.isActiveThree = true;
                notePlane[2].gameObject.SetActive(false);
            }
            controlleSshow.isActiveOne = true;
        }
        if (ScrollWheelValue >= 0.3 * sensitivitySet)
        {
            controlleSshow.isActiveTwo = false;
            if (controlleSshow.isActiveThree)
            {
                ReplaceNoteUI(2);
                notePlane[3].gameObject.SetActive(false);
                controlleSshow.isActiveFour = true;
            }
            controlleSshow.isActiveTwo = true;
        }
        if (ScrollWheelValue >= 0.4 * sensitivitySet)
        {
            controlleSshow.isActiveThree = false;
            if (controlleSshow.isActiveFour)
            {
                ReplaceNoteUI(3);
            }
            controlleSshow.isActiveThree = true;
            ScrollWheelValue = 0.4F * sensitivitySet;
        }
    }
    //替换UI
    private void ReplaceNoteUI(int index)
    {
        notePlane[index].transform.gameObject.SetActive(true);
    }
}
