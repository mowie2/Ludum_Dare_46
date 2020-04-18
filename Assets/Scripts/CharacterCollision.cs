using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private CharacterHealth myCharacterHealth;

    private const int damageOnEnemyCollision = 5;
    private const int pushbackOnEnemyCollision = 1500;
    private Vector2 lastKnownDirection;

    // Start is called before the first frame update
    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCharacterHealth = GetComponent<CharacterHealth>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            lastKnownDirection = new Vector2(1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            lastKnownDirection = new Vector2(-1, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            myRigidbody2D.AddForce(new Vector2(pushbackOnEnemyCollision, 0) * -lastKnownDirection);
            myCharacterHealth.DoDamage(damageOnEnemyCollision);
        }
    }
}