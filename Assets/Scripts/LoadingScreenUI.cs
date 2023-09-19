using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenUI : MonoBehaviour
{
    public Slider loadingBar;

    private void Start()
    {
        loadingBar.value = 0.0f;
    }

    private void Update()
    {
        // Read the loading progress from PlayerPrefs
        float progress = PlayerPrefs.GetFloat("LoadingProgress", 0f);

        if (loadingBar != null)
        {
            loadingBar.value = Mathf.Lerp(loadingBar.value, progress, Time.deltaTime * 5f);
        }
    }
}
