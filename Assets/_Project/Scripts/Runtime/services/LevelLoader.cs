using System;
using superMarioBros.gameplay;
using superMarioBros.levels;
using superMarioBros.services;
using superMarioBros.signals;
using UnityEngine;
using Zenject;


namespace superMarioBros.assetsManagement {
	public class LevelLoader {
		private ILevel loadedLevel;


		private readonly SignalBus         signalBus;
		private readonly GameObjectFactory gameObjectFactory;
		private readonly LevelSequence     levelSequence;


		public ILevel LoadedLevel => loadedLevel;


		public LevelLoader (SignalBus signalBus, GameObjectFactory gameObjectFactory, LevelSequence levelSequence) {
			this.signalBus         = signalBus;
			this.levelSequence     = levelSequence;
			this.gameObjectFactory = gameObjectFactory;
		}

		public void LoadLevel () {
			const int world = 1; // TODO get from player persistent data
			const int stage = 1; // TODO get from player persistent data

			loadedLevel = gameObjectFactory.Create(levelSequence[world, stage]);

			SpawnPlayer(loadedLevel.PlayerSpawnLocation);

			signalBus.Fire(new GameplaySignal.LevelLoaded(loadedLevel));
		}

		public void UnloadLevel () {
			if (LoadedLevel == null)
				throw new Exception("No Level was previously loaded.");

			loadedLevel.Discard();
			loadedLevel = null;

			signalBus.Fire <GameplaySignal.LevelUnloaded>();
		}

		private void SpawnPlayer (Vector2Int at) {
			// TODO move method 


			Mario marioProto = Resources.Load <Mario>("Prefabs/Mario"); // TODO move to addressable
			Mario mario      = gameObjectFactory.Create(marioProto);

			mario.SetPosition(to: at);
			
			signalBus.Fire(new GameplaySignal.PlayerSpawned(mario));
		}
	}

	public class LevelEntitySpawner {}
}


// TODO move scenes to Addressables
