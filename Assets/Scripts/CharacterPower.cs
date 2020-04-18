using System.Collections;
using UnityEngine;

public class CharacterPower : MonoBehaviour
{
    private readonly float maxPowerLevel = 100;

    [SerializeField] private float currentPowerLevel;

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
            currentPowerLevel += 10;
            Destroy(collision.gameObject);
        }
    }

    private void Start()
    {
        currentPowerLevel = maxPowerLevel;
        DrainOverASecond(0.5f);
    }
}