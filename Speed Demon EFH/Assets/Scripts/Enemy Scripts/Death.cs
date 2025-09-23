using UnityEngine;

public class Death : MonoBehaviour
{
    public int bulletHitCount = 0;
    public int maxHits = 10;

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletHitCount++;
            if (bulletHitCount >= maxHits)
            {
                Destroy(gameObject);
            }
        }
    }
}
