using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelPasser levelPasser;

    private void Start()
    {
        levelPasser = GameObject.FindObjectOfType<LevelPasser>();
    }
    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void RestartGame()
    {
        levelPasser.resetFloor();
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnToMenu()
    {
        levelPasser.resetFloor();
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

    public void WinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void NextLevel()
    {
        levelPasser.incrementFloor();
        SceneManager.LoadScene("SampleScene");
    }
}
