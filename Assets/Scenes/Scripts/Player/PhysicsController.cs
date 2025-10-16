using UnityEngine;

[DisallowMultipleComponent]
public class PhysicsController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private float collisionRadius = 0.5f;

    public Vector2 MoveInput { get; set; }

    private AudioController audioCtrl;
    private StateController stateCtrl;

    public void Connect(AudioController audio, StateController state)
    {
        audioCtrl = audio;
        stateCtrl = state;
    }

    void Update()
    {
        if (MoveInput.sqrMagnitude > 0f)
        {
            Vector3 nextPos = transform.position + (Vector3)(MoveInput * moveSpeed * Time.deltaTime);

            if (!IsColliding(nextPos))
            {
                transform.position = nextPos;
            }
            else
            {
                audioCtrl?.PlayWallBeep();
                stateCtrl?.NotifyBumpedWall();
            }
        }
    }
    private bool IsColliding(Vector3 targetPosition)
    {
        Collider2D hit = Physics2D.OverlapCircle(targetPosition, collisionRadius, wallMask);
        return hit != null;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collisionRadius);
    }
}
