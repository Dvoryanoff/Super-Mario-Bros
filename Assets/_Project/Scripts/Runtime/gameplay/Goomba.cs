using superMarioBros.extensions;
using UnityEngine;


namespace superMarioBros.gameplay {
	public class Goomba : GroundMob {
		[SerializeField] private Sprite flatSprite;

		private void OnCollisionEnter2D(Collision2D collision) {
			if (collision.gameObject.CompareTag("Player")) {
				Mario mario = collision.gameObject.GetComponent<Mario>();

				if (mario.starPower) {
					Hit();
				} else if (collision.transform.DotTest(transform, Vector2.down)) {
					Flatten();
				} else {
					mario.Hit();
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.layer == LayerMask.NameToLayer("Shell")) {
				Hit();
			}
		}

		private void Flatten() {
			GetComponent<Rigidbody2D>().isKinematic = true;
			GetComponent<EntityMovement>().enabled  = false;
			GetComponent<AnimatedSprite>().enabled  = false;
			GetComponent<Collider2D>().enabled      = false;
			GetComponent<SpriteRenderer>().sprite   = flatSprite;

			Destroy(gameObject, 0.5f);
		}

		protected override void Hit() {
			GetComponent<DeathAnimation>().enabled = true;
			GetComponent<AnimatedSprite>().enabled = false;
			Destroy(gameObject, 3f);
		}
	}
}
