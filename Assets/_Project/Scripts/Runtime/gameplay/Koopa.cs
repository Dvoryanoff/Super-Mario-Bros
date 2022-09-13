using superMarioBros.extensions;
using UnityEngine;


namespace superMarioBros.gameplay {
    public class Koopa : GroundMob {
        [SerializeField] private Sprite shellSprite;
        [SerializeField] private float  shellSpeed = 12f;

        private bool shelled;
        private bool pushed;

        private void OnCollisionEnter2D(Collision2D collision) {
            if (!shelled && collision.gameObject.CompareTag("Player")) {

                Mario mario = collision.gameObject.GetComponent<Mario>();
                if (mario.starPower) {
                    Hit();
                } else if (collision.transform.DotTest(transform, Vector2.down)) {
                    EnterShell();
                } else {
                    mario.Hit();
                }
            }

        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (shelled && other.CompareTag("Player")) {
                if (!pushed) {
                    Vector2 direction = new Vector2(transform.position.x - other.transform.position.x, 0f);
                    PushShell(direction);

                } else {
                    Mario mario = other.GetComponent<Mario>();

                    if (mario.starPower) {
                        Hit();
                    } else
                        mario.Hit();
                }
            } else if (!shelled && other.gameObject.layer == LayerMask.NameToLayer("Shell")) {
                Hit();
            }

        }

        private void PushShell(Vector2 direction) {
            pushed                                  = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
            EntityMovement movement = GetComponent<EntityMovement>();
            movement.direction = direction.normalized;
            movement.speed     = shellSpeed;
            movement.enabled   = true;

            gameObject.layer = LayerMask.NameToLayer("Shell");
        }

        private void EnterShell() {
            shelled                                = true;
            GetComponent<EntityMovement>().enabled = false;
            GetComponent<AnimatedSprite>().enabled = false;
            GetComponent<SpriteRenderer>().sprite  = shellSprite;
        }

        protected override void Hit() {
            GetComponent<AnimatedSprite>().enabled = false;
            GetComponent<DeathAnimation>().enabled = true;
            Destroy(gameObject, 3f);
        }

        private void OnBecameInvisible() {
            if (pushed) {
                Debug.Log($"Test11");
                Destroy(gameObject);
            }
        }
    }
}
