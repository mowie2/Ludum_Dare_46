﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private readonly float maxHealth = 100;

    private float currentHealth;
    private bool dead;
    private Slider healthBar;
    private readonly List<string> deathText = new List<string>() { "Arghhhh!", "Clear my browser history", "Uhhhggg", "AAAAAAaaaaaa,,,," };

    public void Death()
    {
        Scoreboard.scoreboard_instance.IncreaseKills();
        AfterDeathText();
        LootDrop();

        Destroy(gameObject);
    }

    public void DoDamage(float damageAmount)
    {
        healthBar.GetComponent<CanvasGroup>().alpha = 1;
        currentHealth -= damageAmount;

        if (currentHealth <= 0) dead = true;

        healthBar.value = currentHealth;
    }

    private void AfterDeathText()
    {
        var textCanvas = transform.Find("Text Canvas");
        float timeToShowText = 1;

        GetComponent<EnemySpeech>().Say(deathText[Random.Range(0,deathText.Count)], timeToShowText);

        textCanvas.GetComponent<AudioSource>().Play();
        Vector3 temp = textCanvas.position;
        textCanvas.SetParent(null);
        textCanvas.position = temp;
        Destroy(textCanvas.gameObject, timeToShowText);
    }

    private void LootDrop()
    {
        var x = Random.Range(0, 10);

        if (x >= 0 && x <= 3)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/Battery"), gameObject.transform.position, Quaternion.identity);
        }
        if (x >= 4 && x <= 6)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/Health Pack"), gameObject.transform.position, Quaternion.identity);
        }
        if (x == 9)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/Health Pack"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("Prefabs/Battery"), gameObject.transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;

        healthBar = transform.Find("Health Canvas").Find("Healthbar").GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        healthBar.GetComponent<CanvasGroup>().alpha = 0;
    }

    private void Update()
    {
        if (dead) Death();
    }
}