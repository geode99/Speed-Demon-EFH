using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    public int frameCount = 0;

    void Update()
    {
        frameCount++;
        if (frameCount >= 960)
        {
            Destroy(gameObject);
        }
    }
}
