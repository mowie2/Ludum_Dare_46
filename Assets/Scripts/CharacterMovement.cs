﻿using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private readonly float jumpForce = 250f;
    private readonly float movementPowerCost = 1;
    private readonly int moveSpeed = 3;

    private CharacterPower characterPower;
    private bool jumping;
    private Coroutine movementDrainCoruntine;
    private Collider2D myCollider2D;
    private Rigidbody2D myRigidbody2D;

    private void DrainPowerFromMoving()
    {
        if (Input.GetAxis("Horizontal") != 0 && movementDrainCoruntine == null) movementDrainCoruntine = characterPower.DrainOverASecond(movementPowerCost);
        else if (Input.GetAxis("Horizontal") == 0 && movementDrainCoruntine != null)
        {
            characterPower.StopPowerDrain(movementDrainCoruntine);
            movementDrainCoruntine = null;
        }
    }

    private void FixedUpdate()
    {
        DrainPowerFromMoving();

        myRigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, myRigidbody2D.velocity.y);

        if (jumping)
        {
            characterPower.DrainInstantly(5);
            myRigidbody2D.AddForce(new Vector2(0, jumpForce));
            Vector3 v = myRigidbody2D.velocity;
            v.y = Mathf.Clamp(v.y, 0, 10);
            myRigidbody2D.velocity = v;
            jumping = false;
        }
    }

    private bool IsGrounded()
    {
        var hit = Physics2D.RaycastAll(transform.position, -Vector2.up, 1f);

        foreach (var raycastHit in hit)
        {
            if (raycastHit.collider == myCollider2D) continue;

            return true;
        }

        return false;
    }

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        characterPower = GetComponent<CharacterPower>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) jumping = true;
    }
}