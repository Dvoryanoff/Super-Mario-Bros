using System;
using superMarioBros.gameplay;
using UnityEngine.SceneManagement;


namespace superMarioBros.services {
	public class LevelLoader {
		private string    sceneNameCache;
		public  LevelData LoadedLevel;


		public void LoadLevel (int world, int stage) {
			sceneNameCache = $"{world}-{stage}";
			SceneManager.LoadScene(sceneNameCache, LoadSceneMode.Additive);

			LoadedLevel = new LevelData(world, stage);
		}

		public void UnloadLevel () {
			if (string.IsNullOrEmpty(sceneNameCache))
				throw new NullReferenceException("No Level was previously loaded.");

			SceneManager.UnloadSceneAsync(sceneNameCache);
			sceneNameCache = default;
			LoadedLevel    = default;
		}
	}
}


// TODO move scenes to Addressables
