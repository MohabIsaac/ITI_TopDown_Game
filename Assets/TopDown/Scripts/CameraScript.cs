using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);

    [Range(0f, 1f)]
    public float smoothness = 0.1f; 

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothness
        );
    }
}
