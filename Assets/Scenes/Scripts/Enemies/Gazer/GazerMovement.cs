using UnityEngine;

[DisallowMultipleComponent]
public class GazerMovement : MonoBehaviour
{
    [Header("Movimiento vertical")]
    [SerializeField, Tooltip("Distancia total de desplazamiento vertical")]
    private float movementDistance = 3f;

    [SerializeField, Tooltip("Velocidad de movimiento en unidades por segundo")]
    private float speed = 2f;

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

        // movimiento vertical
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y + dy, bottomEdge, topEdge),
            transform.position.z
        );

        // invertir dirección
        if (transform.position.y >= topEdge) movingUp = false;
        if (transform.position.y <= bottomEdge) movingUp = true;

        // notificar al estado visual
        state?.SetDirection(movingUp);
    }
}
