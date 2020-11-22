using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuitButton : MonoBehaviour, IPointerDownHandler
{
    public Button quitButton; 

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Quit Button Pressed.");
        Application.Quit();
    }

}
