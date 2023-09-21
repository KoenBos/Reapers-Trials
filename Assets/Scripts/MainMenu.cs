using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private GameObject QuitPanel;


    public void LoadScene(string sceneName)
    {
        LevelManager.Instance.LoadScene(sceneName);
    }
    public void LoadSceneNoLoadScreen(string sceneName)
    {
        LevelManager.Instance.LoadSceneNoLoadScreen(sceneName);
    }
    public void QuitGame() 
    {
    Debug.Log("Quit");
    Application.Quit();
    }

}
