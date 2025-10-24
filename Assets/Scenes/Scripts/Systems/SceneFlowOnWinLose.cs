using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[DisallowMultipleComponent]
public class SceneFlowOnWinLose : MonoBehaviour
{
    [Header("Scene flow")]
    [SerializeField] private float reloadDelay = 0.6f; // pequeño delay para que suene el audio

    void OnEnable()
    {
        if (GlobalEvents.Instance != null)
        {
            GlobalEvents.Instance.OnWin += HandleWin;
            GlobalEvents.Instance.OnLose += HandleLose;
        }
    }

    void OnDisable()
    {
        if (GlobalEvents.Instance != null)
        {
            GlobalEvents.Instance.OnWin -= HandleWin;
            GlobalEvents.Instance.OnLose -= HandleLose;
        }
    }

    private void HandleWin() => StartCoroutine(ReloadSceneAfterDelay());
    private void HandleLose() => StartCoroutine(ReloadSceneAfterDelay());

    private IEnumerator ReloadSceneAfterDelay()
    {
        yield return new WaitForSeconds(reloadDelay);
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex); // igual que tu lógica actual
    }
}
