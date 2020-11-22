using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreditButton : MonoBehaviour, IPointerDownHandler
{
    public Button creditButton;


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Credit Button Pressed.");
        SceneManager.LoadScene("Credits");

    }


}
