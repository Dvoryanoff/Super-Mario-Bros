using superMarioBros.signals;
using UnityEngine;
using Zenject;


namespace superMarioBros.gameplay {
	public class SideScrolling : MonoBehaviour {
		private Transform playerTransform;
		private float     height            = 6.4f;
		private float     undergroundHeight = -9.36f;


		private Vector3 initialPosition;
		private bool    isTracking;


		private SignalBus signalBus;

		[Inject]
		private void Inject (SignalBus pSignalBus) {
			signalBus = pSignalBus;
		}

		private void Awake () {
			signalBus.Subscribe <GameplaySignal.PlayerSpawned>(OnPlayerSpawned);
			signalBus.Subscribe <GameplaySignal.PlayerDied>(OnPlayerDied);

			initialPosition = transform.position;
		}

		private void OnDestroy () {
			signalBus.Unsubscribe <GameplaySignal.PlayerSpawned>(OnPlayerSpawned);
			signalBus.Unsubscribe <GameplaySignal.PlayerDied>(OnPlayerDied);
		}

		private void OnPlayerSpawned (GameplaySignal.PlayerSpawned signal) {
			playerTransform = signal.Mario.transform;
			isTracking      = true;

			transform.position = initialPosition; // TODO хуета
		}

		private void OnPlayerDied () {
			playerTransform = null;
			isTracking      = false;
		}

		private void LateUpdate () {
			if (isTracking == false)
				return;

			Vector3 cameraPosition = transform.position;
			cameraPosition.x   = Mathf.Max(playerTransform.transform.position.x, cameraPosition.x);
			transform.position = cameraPosition;
		}

		public void SetUnderground (bool underground) {
			// TODO what
			// Vector3 cameraPosition = transform.position;
			// cameraPosition.y   = underground ? undergroundHeight : height;
			// transform.position = cameraPosition;
		}
	}
}
