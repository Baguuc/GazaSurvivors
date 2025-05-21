using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Open()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void TryToggle()
    {
        if (pauseMenu.active)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) this.Close();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape)) this.Open();
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        TryToggle();
    }
}
