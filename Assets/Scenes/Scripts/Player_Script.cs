using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Script : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] public float moveSpeed = 5f;

    [Header("Background")]
    [SerializeField] private GameObject backgroundRoot; 

    private SpriteRenderer sr;
    private Vector2 inputDir;
    private Rigidbody2D rb;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        HandleState();
    }

    void FixedUpdate()
    {
        HandleMovement(Time.fixedDeltaTime);
    }

    private void HandleInput()
    {
        inputDir = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) inputDir.x -= 1f;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) inputDir.x += 1f;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) inputDir.y += 1f;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) inputDir.y -= 1f;

        if (inputDir.sqrMagnitude > 1f) inputDir = inputDir.normalized;

        if (sr != null)
        {
            if (inputDir.x > 0.01f)
                sr.flipX = false;
            else if (inputDir.x < -0.01f)
                sr.flipX = true;
        }
    }

    private void HandleMovement(float dt)
    {
        Vector2 nextPos = rb.position + inputDir * moveSpeed * dt;
        rb.MovePosition(nextPos);
    }

    private void HandleState()
    {
        if (Input.GetKeyDown(KeyCode.B))
            ChangeBackgroundColor();

        if (Input.GetKeyDown(KeyCode.C) && sr != null)
            sr.color = Random.ColorHSV();
    }

    private void ChangeBackgroundColor()
    {
        if (backgroundRoot == null) return;
        var tiles = backgroundRoot.GetComponentsInChildren<SpriteRenderer>(true);

        foreach (var tile in tiles)
        {
            Color c = Random.ColorHSV(
                0f, 1f,     
                0.7f, 1f,   
                0.75f, 1f, 
                1f, 1f  
            );
            tile.color = c;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
            PlayBeep();
    }

    private void PlayBeep()
    {
#if UNITY_EDITOR
        EditorApplication.Beep(); 
#endif
    }
}
