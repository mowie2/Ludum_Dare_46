using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShield : MonoBehaviour
{
    private CharacterPower myCharacterPower;
    private Coroutine powerDrainCoroutine;
    private float shieldPowerDrain;
    private Transform shieldTransform;

    private void Start()
    {
        shieldPowerDrain = 1f;
        myCharacterPower = GetComponent<CharacterPower>();
        shieldTransform = transform.Find("Shield");

        shieldTransform.gameObject.SetActive(false);
    }

    private void TurnOffShield()
    {
        GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/ShieldPowerDown");
        GetComponent<AudioSource>().Play();
        myCharacterPower.StopPowerDrain(powerDrainCoroutine);
        powerDrainCoroutine = null;
        shieldTransform.gameObject.SetActive(false);
    }

    private void TurnOnShield()
    {
        shieldTransform.gameObject.SetActive(true);
        powerDrainCoroutine = myCharacterPower.DrainOverASecond(shieldPowerDrain);
        GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/ShieldPowerUp");
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(1) && powerDrainCoroutine == null)
        {
            TurnOnShield();
        }

        if (Input.GetMouseButtonUp(1))
        {
            TurnOffShield();
        }
    }
}