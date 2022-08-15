using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private new Rigidbody2D rigidbody;

    private float inputAxis;
    private Vector2 velocity;

    [SerializeField] private float moveSpeed = 8f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        HorizontalMovement();
    }

    private void HorizontalMovement() {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate() {
        Vector2 position = rigidbody.position;
        position += velocity * Time.deltaTime;

        rigidbody.MovePosition(position);
    }
}
