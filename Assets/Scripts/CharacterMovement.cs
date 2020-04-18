using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 250f;
    private bool jumping;
    [SerializeField] private int moveSpeed = 3;
    private Collider2D myCollider2D;
    private Rigidbody2D myRigidbody2D;

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, myRigidbody2D.velocity.y);

        if (jumping)
        {
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumping = true;
        }
    }
}