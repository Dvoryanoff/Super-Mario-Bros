using UnityEngine;
using Zenject;


namespace superMarioBros.gameplay {
	public class PowerUp : MonoBehaviour {
		public enum Type {
			Coin,
			ExtraLife,
			MagicMushroom,
			StarPower,
		}

		public Type type;

		private GameManager gameManager;

		
		[Inject]
		private void Inject (GameManager pGameManager) {
			gameManager = pGameManager;
		}

		private void OnTriggerEnter2D (Collider2D other) {
			if (other.CompareTag("Player")) {
				Collect(other.gameObject);
			}
		}

		private void Collect (GameObject player) {
			switch (type) {
				case Type.Coin:
					gameManager.AddCoin();
					break;
				case Type.MagicMushroom:
					player.GetComponent <Player>().Grow();
					break;
				case Type.ExtraLife:
					gameManager.AddLife();
					break;
				case Type.StarPower:
					player.GetComponent <Player>().StarPower();
					break;
			}

			Destroy(gameObject);
		}
	}
}
