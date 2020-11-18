using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour, IPointerDownHandler
{
    public Button menuButton;


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Menu Button Pressed.");
        SceneManager.LoadScene("MainMenu");
    }


}
