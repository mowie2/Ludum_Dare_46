using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    private readonly float maxHealth = 100;

    private float currentHealth;

    private Slider healthBar;

    private Image healthBarImage;

    private Color healthBarNormalColor;

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DoDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) Death();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        StartCoroutine(HealthIncreasePopupText(healAmount));

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void FallingCheck()
    {
        if (transform.position.y <= -5) Death();
    }

    private IEnumerator HealthIncreasePopupText(float amount)
    {
        var textComponent = transform.Find("Text Canvas").Find("Stat Increase Text").GetComponent<TextMeshProUGUI>();

        textComponent.color = Color.white;
        textComponent.text = string.Format("+{0} health", amount);
        yield return new WaitForSeconds(1);
        textComponent.color = Color.clear;
    }

    private void Start()
    {
        var healthUIGameObject = GameObject.Find("Health UI");
        if (healthUIGameObject != null)
        {
            healthBar = healthUIGameObject.transform.Find("Slider").GetComponent<Slider>();
            healthBar.maxValue = maxHealth;
            healthBarImage = healthBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
            healthBarNormalColor = healthBarImage.color;
        }

        currentHealth = maxHealth;
    }

    private void Update()
    {
        UpdateUI();
        FallingCheck();
    }

    private void UpdateUI()
    {
        healthBar.value = currentHealth;

        if (currentHealth <= 20) healthBarImage.color = Color.red;
        else healthBarImage.color = healthBarNormalColor;
    }
}