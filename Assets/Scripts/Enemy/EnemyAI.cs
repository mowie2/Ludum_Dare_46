using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private readonly List<string> taunts = new List<string>() { "DIE!", "KILL HIM", "HI" };
    [SerializeField] private float detectingRange;
    [SerializeField] private float fireRate;
    private MoveDirection moveDirection;
    private Dictionary<MoveDirection, float> moveDirectionsInFloat = new Dictionary<MoveDirection, float>();
    [SerializeField] private float moveSpeed;
    private Rigidbody2D myRigidbody2D;
    private GameObject player;
    private Shooting shootingComponent;
    private Coroutine shootingCoroutine;

    private enum MoveDirection
    {
        Left,
        Right
    }

    private bool CanSeePlayer()
    {
        Vector3 currentPositon = transform.position;
        Vector3 direction = player.transform.position - currentPositon;
        direction.Normalize();

        Debug.DrawRay(currentPositon, direction);

        var raycast = Physics2D.RaycastAll(transform.position, direction, detectingRange);
        Debug.Log(raycast.Length);

        foreach (var hit in raycast)
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }

            if (hit.transform.CompareTag("Floor & Wall"))
            {
                return false;
            }
        }

        return true;
    }

    private void DetectPlatformEdge()
    {
        var rightSide = new Vector2(transform.position.x + 1, transform.position.y);
        var rightHit = Physics2D.RaycastAll(rightSide, -Vector2.up, 1f);
        if (rightHit.Length == 0) FlipMoveDirection();

        var leftSide = new Vector2(transform.position.x - 1, transform.position.y);
        var leftHit = Physics2D.RaycastAll(leftSide, -Vector2.up, 1f);
        if (leftHit.Length == 0) FlipMoveDirection();
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FlipMoveDirection();
    }

    private bool PlayerIsInShootingRange()
    {
        var distance = Vector2.Distance(transform.position, player.transform.position);

        return distance < detectingRange;
    }

    private IEnumerator ShootAtPlayer()
    {
        var enemySpeech = GetComponent<EnemySpeech>();
        enemySpeech.Say(taunts[Random.Range(0, taunts.Count)], 1);

        while (true)
        {
            shootingComponent.Shoot(player.transform.position);
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Start()
    {
        shootingComponent = GetComponent<Shooting>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Character");
        moveDirectionsInFloat.Add(MoveDirection.Left, 1);
        moveDirectionsInFloat.Add(MoveDirection.Right, -1);

        int initialMoveDirection = Random.Range(0, 2);
        moveDirection = (MoveDirection)initialMoveDirection;
    }

    private void Update()
    {
        Debug.Log(CanSeePlayer());

        if (PlayerIsInShootingRange() && CanSeePlayer() && shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootAtPlayer());
        }

        if (!CanSeePlayer() && shootingCoroutine != null || !PlayerIsInShootingRange() && shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }

        DetectPlatformEdge();
    }
}