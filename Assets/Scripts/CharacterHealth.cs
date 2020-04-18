using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    private readonly float maxHealth = 100;

    private float currentHealth;
    private TextMeshProUGUI textMeshProUGUI;

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FallingCheck()
    {
        if (transform.position.y <= -5) Death();
    }

    private void Start()
    {
        textMeshProUGUI = GameObject.Find("Health UI").GetComponent<TextMeshProUGUI>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        UpdateUI();
        FallingCheck();
        if (currentHealth <= 0) Death();
    }

    private void UpdateUI()
    {
        textMeshProUGUI.text = string.Format("Health: {0}", currentHealth);
    }

    public void DoDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }
}