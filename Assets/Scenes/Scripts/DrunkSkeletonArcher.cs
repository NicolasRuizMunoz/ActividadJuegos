using UnityEngine;

public class DrunkSkeletonArcher : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject arrowPrefab;    // Prefab de la flecha
    [SerializeField] private Transform firePoint;       // Opcional: centro del radio; si es null usa la posición del arquero

    [Header("Disparo")]
    [SerializeField] private float spawnRadius = 3f;    // Requisito: radio 3
    [SerializeField] private float projectileLifetime = 5f; // Vuela ~5s
    [SerializeField] private float initialPhaseOffset = 0.3f;

    private GameObject activeArrow;
    private float timer;

    void Start()
    {
        // Disparo desfasado para no caer al mismo tiempo que otros enemigos
        timer = projectileLifetime + initialPhaseOffset;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Shoot();
            // Dispara la siguiente cuando se espera lo mismo que dura la flecha
            timer = projectileLifetime;
        }
    }

    void Shoot()
    {
        // Si había una flecha, elimínala (la anterior desaparece)
        if (activeArrow) Destroy(activeArrow);

        // Centro del radio para el spawn aleatorio
        Vector3 center = firePoint ? firePoint.position : transform.position;

        // Posición aleatoria dentro del radio
        Vector2 rndPos = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = center + new Vector3(rndPos.x, rndPos.y, 0f);

        // Dirección aleatoria (evita un vector casi cero)
        Vector2 dir;
        do { dir = Random.insideUnitCircle; } while (dir.sqrMagnitude < 0.05f);

        // Instanciar e inicializar
        activeArrow = Instantiate(arrowPrefab, spawnPos, Quaternion.identity);
        var proj = activeArrow.GetComponent<EnemyProjectile>();
        if (proj) proj.Initialize(dir, projectileLifetime);
    }

    // Gizmo para ver el radio de aparición
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 center = firePoint ? firePoint.position : transform.position;
        Gizmos.DrawWireSphere(center, spawnRadius);
    }
}
