using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // initialize variables
    public GameObject player;
    private Vector3 cameraOffset;

    private float cameraSmoothing = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // vector from camera that points to player's position
        cameraOffset = player.transform.position - transform.position;
        cameraOffset.z = 0;

        // move camera
        transform.Translate(cameraOffset/cameraSmoothing);
    }
}
