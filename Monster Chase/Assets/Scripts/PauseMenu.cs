using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject restartButton;
    public GameObject pauseButton;
    public GameObject homeButton;


    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        restartButton.SetActive(false);
        homeButton.SetActive(false);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        restartButton.SetActive(true);
        homeButton.SetActive(true);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void TakeToMainMenu()
    {
  //      pauseMenuUI.SetActive(false);
  //      restartButton.SetActive(true);
  //      homeButton.SetActive(true);
  //      pauseButton.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
