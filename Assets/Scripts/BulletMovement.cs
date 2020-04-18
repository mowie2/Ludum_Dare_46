using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float bulletSpeed;
    private float bulletLifeTime;
    public Vector3 direction;
    void Start()
    {
        bulletSpeed = 3f;
        bulletLifeTime = 5f;
        Destroy(gameObject, bulletLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * bulletSpeed;
    }
}
