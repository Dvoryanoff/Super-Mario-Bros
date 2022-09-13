using System.Collections;
using superMarioBros.assetsManagement;
using superMarioBros.services;
using UnityEngine;
using Zenject;


// TODO create Level Sequence
namespace superMarioBros.gameplay {
	public class FlagPole : MonoBehaviour {
		[SerializeField] private Transform flag;
		[SerializeField] private Transform poleBottom;
		[SerializeField] private Transform castle;
		[SerializeField] private float     speed = 6f;

		[SerializeField] private int nextWorld = 1;
		[SerializeField] private int nextStage = 1;


		private LevelLoader levelLoader;


		[Inject]
		private void Inject (LevelLoader pLevelLoader) {
			levelLoader = pLevelLoader;
		}

		private void OnTriggerEnter2D (Collider2D other) {
			if (other.CompareTag(nameof(Mario))) {
				StartCoroutine(MoveTo(flag, poleBottom.position));
				StartCoroutine(LevelCompleteSequence(other.transform));
			}
		}

		private IEnumerator LevelCompleteSequence (Transform player) {
			player.GetComponent <PlayerMovement>().enabled = false;
			yield return MoveTo(player, poleBottom.position);
			yield return MoveTo(player, player.position + Vector3.right);
			yield return MoveTo(player, player.position + Vector3.right + Vector3.down);
			yield return MoveTo(player, castle.position);

			player.gameObject.SetActive(false);

			yield return new WaitForSeconds(2f);

			levelLoader.LoadLevel();
		}

		private IEnumerator MoveTo (Transform subject, Vector3 destination) {
			while (Vector3.Distance(subject.position, destination) > 0.125f) {
				subject.position = Vector3.MoveTowards(subject.position, destination, speed * Time.deltaTime);
				yield return null;
			}

			subject.position = destination;
		}
	}
}
