using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public string targetSceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
