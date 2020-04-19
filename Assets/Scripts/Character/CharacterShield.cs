using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShield : MonoBehaviour
{
    CharacterPower myCharacterPower;
    float shieldPowerDrain;
    Coroutine powerDrainCoroutine;
    void Start()
    {
        shieldPowerDrain = 6f;
        myCharacterPower = GetComponent<CharacterPower>();
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
            myCharacterPower.StopPowerDrain(powerDrainCoroutine);
            powerDrainCoroutine = null;
        }
    }

    private void TurnOnShield()
    {
        powerDrainCoroutine = myCharacterPower.DrainOverASecond(shieldPowerDrain);
    }
}
