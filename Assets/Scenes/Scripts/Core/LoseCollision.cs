using UnityEngine;

[DisallowMultipleComponent]
public class LoseCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Lose: Player hit by enemy or arrow");
            GlobalEvents.Instance?.RaiseLose();
        }
    }
}
