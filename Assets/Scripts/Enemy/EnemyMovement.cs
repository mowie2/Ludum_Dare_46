using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform healthCanvas;
    private MoveDirection moveDirection;
    private Dictionary<MoveDirection, float> moveDirectionsInFloat = new Dictionary<MoveDirection, float>();
    [SerializeField] private float moveSpeed;
    private Rigidbody2D myRigidbody2D;

    private Transform textCanvas;

    private enum MoveDirection
    {
        Left,
        Right
    }

    private void DetectPlatformEdge()
    {

        // detect edge left
        var leftSide = new Vector2(transform.position.x - 1, transform.position.y);
        var lefthit = Physics2D.Raycast(leftSide, new Vector2(-1, -1), 1.5f);
        if (!lefthit && moveDirection != MoveDirection.Left) FlipMoveDirection();
        
        // detect edge right
        var rightSide = new Vector2(transform.position.x + 1, transform.position.y);
        var righthit = Physics2D.Raycast(rightSide, new Vector2(1, -1), 1.5f);
        if (!righthit && moveDirection != MoveDirection.Right) FlipMoveDirection();
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = new Vector2(moveDirectionsInFloat[moveDirection] * moveSpeed, myRigidbody2D.velocity.y);
    }

    private void FlipMoveDirection()
    {
        if (moveDirection == MoveDirection.Left)
        {
            moveDirection = MoveDirection.Right;
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveDirection == MoveDirection.Right)
        {
            moveDirection = MoveDirection.Left;
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }

        healthCanvas.eulerAngles = Vector3.zero;
        textCanvas.eulerAngles = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FlipMoveDirection();
    }

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        moveDirectionsInFloat.Add(MoveDirection.Left, 1);
        moveDirectionsInFloat.Add(MoveDirection.Right, -1);

        int initialMoveDirection = Random.Range(0, 2);
        moveDirection = (MoveDirection)initialMoveDirection;

        textCanvas = transform.Find("Text Canvas");
        healthCanvas = transform.Find("Health Canvas");
    }

    private void Update()
    {
        DetectPlatformEdge();
    }
}