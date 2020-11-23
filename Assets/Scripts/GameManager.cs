using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void RestartGame()
    {
        Destroy(GameObject.Find("DontDestroyOnLoad"));
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
