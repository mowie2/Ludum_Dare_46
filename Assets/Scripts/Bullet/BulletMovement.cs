using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BulletMovement : MonoBehaviour
{
    public Vector3 direction;

    private readonly float bulletLifeTime = 30;
    private readonly float bulletSpeed = 5;

    private void SetGlowColor()
    {
        GetComponent<Light2D>().color = GetComponent<SpriteRenderer>().color;
    }

    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    private void Update()
    {
        transform.position += direction * Time.deltaTime * bulletSpeed;

        SetGlowColor();
    }
}