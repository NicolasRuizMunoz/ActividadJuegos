using UnityEngine;

[DisallowMultipleComponent]
public class InputController : MonoBehaviour
{
    private PhysicsController physics;
    private StateController state;

    public void Connect(PhysicsController physics, StateController state)
    {
        this.physics = physics;
        this.state = state;
    }

    void Update()
    {
        //Movimiento
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) dir.x -= 1f;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) dir.x += 1f;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) dir.y += 1f;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) dir.y -= 1f;
        if (dir.sqrMagnitude > 1f) dir.Normalize();

        if (physics) physics.MoveInput = dir;

        if (state) state.UpdateFacing(dir.x);

        if (Input.GetKeyDown(KeyCode.C)) state?.RandomizeSpriteColor();
        if (Input.GetKeyDown(KeyCode.B)) state?.RandomizeBackgroundColors();
    }
}
