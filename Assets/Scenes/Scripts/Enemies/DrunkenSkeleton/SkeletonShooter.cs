using UnityEngine;

public class SkeletonShooter : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float spawnRadius = 3f;
    [SerializeField] private float projectileLifetime = 5f;

    public void Shoot()
    {
        if (!arrowPrefab) return;

        // posición  alrededor del esqueleto
        Vector2 off = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = transform.position + new Vector3(off.x, off.y, 0f);

        // dirección aleatoria
        Vector2 dir;
        do { dir = Random.insideUnitCircle; } while (dir.sqrMagnitude < 0.05f);
        dir.Normalize();

        // inicializar flecha
        var arrow = Instantiate(arrowPrefab, spawnPos, Quaternion.identity);
        var proj = arrow.GetComponent<EnemyProjectile>();
        if (proj) proj.Initialize(dir, projectileLifetime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
