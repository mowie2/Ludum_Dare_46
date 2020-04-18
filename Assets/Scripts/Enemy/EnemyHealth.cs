using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    private readonly float maxHealth = 100;

    private float currentHealth;
    private Slider healthBar;
    void Start()
    {
        currentHealth = maxHealth;

        healthBar = transform.Find("Canvas").Find("Healthbar").GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        healthBar.GetComponent<CanvasGroup>().alpha = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoDamage(float damageAmount)
    {
        healthBar.GetComponent<CanvasGroup>().alpha = 1;
        currentHealth -= damageAmount;

        if (currentHealth <= 0) Death();

        healthBar.value = currentHealth;
    }
    public void Death()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/battery"), gameObject.transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}
