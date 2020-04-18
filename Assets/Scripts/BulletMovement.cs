using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 direction;
    private float bulletDamage;
    private float bulletLifeTime;
    private float bulletSpeed;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyHealth>().DoDamage(bulletDamage);
        }

        if (col != null)
        {
            var afterDeathGlow = Instantiate(Resources.Load<GameObject>("Prefabs/Plasma Death After Glow"), transform.position, Quaternion.identity);
            afterDeathGlow.GetComponent<Light2D>().color = GetComponent<SpriteRenderer>().color;

            var deathLight = Instantiate(Resources.Load<GameObject>("Prefabs/Plasma Death"), transform.position, Quaternion.identity);
            deathLight.GetComponent<Light2D>().color = GetComponent<SpriteRenderer>().color;

            Destroy(deathLight, 0.05f);
            Destroy(gameObject);
        }
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