using System;
using UnityEngine.SceneManagement;


namespace superMarioBros.assetsManagement {
	public static class SceneLoader {
		public static void LoadSceneAsync (string sceneName, LoadSceneMode mode = LoadSceneMode.Single, Action onComplete = null) {
			SceneManager.LoadSceneAsync(sceneName, mode)
			            .completed += _ => onComplete?.Invoke();
		}
	}
}
