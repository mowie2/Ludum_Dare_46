using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject currentBullet;

    private CharacterPower myCharacterPower;
    private Transform turretTransform;

    private void RotateTurrentToMouse(Vector3 mousePosition)
    {
        Vector3 currentPositon = gameObject.transform.position;
        Vector3 direction = mousePosition - currentPositon;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        turretTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Shoot(Vector3 mousePosition)
    {
        myCharacterPower.DrainInstantly(10f);

        Vector3 currentPositon = gameObject.transform.position;
        Vector3 direction = mousePosition - currentPositon;
        direction.Normalize();

        GameObject bullet = Instantiate(currentBullet, turretTransform.position, Quaternion.identity);
        bullet.GetComponent<BulletMovement>().direction = direction;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Start()
    {
        currentBullet = Resources.Load<GameObject>("Prefabs/Plasma");
        myCharacterPower = GetComponent<CharacterPower>();
        turretTransform = transform.Find("Turret");
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RotateTurrentToMouse(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot(mousePosition);
        }
    }
}