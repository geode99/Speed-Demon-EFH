using UnityEngine;

public class Restart : MonoBehaviour
{
    public Transform targetRoom; // Assign the target room Transform in the Inspector

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && targetRoom != null)
        {
            // Move this object to the target room's position
            transform.position = targetRoom.position;
        }
    }
}
