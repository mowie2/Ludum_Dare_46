using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float bulletSpeed;
    private float bulletLifeTime;
    void Start()
    {
        bulletSpeed = 5f;
        bulletLifeTime = 1f;
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * bulletSpeed;
    }
}
