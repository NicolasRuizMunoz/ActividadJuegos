using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class PlayerRoot : MonoBehaviour
{
    public InputController inputCtrl { get; private set; }
    public PhysicsController physicsCtrl { get; private set; }
    public StateController stateCtrl { get; private set; }
    public AudioController audioCtrl { get; private set; }

    void Start()
    {
        inputCtrl = GetComponent<InputController>();
        physicsCtrl = GetComponent<PhysicsController>();
        stateCtrl = GetComponent<StateController>();
        audioCtrl = GetComponent<AudioController>();

        if (inputCtrl) inputCtrl.Connect(physicsCtrl, stateCtrl);
        if (physicsCtrl) physicsCtrl.Connect(audioCtrl, stateCtrl);
        if (stateCtrl) stateCtrl.Connect(physicsCtrl, audioCtrl);
        if (audioCtrl) audioCtrl.Connect(stateCtrl);
    }
}
