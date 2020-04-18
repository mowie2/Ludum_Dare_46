using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private readonly float maxHealth = 100;

    private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) Death();
    }
    public void Death()
    {

        Instantiate(Resources.Load<GameObject>("Prefabs/battery"), gameObject.transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}
