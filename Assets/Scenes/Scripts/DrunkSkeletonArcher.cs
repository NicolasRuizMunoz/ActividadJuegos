using UnityEngine;

public class DrunkSkeletonArcher : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float spawnRadius = 3f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float initialPhaseOffset = 0.3f;

    private GameObject activeArrow;
    private float shootTimer;

    void Start()
    {
        shootTimer = projectileLifetime + initialPhaseOffset;
    }

    void Update()
    {
        HandleTimers(Time.deltaTime);
        HandleShootCycle();
    }

    private void HandleTimers(float dt)
    {
        if (shootTimer > 0f) shootTimer -= dt;
    }

    private void HandleShootCycle()
    {
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = projectileLifetime;
        }
    }

    private void Shoot()
    {
        if (!arrowPrefab) return;
        if (activeArrow) Destroy(activeArrow);

        Vector3 center = transform.position;
        Vector2 rndPos = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = center + new Vector3(rndPos.x, rndPos.y, 0f);

        Vector2 dir;
        do { dir = Random.insideUnitCircle; } while (dir.sqrMagnitude < 0.05f);
        dir.Normalize();

        activeArrow = Instantiate(arrowPrefab, spawnPos, Quaternion.identity);

        var proj = activeArrow.GetComponent<EnemyProjectile>();
        if (proj)
        {
            proj.Initialize(dir, projectileLifetime);
        }
        else
        {
            var rb = activeArrow.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.gravityScale = 0f;
                float fallbackSpeed = 8f;
                rb.linearVelocity = dir * fallbackSpeed;
            }
            Destroy(activeArrow, projectileLifetime);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
