using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class ExitGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Win: Player reached the exit!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
