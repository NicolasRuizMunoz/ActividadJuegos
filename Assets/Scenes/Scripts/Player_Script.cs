using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] public float moveSpeed = 5f;

    private SpriteRenderer sr;
    private Camera cam;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }

    void Start()
    {
        if (cam != null)
            cam.backgroundColor = new Color(0.10f, 0.10f, 0.12f);
    }

    void Update()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) dir.x -= 1f;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) dir.x += 1f;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) dir.y += 1f;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) dir.y -= 1f;

        if (dir.sqrMagnitude > 1f) dir = dir.normalized;

        transform.Translate(dir * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.B) && cam != null)
            cam.backgroundColor = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.08f, 0.25f);

        if (Input.GetKeyDown(KeyCode.C) && sr != null)
            sr.color = Random.ColorHSV();
    }
}