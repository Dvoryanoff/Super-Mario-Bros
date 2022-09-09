﻿using superMarioBros.gameplay;


namespace superMarioBros.services {
	public class LevelLoader {
		public LevelData LoadedLevel;

		public void LoadLevel (int world, int stage) {
			// SceneManager.LoadScene($"{world}-{stage}");

			LoadedLevel = new LevelData(world, stage);
		}
	}
}
