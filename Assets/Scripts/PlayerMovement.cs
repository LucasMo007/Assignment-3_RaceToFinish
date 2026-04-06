using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float maxSpeed = 12f;

    [Header("Jumping")]
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.3f;
    public LayerMask groundLayer;

    [Header("Ground Check")]
    public Transform groundCheck;

    private Rigidbody rb;
    private bool isGrounded;
    private float moveX;
    private float moveZ;

    private Animator animator;

    // Speed modifiers for speed-up and slow-down zones
    private float speedMultiplier = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Freeze rotation so the player doesn't topple over
        rb.freezeRotation = true;
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Get input
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        // Ground check using sphere cast
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundLayer);

        animator.SetFloat("Speed", new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).magnitude);
        animator.SetBool("Grounded", isGrounded);

        // Jump - works straight up and diagonally (if moving while jumping)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

   
    void FixedUpdate()
    {
        // Get camera forward and right (ignore Y)
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // Movement relative to camera
        Vector3 moveDirection = (camForward * moveZ + camRight * moveX).normalized;
        Vector3 force = moveDirection * moveSpeed * speedMultiplier;

        rb.AddForce(force, ForceMode.Force);

        // Rotate player to face movement direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        }

        // Clamp horizontal speed
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizontalVelocity.magnitude > maxSpeed * speedMultiplier)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed * speedMultiplier;
            rb.linearVelocity = new Vector3(horizontalVelocity.x, rb.linearVelocity.y, horizontalVelocity.z);
        }
    }
    // Called by SpeedZone triggers
    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }

    // Visualize ground check in editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckDistance);
        }
    }
}
