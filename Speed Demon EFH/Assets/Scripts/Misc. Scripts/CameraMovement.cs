using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float cameraSmoothing = 2f;

    void Update()
    {
        Vector3 targetPosition = player.transform.position;
        targetPosition.z = transform.position.z; // Keep camera's z position

        // Smoothly move camera towards player
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSmoothing * Time.deltaTime);
    }
}
