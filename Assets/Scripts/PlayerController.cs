using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float runMultiplier = 1.5f;
    private bool isRunning;
    private Vector2 moveInput;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        float currentSpeed = isRunning ? moveSpeed * runMultiplier : moveSpeed;
        Vector2 nextPos = rb.position + moveInput * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(nextPos);
    }
}
