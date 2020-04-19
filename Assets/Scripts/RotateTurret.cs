using UnityEngine;

public class RotateTurret : MonoBehaviour
{
    private Transform character;

    private void RotateTurrentToMouse(Vector3 targetPosition)
    {
        Vector3 currentPositon = transform.position;
        Vector3 direction = targetPosition - currentPositon;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Start()
    {
        character = GameObject.Find("Character").transform;
    }

    private void Update()
    {
        if (transform.CompareTag("Player")) RotateTurrentToMouse(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (transform.CompareTag("Enemy")) RotateTurrentToMouse(character.transform.position);
    }
}