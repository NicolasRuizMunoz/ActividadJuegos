using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class GlobalAudio : MonoBehaviour
{
    [Header("Clips")]
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip loseClip;
    [SerializeField] private AudioClip bumpClip; 

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
    }

    void OnEnable()
    {
        if (GlobalEvents.Instance != null)
        {
            GlobalEvents.Instance.OnWin += PlayWin;
            GlobalEvents.Instance.OnLose += PlayLose;
            GlobalEvents.Instance.OnWallBump += PlayBump;
        }
    }

    void OnDisable()
    {
        if (GlobalEvents.Instance != null)
        {
            GlobalEvents.Instance.OnWin -= PlayWin;
            GlobalEvents.Instance.OnLose -= PlayLose;
            GlobalEvents.Instance.OnWallBump -= PlayBump; 
        }
    }

    private void PlayWin() { if (winClip) source.PlayOneShot(winClip); }
    private void PlayLose() { if (loseClip) source.PlayOneShot(loseClip); }
    private void PlayBump() { if (bumpClip) source.PlayOneShot(bumpClip); }
}
