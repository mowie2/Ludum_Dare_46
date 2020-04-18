using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCollision : MonoBehaviour
{
    private const int damageOnEnemyCollision = 5;
    private const int pushbackOnEnemyCollision = 1500;
    private Vector2 lastKnownDirection;
    private CharacterHealth myCharacterHealth;
    private Rigidbody2D myRigidbody2D;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            myRigidbody2D.AddForce(new Vector2(pushbackOnEnemyCollision, 0) * -lastKnownDirection);
            myCharacterHealth.DoDamage(damageOnEnemyCollision);
        }

        if (col.gameObject.CompareTag("Battery"))
        {
            GetComponent<CharacterPower>().AddPower(10);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Health Pack"))
        {
            GetComponent<CharacterHealth>().Heal(10);
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

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
}