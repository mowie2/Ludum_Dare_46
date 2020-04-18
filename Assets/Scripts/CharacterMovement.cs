using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;
    private bool jumping;
    [SerializeField] private int maxSpeed = 5;
    [SerializeField] private int movementForce = 5;
    private Collider2D myCollider2D;
    private Rigidbody2D myRigidbody2D;

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = 0f;

        if (jumping)
        {
            vertical = jumpForce;
            jumping = false;
        }

        var movement = new Vector2(horizontal, vertical);
        myRigidbody2D.AddForce(movement * movementForce);

        if (myRigidbody2D.velocity.magnitude > maxSpeed)
        {
            myRigidbody2D.velocity = myRigidbody2D.velocity.normalized * maxSpeed;
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumping = true;
        }
    }
}