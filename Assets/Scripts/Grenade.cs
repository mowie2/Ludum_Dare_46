using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private void DestroyGrenade()
    {
        var shootPlasma = GetComponent<ShootPlasma>();

        for (float x = -1; x < 1; x += 0.3f)
        {
            for (float y = -1; y < 1; y += 0.3f)
            {
                if (x == 0 && y == 0) continue;
                shootPlasma.Shoot(new Vector2(transform.position.x + x, transform.position.y + y));
            }
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyGrenade", 1f);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}