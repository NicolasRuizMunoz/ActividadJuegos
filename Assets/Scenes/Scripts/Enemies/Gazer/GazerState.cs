using UnityEngine;

[DisallowMultipleComponent]
public class GazerState : MonoBehaviour
{
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(bool movingUp)
    {
        if (!sr) return;
        sr.flipY = !movingUp;
    }
}
