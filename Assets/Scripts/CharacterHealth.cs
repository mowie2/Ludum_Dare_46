using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    private readonly float maxHealth = 100;
    private float currentHealth;

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FallingCheck()
    {
        if (transform.position.y <= -5) Death();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        FallingCheck();
        if (currentHealth <= 0) Death();
    }
}