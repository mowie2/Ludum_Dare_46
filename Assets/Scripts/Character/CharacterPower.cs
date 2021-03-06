﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPower : MonoBehaviour
{
    private readonly float maxPowerLevel = 100;

    private float currentPowerLevel;
    private Image healthAmountLeftImage;

    private Slider powerBar;
    private Image powerBarImage;
    private Color powerBarNormalColor;
    [SerializeField] private bool noEnergyCost;
    public void AddPower(float amount)
    {
        currentPowerLevel += amount;
        if (currentPowerLevel > maxPowerLevel)
        {
            currentPowerLevel = maxPowerLevel;
        }
        StartCoroutine(PowerIncreasePopupText(amount));
    }

    public void DrainInstantly(float amount)
    {
        if (noEnergyCost) return;
        currentPowerLevel -= amount;
        Scoreboard.scoreboard_instance.IncreasePowerConsume(amount);
    }

    public Coroutine DrainOverASecond(float drainAmountASecond)
    {
        if (noEnergyCost) drainAmountASecond = 0;
        return StartCoroutine(DrainPower(drainAmountASecond));
    }

    public void StopPowerDrain(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator DrainPower(float drainAmount)
    {
        while (true)
        {
            Scoreboard.scoreboard_instance.IncreasePowerConsume(drainAmount);
            currentPowerLevel -= drainAmount;
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator PowerIncreasePopupText(float amount)
    {
        var textComponent = transform.Find("Text Canvas").Find("Stat Increase Text").GetComponent<TextMeshProUGUI>();

        textComponent.color = Color.white;
        textComponent.text = string.Format("+{0} power", amount);
        yield return new WaitForSeconds(1);
        textComponent.color = Color.clear;
    }

    private void Start()
    {
        healthAmountLeftImage = GameObject.Find("Power Amount Left").GetComponent<Image>();

        currentPowerLevel = maxPowerLevel;

        DrainOverASecond(1);
    }

    private void Update()
    {
        if (currentPowerLevel <= 0) GetComponent<CharacterHealth>().Death();

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (healthAmountLeftImage == null) return;
        healthAmountLeftImage.fillAmount = currentPowerLevel / 100;
    }
}