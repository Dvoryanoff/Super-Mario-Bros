using superMarioBros.assetsManagement;
using superMarioBros.services;
using superMarioBros.signals;
using Zenject;


namespace superMarioBros.gameStateMachine.states {
	public class GameplayState : GameStateBase {
		private LevelLoader       levelLoader;
		private GameObjectFactory gameObjectFactory;
		private SignalBus         signalBus;


		[Inject]
		private void Inject (SignalBus pSignalBus, LevelLoader pLevelLoader) {
			signalBus   = pSignalBus;
			levelLoader = pLevelLoader;
		}

		public override void OnEnter () {
			levelLoader.LoadLevel();

			signalBus.Subscribe <GameplaySignal.PlayerDied>(OnPlayerDied);
		}

		public override void OnExit () {
			signalBus.Unsubscribe <GameplaySignal.PlayerDied>(OnPlayerDied);
		}

		private void OnPlayerDied () {
			RestartLevel();
		}

		private void RestartLevel () {
			levelLoader.UnloadLevel();
			levelLoader.LoadLevel();
		}
	}
}
