using UnityEngine;
using Zenject;


namespace superMarioBros.gameplay {
	public class DeathBarrier : MonoBehaviour {
		private GameManager gameManager;


		[Inject]
		private void Inject (GameManager pGameManager) {
			gameManager = pGameManager;
		}


		private void OnTriggerEnter2D (Collider2D other) {
			if (other.CompareTag("Player")) {
				other.gameObject.SetActive(false);
				gameManager.ResetLevel();
			} else {
				Destroy(other.gameObject);
			}
		}
	}
}
