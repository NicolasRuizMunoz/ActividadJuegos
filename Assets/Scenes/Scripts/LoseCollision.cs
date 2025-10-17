using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class LoseCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Lose: Player hit by enemy or arrow");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
