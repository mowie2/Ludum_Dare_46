using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BulletCollision : MonoBehaviour
{
    public GameObject GameObjectBulletCameFrom;

    private readonly float bulletDamage = 20;

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
        if (collision.gameObject == GameObjectBulletCameFrom) return;

        if (collision.gameObject.CompareTag("Enemy")) collision.gameObject.GetComponent<EnemyHealth>().DoDamage(bulletDamage);

        if (collision != null) DestroyBullet();
    }
}