﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject currentBullet;
    CharacterPower myCharacterPower;
    
    void Start()
    {
        currentBullet = Resources.Load<GameObject>("Prefabs/Plasma");
        myCharacterPower = GetComponent<CharacterPower>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Shoot(direction);
        }
   
    }

    private void Shoot(Vector2 direction)
    {
        myCharacterPower.DrainInstantly(10f);
        Vector3 currentPositon = gameObject.transform.position;
        Instantiate(currentBullet, currentPositon, Quaternion.identity);
    }
}
