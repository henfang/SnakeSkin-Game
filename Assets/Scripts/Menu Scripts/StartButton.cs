using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerDownHandler
{
    public Button startButton;


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Start Button Pressed.");
        SceneManager.LoadScene("SampleScene");
    }


}
