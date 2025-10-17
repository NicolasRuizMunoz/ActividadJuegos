using UnityEngine;

public class SkeletonShootTimer : MonoBehaviour
{
    [SerializeField] private float shootInterval = 5f;
    private float timer;
    private SkeletonShooter shooter;

    void Start()
    {
        shooter = GetComponent<SkeletonShooter>();
        timer = shootInterval * Random.Range(0.5f, 1.5f);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            shooter?.Shoot();
            timer = shootInterval;
        }
    }
}
