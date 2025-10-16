using UnityEngine;

[DisallowMultipleComponent]
public class StateController : MonoBehaviour
{
    [Header("Visual")]
    [SerializeField] private GameObject backgroundRoot;

    private SpriteRenderer sr;
    private PhysicsController physics;
    private AudioController audio;

    public bool IsAlive { get; private set; } = true;

    public void Connect(PhysicsController physics, AudioController audio)
    {
        this.physics = physics;
        this.audio = audio;
    }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void UpdateFacing(float xDir)
    {
        if (!sr) return;
        if (xDir > 0.01f) sr.flipX = false;
        else if (xDir < -0.01f) sr.flipX = true;
    }

    public void RandomizeSpriteColor()
    {
        if (sr) sr.color = Random.ColorHSV();
    }

    public void RandomizeBackgroundColors()
    {
        if (!backgroundRoot) return;
        var tiles = backgroundRoot.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var tile in tiles)
        {
            Color c = Random.ColorHSV(
                0f, 1f,    
                0.7f, 1f, 
                0.75f, 1f, 
                1f, 1f     
            );
            tile.color = c;
        }
    }
}
