using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private readonly List<string> taunts = new List<string>() { "DIE!", "KILL HIM", "Tthere he is!" };
    [SerializeField] private float detectingRange;
    [SerializeField] private float fireRate;

    private GameObject player;
    private ShootPlasma shootingComponent;
    private Coroutine shootingCoroutine;

    private bool CanSeePlayer()
    {
        Vector3 currentPositon = transform.position;
        Vector3 direction = player.transform.position - currentPositon;
        direction.Normalize();

        Debug.DrawRay(currentPositon, direction);

        var raycast = Physics2D.RaycastAll(transform.position, direction, detectingRange);

        foreach (var hit in raycast)
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }

            if (hit.transform.CompareTag("Floor & Wall"))
            {
                return false;
            }
        }

        return true;
    }

    private bool PlayerIsInShootingRange()
    {
        var distance = Vector2.Distance(transform.position, player.transform.position);

        return distance < detectingRange;
    }

    private IEnumerator ShootAtPlayer()
    {
        var enemySpeech = GetComponent<EnemySpeech>();
        enemySpeech.Say(taunts[Random.Range(0, taunts.Count)], 1);

        while (true)
        {
            shootingComponent.Shoot(player.transform.position);
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Start()
    {
        shootingComponent = GetComponent<ShootPlasma>();

        player = GameObject.Find("Character");
    }

    private void Update()
    {
        if (PlayerIsInShootingRange() && CanSeePlayer() && shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootAtPlayer());
        }

        if (!CanSeePlayer() && shootingCoroutine != null || !PlayerIsInShootingRange() && shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }
}