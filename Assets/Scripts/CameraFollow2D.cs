using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    private readonly float followSpeed = 2f;
    [SerializeField] private Transform target;

    private void Update()
    {
        if (target == null) return;

        Vector3 targetPositon = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.Slerp(transform.position, targetPositon, followSpeed * Time.deltaTime);
    }
}