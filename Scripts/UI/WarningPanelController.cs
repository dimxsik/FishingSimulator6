using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class WarningPanelController : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    [SerializeField] private GameObject warningPanel;

    public float fadeDuration = 2.0f;
    
    public void StartFadeOutWarning()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        warningPanel.SetActive(true);
        float startAlpha = 1;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, progress);
            progress += rate * Time.deltaTime;

            yield return null;
        }

        canvasGroup.alpha = 0;
        warningPanel.SetActive(false);
    }
}