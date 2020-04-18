using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float bulletSpeed;
    private float bulletLifeTime;

    private float bulletDamage;

    public Vector3 direction;
    void Start()
    {
        bulletSpeed = 3f;
        bulletLifeTime = 5f;
        bulletDamage = 20;

        Destroy(gameObject, bulletLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit enemy");
            col.gameObject.GetComponent<EnemyHealth>().DoDamage(bulletDamage);
        }

        if(col != null)
        {
            Destroy(gameObject);
        }
    }
}
