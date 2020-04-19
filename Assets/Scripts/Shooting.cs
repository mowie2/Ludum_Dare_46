using UnityEngine;

public class Shooting : MonoBehaviour
{
    private readonly float shootingPowerCost = 2;

    [SerializeField] private Color bulletColour;
    [SerializeField] private Transform bulletOrigin;
    private GameObject bulletPrefab;

    public void Shoot(Vector2 targetPosition)
    {
        Vector2 currentPositon = gameObject.transform.position;
        Vector2 direction = targetPosition - currentPositon;
        direction.Normalize();

        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, Quaternion.identity);
        bullet.GetComponent<SpriteRenderer>().color = bulletColour;
        bullet.GetComponent<BulletMovement>().direction = direction;
        bullet.GetComponent<BulletCollision>().GameObjectTagBulletCameFrom = gameObject.tag;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Plasma");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.CompareTag("Player"))
        {
            GetComponent<CharacterPower>().DrainInstantly(shootingPowerCost);
            Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}