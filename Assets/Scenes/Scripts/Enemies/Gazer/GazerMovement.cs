using UnityEngine;
public class GazerMovement : MonoBehaviour
{
    [SerializeField] private float movementDistance = 3f;
    [SerializeField] private float speed = 2f;

    private bool movingUp;
    private float topEdge;
    private float bottomEdge;
    private GazerState state;

    void Start()
    {
        bottomEdge = transform.position.y - movementDistance;
        topEdge = transform.position.y + movementDistance;
        state = GetComponent<GazerState>();
    }

    void Update()
    {
        float dy = (movingUp ? 1f : -1f) * speed * Time.deltaTime;
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y + dy, bottomEdge, topEdge),
            transform.position.z
        );

        if (transform.position.y >= topEdge) movingUp = false;
        if (transform.position.y <= bottomEdge) movingUp = true;

        state?.SetDirection(movingUp);
    }
}
