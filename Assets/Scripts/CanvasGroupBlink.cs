using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupBlink : MonoBehaviour
{
    [SerializeField] private float blinkSpeed = 1f;
    [SerializeField] private float minimumAlpha = 0f;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        canvasGroup.alpha = Mathf.PingPong(Time.time * blinkSpeed, 1f) + minimumAlpha;
    }
}
