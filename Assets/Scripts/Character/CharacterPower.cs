using System.Collections;
using TMPro;
using UnityEngine;

public class CharacterPower : MonoBehaviour
{
    private readonly float maxPowerLevel = 100;

    private float currentPowerLevel;
    private TextMeshProUGUI textMeshProUGUI;

    public void DrainInstantly(float amount)
    {
        currentPowerLevel -= amount;
    }

    public Coroutine DrainOverASecond(float drainAmountASecond)
    {
        return StartCoroutine(DrainPower(drainAmountASecond));
    }

    public void StopPowerDrain(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }

    private void AddPower(float amount)
    {
        currentPowerLevel += amount;
        StartCoroutine(PowerIncreasePopupText(amount));
    }

    private IEnumerator DrainPower(float drainAmount)
    {
        while (true)
        {
            currentPowerLevel -= drainAmount;
            yield return new WaitForSeconds(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Battery"))
        {
            AddPower(10);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator PowerIncreasePopupText(float amount)
    {
        var textComponent = transform.Find("Canvas").Find("Power Increase Text").GetComponent<TextMeshProUGUI>();

        textComponent.color = Color.white;
        textComponent.text = string.Format("+{0} power", amount);
        yield return new WaitForSeconds(1);
        textComponent.color = Color.clear;
    }

    private void Start()
    {
        textMeshProUGUI = GameObject.Find("Power UI").GetComponent<TextMeshProUGUI>();
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
        textMeshProUGUI.text = string.Format("Power: {0}%", (currentPowerLevel / maxPowerLevel) * 100);
    }
}