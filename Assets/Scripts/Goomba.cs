using UnityEngine;

public class Goomba : MonoBehaviour {
    [SerializeField] private Sprite flatSprite;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {

            Player player = collision.gameObject.GetComponent<Player>();

            if (collision.transform.DotTest(transform, Vector2.down)) {
                Flatten();
            } else {
                player.Hit();
            }
        }

    }

    private void Flatten() {
        //GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite;

        Destroy(gameObject, 0.5f);
    }
}
