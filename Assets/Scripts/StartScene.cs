using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
//if any key is pressed load new scene
    void Update()
    {
        if (Input.anyKey)
        {
            LevelManager.Instance.LoadSceneNoLoadScreen("MainMenuScene");
        }
    }
}
