using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float detectingRange;
    [SerializeField] private float fireRate;
    private GameObject player;
    private Shooting shootingComponent;
    private Coroutine shootingCoroutine;

    private bool PlayerIsInShootingRange()
    {
        var distance = Vector2.Distance(transform.position, player.transform.position);

        return distance < detectingRange;
    }

    private IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            shootingComponent.Shoot(player.transform.position);
            yield return new WaitForSeconds(fireRate);
        }
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
        if (PlayerIsInShootingRange() && shootingCoroutine == null) shootingCoroutine = StartCoroutine(ShootAtPlayer());

        if (!PlayerIsInShootingRange() && shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }
}