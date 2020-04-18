using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 direction;
    private float bulletDamage;
    private float bulletLifeTime;
    private float bulletSpeed;

    // Update is called once per frame
    private void Update()
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

        if (col != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        bulletSpeed = 10f;
        bulletLifeTime = 5f;
        bulletDamage = 20;

        Destroy(gameObject, bulletLifeTime);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += direction * Time.deltaTime * bulletSpeed;
    }
}