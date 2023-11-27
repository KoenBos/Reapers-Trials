using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenue : MonoBehaviour
{
    private bool pause = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            TogglePause();
        }
    }
    public void TogglePause()
    {
        pause = !pause;
        if (pause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale =0;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        LevelManager.Instance.LoadScene("MainMenuScene");
    }
}
