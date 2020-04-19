using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShield : MonoBehaviour
{
    private CharacterPower myCharacterPower;
    private Coroutine powerDrainCoroutine;
    private Transform shieldComponent;
    private float shieldPowerDrain;

    private void Start()
    {
        shieldPowerDrain = 1f;
        myCharacterPower = GetComponent<CharacterPower>();
        shieldComponent = transform.Find("Shield");

        shieldComponent.gameObject.SetActive(false);
    }

    private void TurnOffShield()
    {
        myCharacterPower.StopPowerDrain(powerDrainCoroutine);
        powerDrainCoroutine = null;
        shieldComponent.gameObject.SetActive(false);
    }

    private void TurnOnShield()
    {
        shieldComponent.gameObject.SetActive(true);
        powerDrainCoroutine = myCharacterPower.DrainOverASecond(shieldPowerDrain);
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