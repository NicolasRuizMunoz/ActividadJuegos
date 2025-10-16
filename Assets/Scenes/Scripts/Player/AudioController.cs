using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [Header("Clips")]
    [SerializeField] private AudioClip wallBeep; //Aca elegir sonido

    private AudioSource source;
    private StateController state;

    public void Connect(StateController state)
    {
        this.state = state;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
    }
    public void PlayWallBeep()
    {
        if (source && wallBeep)
        {
            source.PlayOneShot(wallBeep);
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("beep-activado");
            EditorApplication.Beep();
#endif
        }
    }
}
