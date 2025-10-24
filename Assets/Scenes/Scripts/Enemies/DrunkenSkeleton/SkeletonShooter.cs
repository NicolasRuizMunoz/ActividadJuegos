using UnityEngine;

[DisallowMultipleComponent]
public class SkeletonShooter : MonoBehaviour
{
    [Header("Disparo")]
    [SerializeField, Range(1f, 10f), Tooltip("Radio máximo en el que puede aparecer la flecha")]
    private float spawnRadius = 3f;

    [SerializeField, Range(1f, 10f), Tooltip("Duración de la flecha antes de destruirse")]
    private float projectileLifetime = 5f;

    [SerializeField, Tooltip("Prefab de la flecha enemiga")]
    private GameObject arrowPrefab;

    public void Shoot()
    {
        if (!arrowPrefab) return;

        // posición aleatoria alrededor del esqueleto
        Vector2 off = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = transform.position + new Vector3(off.x, off.y, 0f);

        // dirección aleatoria
        Vector2 dir;
        do { dir = Random.insideUnitCircle; } while (dir.sqrMagnitude < 0.05f);
        dir.Normalize();

        // instanciar flecha
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
