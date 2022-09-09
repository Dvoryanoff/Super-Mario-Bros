using System;
using System.Collections;
using superMarioBros.extensions;
using UnityEngine;


namespace superMarioBros.gameplay {
	public class BlockHit : LevelElement {
		[SerializeField] private GameObject item;


		public static event Action <Vector2Int> OnBlockHit;


		private Transform myTransform;
		public  Sprite    emptyBlock;


		public  int  maxHits = -1;
		private bool animating;


		private void Awake () {
			myTransform = transform;
		}

		private void OnCollisionEnter2D (Collision2D collision) {
			bool isHitByPlayer = collision.gameObject.CompareTag("Player");
			bool canBeHit      = animating == false && maxHits != 0;

			if (canBeHit == false || isHitByPlayer == false)
				return;

			bool validHit = collision.transform.DotTest(myTransform, Vector2.up);

			if (validHit)
				Hit();
		}

		private void Hit () {
			SpriteRenderer spriteRenderer = GetComponent <SpriteRenderer>();
			spriteRenderer.enabled = true;

			maxHits--;

			if (maxHits == 0)
				spriteRenderer.sprite = emptyBlock;

			if (item != null)
				Instantiate(item, myTransform.position, Quaternion.identity);

			StartCoroutine(Animate());

			OnBlockHit?.Invoke(Position);
		}

		private IEnumerator Animate () {
			animating = true;

			Vector3 restingPosition  = myTransform.localPosition;
			Vector3 animatedPosition = restingPosition + Vector3.up * 0.5f;
			yield return Move(restingPosition,  animatedPosition);
			yield return Move(animatedPosition, restingPosition);

			animating = false;
		}

		private IEnumerator Move (Vector3 from, Vector3 to) {
			const float duration = 0.125f;

			float elapsed = 0f;

			while (elapsed < duration) {
				float t = elapsed / duration;
				myTransform.localPosition =  Vector3.Lerp(from, to, t);
				elapsed                   += Time.deltaTime;

				yield return null;

				myTransform.localPosition = to;
			}
		}
	}
}
