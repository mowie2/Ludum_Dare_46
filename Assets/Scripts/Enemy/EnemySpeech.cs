using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpeech : MonoBehaviour
{
    public void Say(string textToSay, float secondsToShow)
    {
        StartCoroutine(ShowText(textToSay, secondsToShow));
    }

    private IEnumerator ShowText(string text, float secondsToShow)
    {
        var textComponent = transform.Find("Text Canvas").Find("Text").GetComponent<TextMeshProUGUI>();

        textComponent.color = Color.white;
        textComponent.text = text;
        yield return new WaitForSeconds(secondsToShow);
        textComponent.color = Color.clear;
    }

    private void Start()
    {
        Say("Death to the infidel!", 3);
    }
}