using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] string sceneName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneName);
    }
}
