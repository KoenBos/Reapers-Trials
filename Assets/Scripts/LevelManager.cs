using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private string loadingSceneName = "LoadingScene";

    private AsyncOperation loadingOperation;
    private bool isSceneLoading = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        if (!isSceneLoading)
        {
            isSceneLoading = true;
            PlayerPrefs.SetFloat("LoadingProgress", 0f);
            PlayerPrefs.Save();

            // Load the loading scene first
            SceneManager.LoadScene(loadingSceneName);
            StartCoroutine(LoadSceneWithLoadingScreen(sceneName));
        }
    }

    private IEnumerator LoadSceneWithLoadingScreen(string sceneName)
    {
        yield return null; // Wait for one frame so that the loading scene is loaded

        loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingOperation.allowSceneActivation = false;

        while (!loadingOperation.isDone)
        {
            float progress = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            PlayerPrefs.SetFloat("LoadingProgress", progress); // Update progress
            PlayerPrefs.Save(); // Save progress

            if (progress >= 0.9f)
            {
                //1 second delay
                yield return new WaitForSeconds(1f);

                loadingOperation.allowSceneActivation = true; // Activate the scene
            }

            yield return null;
        }

        isSceneLoading = false;
    }
    //load scene without loading screen
    public void LoadSceneNoLoadScreen(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
