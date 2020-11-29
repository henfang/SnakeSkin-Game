using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerDownHandler
{
    public Button startButton;
    public Loading loadCheck;



    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.interactable = false;
        loadCheck = GameObject.FindObjectOfType<Loading>();

    }

    void Update()
    {
        if (loadCheck.ready)
        {
            startButton.interactable = true;
          
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        loadCheck.Continue();
    }


}
