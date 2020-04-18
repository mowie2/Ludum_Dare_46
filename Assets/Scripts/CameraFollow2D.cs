using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    private readonly float followSpeed = 2f;
    private Transform target;

    private void Start()
    {
        target = GameObject.Find("Character").transform;
    }

    private void Update()
    {
        Vector3 targetPositon = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.Slerp(transform.position, targetPositon, followSpeed * Time.deltaTime);
    }
}