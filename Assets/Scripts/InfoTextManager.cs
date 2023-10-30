using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTextManager : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    private void Start()
    {
        // Disable the info text by default
        infoText.gameObject.SetActive(false);
    }

    public void ShowInfo(string text)
    {
        // Set the text and enable the info text
        infoText.text = text;
        infoText.gameObject.SetActive(true);
    }

    public void HideInfo()
    {
        // Disable the info text
        infoText.gameObject.SetActive(false);
    }

    public void ShowInfoTime(string text, float duration)
    {
        // Show the info text and start a coroutine to hide it after the specified duration
        ShowInfo(text);
        StartCoroutine(HideInfoTextAfterDuration(duration));
    }

    private IEnumerator HideInfoTextAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        HideInfo();
    }
}