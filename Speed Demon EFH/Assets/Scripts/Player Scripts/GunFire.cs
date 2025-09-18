using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform firePoint;         
    public float projectileSpeed = 30f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * projectileSpeed;
        }
    }
}
