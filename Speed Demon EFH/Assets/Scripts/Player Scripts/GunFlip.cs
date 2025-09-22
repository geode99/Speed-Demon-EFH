using UnityEngine;

public class GunFlip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        // Get the current z rotation in degrees
        float zRotation = transform.eulerAngles.z;

        // Convert Unity's 0-360 range to -180 to 180
        if (zRotation > 180f){
            zRotation -= 360f;
        }
        if (moveX > 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveX < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Flip Y if rotation is more than 90 or less than -90
        if (zRotation > 90f || zRotation < -90f)
        {
            // Flipped
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
        else
        {
            // Normal
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
    }
}
