using UnityEngine;

[DisallowMultipleComponent]
public class ExitGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Win: Player reached the exit!");
            GlobalEvents.Instance?.RaiseWin();
        }
    }
}
