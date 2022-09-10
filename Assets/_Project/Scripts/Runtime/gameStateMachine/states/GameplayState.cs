using superMarioBros.services;
using UnityEngine;
using Zenject;


namespace superMarioBros.gameStateMachine.states {
	public class GameplayState : GameStateBase {
		private LevelLoader       levelLoader;
		private GameObjectFactory gameObjectFactory;


		[Inject]
		private void Inject (LevelLoader levelLoader, GameObjectFactory gameObjectFactory) {
			this.levelLoader       = levelLoader;
			this.gameObjectFactory = gameObjectFactory;
		}

		public override void OnEnter () {
			levelLoader.LoadLevel(1, 1); // TODO move to PlayerData \ User \ SaveData wtvr

			GameObject marioProto = Resources.Load("Prefabs/Mario") as GameObject;
			gameObjectFactory.Create(marioProto); // FIXME what
		}
	}
}
