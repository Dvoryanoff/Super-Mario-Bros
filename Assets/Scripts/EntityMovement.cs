using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class EntityMovement : MonoBehaviour {

    public float speed = 0f;
    private Vector2 initialDirection = Vector2.left;

    private new Rigidbody2D rigidbody;
    private Vector2 velocity;
    public Vector2 direction;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    private void Start() {
        direction = initialDirection;
    }

    private void OnBecameVisible() {
        enabled = true;
    }

    private void OnBecameInvisible() {
        enabled = false;
    }

    private void OnEnable() {
        rigidbody.WakeUp();
    }

    private void OnDisable() {
        rigidbody.velocity = Vector2.zero;
        rigidbody.Sleep();
    }

    private void FixedUpdate() {
        velocity.x = direction.x * speed;
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;
        ;

        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        if (rigidbody.Raycast(direction)) {
            direction = -direction;
        }

        if (rigidbody.Raycast(Vector2.down)) {
            velocity.y = Mathf.Max(velocity.y, 0);
        }
    }
}

