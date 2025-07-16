using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public Vector2 minPos  = new Vector2(-13f, -3f); // нижний левый угол карты
    public Vector2 maxPos  = new Vector2(14f, 4f); // верхний правый угол карты

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Ограничение по границам
        float clampedX = Mathf.Clamp(smoothed.x, minPos.x, maxPos.x);
        float clampedY = Mathf.Clamp(smoothed.y, minPos.y, maxPos.y);

        transform.position = new Vector3(clampedX, clampedY, smoothed.z);
    }
}
