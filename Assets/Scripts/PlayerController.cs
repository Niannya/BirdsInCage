using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float runMultiplier = 1.5f;
    private bool isRunning;
    private Vector2 moveInput;
    private bool canMove = true;

    private Vector2 facingDirection = Vector2.down;
    public Vector2 FacingDirection => facingDirection;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!canMove) return;

        // 读取输入与移动
        isRunning = Input.GetKey(KeyCode.LeftShift);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(horizontal, vertical).normalized;

        // 记录朝向
        if(moveInput != Vector2.zero)
        {
            facingDirection = moveInput;
        }
    }

    private void FixedUpdate()
    {
        float currentSpeed = isRunning ? moveSpeed * runMultiplier : moveSpeed;
        Vector2 nextPos = rb.position + moveInput * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(nextPos);
    }

    public void SetCanMove(bool value)
    {
        canMove = value;

        if (!canMove)
        {
            moveInput = Vector2.zero;
            isRunning = false;
        }
    }
}
