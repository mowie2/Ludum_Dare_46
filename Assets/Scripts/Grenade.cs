using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private void DestroyGrenade()
    {
        var shootPlasma = GetComponent<ShootPlasma>();

        shootPlasma.Shoot(new Vector2(transform.position.x, transform.position.y + 1));
        shootPlasma.Shoot(new Vector2(transform.position.x, transform.position.y - 1));
        shootPlasma.Shoot(new Vector2(transform.position.x + 1, transform.position.y));
        shootPlasma.Shoot(new Vector2(transform.position.x - 1, transform.position.y));

        shootPlasma.Shoot(new Vector2(transform.position.x + 1, transform.position.y + 1));
        shootPlasma.Shoot(new Vector2(transform.position.x - 1, transform.position.y + 1));
        shootPlasma.Shoot(new Vector2(transform.position.x + 1, transform.position.y - 1));
        shootPlasma.Shoot(new Vector2(transform.position.x - 1, transform.position.y - 1));

        shootPlasma.Shoot(new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f));
        shootPlasma.Shoot(new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f));
        shootPlasma.Shoot(new Vector2(transform.position.x - 0.5f, transform.position.y + 0.5f));
        shootPlasma.Shoot(new Vector2(transform.position.x - 0.5f, transform.position.y + 0.5f));

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyGrenade", 3f);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}