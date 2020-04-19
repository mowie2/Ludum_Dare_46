using UnityEngine;

public class CharacterTurret : MonoBehaviour
{
    private void RotateTurrentToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 currentPositon = transform.position;
        Vector3 direction = mousePosition - currentPositon;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Update()
    {
        RotateTurrentToMouse();
    }
}