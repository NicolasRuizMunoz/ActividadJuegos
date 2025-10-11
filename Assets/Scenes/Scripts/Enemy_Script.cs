using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    [SerializeField] private float movementDistance = 3f;
    [SerializeField] private float speed = 2f;

    private bool movingUp;
    private float topEdge;
    private float bottomEdge;

    void Awake()
    {
        bottomEdge = transform.position.y - movementDistance;
        topEdge = transform.position.y + movementDistance;
    }

    void Update()
    {
        HandleState();                   
        HandleMovement(Time.deltaTime);
    }
    private void HandleState()
    {
        if (movingUp && transform.position.y >= topEdge) movingUp = false;
        else if (!movingUp && transform.position.y <= bottomEdge) movingUp = true;
    }

    private void HandleMovement(float dt)
    {
        float dy = (movingUp ? +1f : -1f) * speed * dt;
        float newY = Mathf.Clamp(transform.position.y + dy, bottomEdge, topEdge);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
