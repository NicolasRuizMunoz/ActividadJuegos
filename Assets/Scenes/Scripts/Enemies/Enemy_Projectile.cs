using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector2 dir = Vector2.right;
    private float dieAt = Mathf.Infinity;
    public void Initialize(Vector2 direction, float lifetimeSeconds)
    {
        dir = direction.sqrMagnitude > 0 ? direction.normalized : Random.insideUnitCircle.normalized;
        dieAt = Time.time + Mathf.Max(0.01f, lifetimeSeconds);
    }

    void Update()
    {
        transform.position += (Vector3)(dir * speed * Time.deltaTime);

        if (Time.time >= dieAt)
            Destroy(gameObject);
    }
}
