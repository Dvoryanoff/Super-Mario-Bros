using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private new Rigidbody2D rigidbody;
    private new Camera camera;
    private float inputAxis;
    private Vector2 velocity;
    private float offset = 0.5f;

    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float maxJumpHeight = 5f;
    [SerializeField] private float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    [SerializeField] private float maxJumpTime = 1f;
    [SerializeField] float gravity => (-2f * maxJumpHeight / Mathf.Pow(maxJumpTime / 2f, 2));

    public bool IsGrounded {
        get; private set;
    }
    public bool IsJumping {
        get; private set;
    }

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void Update() {
        HorizontalMovement();
        IsGrounded = rigidbody.Raycast(Vector2.down);
        if (IsGrounded) {
            GroundedMovement();
        }

        ApplyGravity();

    }

    private void HorizontalMovement() {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);
    }

    private void GroundedMovement() {
        velocity.y = Mathf.Max(velocity.y, 0);
        IsJumping = velocity.y > 0;

        if (Input.GetButtonDown("Jump")) {
            velocity.y = jumpForce;
            IsJumping = true;
        }
    }

    private void ApplyGravity() {
        bool IsFalling = velocity.y < 0 || !Input.GetButton("Jump");
        float multiplier = IsFalling ? 2f : 1f;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
        velocity.y += gravity * multiplier * Time.deltaTime;

    }

    private void FixedUpdate() {
        Vector2 position = rigidbody.position;
        position += velocity * Time.deltaTime;
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + offset, rightEdge.x - offset);
        rigidbody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer != LayerMask.NameToLayer("PowerUp")) {
            if (transform.DotTest(collision.transform, Vector2.up)) {
                velocity.y = 0;
            }
        }

    }
}

