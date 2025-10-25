using UnityEngine;

[DisallowMultipleComponent]
public class SkeletonShootTimer : MonoBehaviour
{
    [Header("Control de disparo")]
    [SerializeField, Range(0.5f, 10f), Tooltip("Tiempo base entre disparos (segundos)")]
    private float shootInterval = 5f;

    [SerializeField, Range(0f, 1f), Tooltip("Variación aleatoria del intervalo")]
    private float randomVariance = 0.5f;

    private float timer;
    private SkeletonShooter shooter;

    void Start()
    {
        shooter = GetComponent<SkeletonShooter>();
        timer = shootInterval * Random.Range(1f - randomVariance, 1f + randomVariance);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            shooter?.Shoot();
            timer = shootInterval * Random.Range(1f - randomVariance, 1f + randomVariance);
        }
    }
}
