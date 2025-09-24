using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public string targetSceneName; // Set the name of the target scene in the Inspector

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gate") && !string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
