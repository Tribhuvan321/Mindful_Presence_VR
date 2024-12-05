using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MeditationTextController : MonoBehaviour
{
    public TMP_Text meditationText;
    public string[] messages = { "Focus on your breath", "Let go of tension", "Feel the calm within you" };
    public float fadeDuration = 2f;
    public float displayDuration = 4f;

    private int currentMessageIndex = 0;

    void Start()
    {
        StartCoroutine(DisplayMessages());
    }

    IEnumerator DisplayMessages()
    {
        while (true)
        {
            meditationText.text = messages[currentMessageIndex];
            yield return StartCoroutine(FadeInText());
            yield return new WaitForSeconds(displayDuration);
            yield return StartCoroutine(FadeOutText());

            currentMessageIndex = (currentMessageIndex + 1) % messages.Length; // Cycle through messages
        }
    }

    IEnumerator FadeInText()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            meditationText.color = new Color(meditationText.color.r, meditationText.color.g, meditationText.color.b, elapsedTime / fadeDuration);
            yield return null;
        }
    }

    IEnumerator FadeOutText()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            meditationText.color = new Color(meditationText.color.r, meditationText.color.g, meditationText.color.b, 1f - (elapsedTime / fadeDuration));
            yield return null;
        }
    }
}
