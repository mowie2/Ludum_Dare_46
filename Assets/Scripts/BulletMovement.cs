using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BulletMovement : MonoBehaviour
{
    public Vector3 direction;
    public GameObject gameObjectBulletCameFrom;
    private float bulletDamage;
    private float bulletLifeTime;
    private float bulletSpeed;

    private void DestroyBullet()
    {
        var afterDeathGlow = Instantiate(Resources.Load<GameObject>("Prefabs/Plasma Death After Glow"), transform.position, Quaternion.identity);
        afterDeathGlow.GetComponent<Light2D>().color = GetComponent<SpriteRenderer>().color;

        var deathLight = Instantiate(Resources.Load<GameObject>("Prefabs/Plasma Death"), transform.position, Quaternion.identity);
        deathLight.GetComponent<Light2D>().color = GetComponent<SpriteRenderer>().color;

        Destroy(deathLight, 0.05f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == gameObjectBulletCameFrom) return;

        if (collision.gameObject.CompareTag("Enemy")) collision.gameObject.GetComponent<EnemyHealth>().DoDamage(bulletDamage);

        if (collision != null) DestroyBullet();
    }

    private void SetGlowColor()
    {
        GetComponent<Light2D>().color = GetComponent<SpriteRenderer>().color;
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

        SetGlowColor();
    }
}