using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    [SerializeField] private float movementDistance = 3f;
    [SerializeField] private float speed = 2f;

    private bool movingUp;
    private float topEdge;
    private float bottomEdge;

    private void Awake()
    {
        bottomEdge = transform.position.y - movementDistance;
        topEdge = transform.position.y + movementDistance;
    }

    private void Update()
    {
        if (movingUp)
        {
            if (transform.position.y < topEdge)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y + speed * Time.deltaTime,
                    transform.position.z
                );
            }
            else
                movingUp = false;
        }
        else
        {
            if (transform.position.y > bottomEdge)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y - speed * Time.deltaTime,
                    transform.position.z
                );
            }
            else
                movingUp = true;
        }
    }
}