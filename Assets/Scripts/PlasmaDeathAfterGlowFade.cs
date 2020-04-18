using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlasmaDeathAfterGlowFade : MonoBehaviour
{
    private readonly float intesintyDecreaseAmount = 0.01f;
    private Light2D light2D;

    private IEnumerator Fade()
    {
        while (true)
        {
            light2D.intensity -= intesintyDecreaseAmount;

            yield return new WaitForSeconds(0.1f);

            if (light2D.intensity <= 0) Destroy(gameObject);
        }
    }

    private void Start()
    {
        light2D = GetComponent<Light2D>();
        StartCoroutine(Fade());
    }
}