﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrenade : MonoBehaviour
{
    private readonly float powerCost = 0;
    private readonly float throwStrength = 10;

    private void ThrowGrenade()
    {
        GetComponent<CharacterPower>().DrainInstantly(powerCost);
        var grenade = Instantiate(Resources.Load<GameObject>("Prefabs/Grenade"), transform.position, Quaternion.identity);

        Vector2 currentPositon = transform.position;
        Vector3 direction = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - currentPositon;
        direction.Normalize();

        grenade.GetComponent<Rigidbody2D>().velocity = direction * throwStrength;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ThrowGrenade();
        }
    }
}