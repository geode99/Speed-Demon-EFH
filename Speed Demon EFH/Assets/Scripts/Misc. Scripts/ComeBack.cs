using UnityEngine;
using UnityEngine.SceneManagement;

public class ComeBack : MonoBehaviour
{
    public string targetSceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
