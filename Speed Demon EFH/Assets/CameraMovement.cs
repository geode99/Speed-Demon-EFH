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
        cameraOffset = player.transform.position - transform.position;
        cameraOffset.z = 0;

        transform.Translate(cameraOffset/cameraSmoothing);
        //transform.position = transform.position + cameraOffset/cameraSmoothing;

        print(transform.position);
        print(player.transform.position);
    }
}
