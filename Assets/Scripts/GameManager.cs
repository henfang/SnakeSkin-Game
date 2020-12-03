using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelPasser levelPasser;
    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void RestartGame()
    {
        levelPasser = GameObject.FindObjectOfType<LevelPasser>();
        levelPasser.resetFloor();
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnToMenu()
    {
        levelPasser = GameObject.FindObjectOfType<LevelPasser>();
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
        levelPasser = GameObject.FindObjectOfType<LevelPasser>();
        levelPasser.incrementFloor();
        SceneManager.LoadScene("SampleScene");
    }
}
