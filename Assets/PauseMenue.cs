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
            pause = !pause;
            TogglePause();
        }
    }
    public void TogglePause()
    {
        pause = !pause;
        if (pause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale =1 ;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
