using UnityEngine;

public class MouseTracking : MonoBehaviour
{
    public Transform centerPoint;

    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = centerPoint.position.z;

        Vector2 direction = (mouseWorldPos - centerPoint.position);
        direction.Normalize();
        
        transform.position = centerPoint.position + (Vector3)direction * 0.7f;

        float angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
