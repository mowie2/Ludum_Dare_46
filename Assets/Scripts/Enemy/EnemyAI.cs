using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    private Shooting shootingComponent;

    private void ShootAtPlayer()
    {
        shootingComponent.Shoot(player.transform.position);
    }

    // Start is called before the first frame update
    private void Start()
    {
        shootingComponent = GetComponent<Shooting>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        ShootAtPlayer();
    }
}