using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShield : MonoBehaviour
{
    CharacterPower myCharacterPower;
    float shieldPowerDrain;
    Coroutine powerDrainCoroutine;

    Transform shieldComponent;
    void Start()
    {
        shieldPowerDrain = 6f;
        myCharacterPower = GetComponent<CharacterPower>();
        shieldComponent = transform.Find("Shield");

        shieldComponent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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

    private void TurnOnShield()
    {
        shieldComponent.gameObject.SetActive(true);
        powerDrainCoroutine = myCharacterPower.DrainOverASecond(shieldPowerDrain);
    }

    private void TurnOffShield()
    {
        myCharacterPower.StopPowerDrain(powerDrainCoroutine);
        powerDrainCoroutine = null;
        shieldComponent.gameObject.SetActive(false);
    }
}
