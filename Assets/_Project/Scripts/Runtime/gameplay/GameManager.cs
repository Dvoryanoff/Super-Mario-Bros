using superMarioBros.services;
using UnityEngine;
using Zenject;


namespace superMarioBros.gameplay {
	public class GameManager : MonoBehaviour {
		public static GameManager Instance {get; private set;}

		public int lives {get; private set;}
		public int coins {get; private set;}


		private LevelLoader levelLoader;


		public int World => levelLoader.LoadedLevel.World;
		public int Stage => levelLoader.LoadedLevel.Stage;

		[Inject]
		private void Inject (LevelLoader pLevelLoader) {
			levelLoader = pLevelLoader;
		}

		private void Awake () {
			if (Instance != null) {
				DestroyImmediate(gameObject);
			} else {
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}
		}

		private void OnDestroy () {
			if (Instance == this) {
				Instance = null;
			}
		}

		private void Start () {
			Application.targetFrameRate = 60;
			NewGame();
		}

		private void NewGame () {
			lives = 3;
			coins = 0;
			levelLoader.LoadLevel(1, 1);
		}

		public void NextLevel () {
			levelLoader.LoadLevel(World, Stage + 1);
		}

		public void ResetLevel (float delay) {
			Invoke(nameof(ResetLevel), delay);
		}

		public void ResetLevel () {
			lives--;
			if (lives > 0) {
				levelLoader.LoadLevel(World, Stage);
			} else {
				GameOver();
			}
		}

		private void GameOver () {
			NewGame();
		}

		public void AddCoin () {
			coins++;
			if (coins == 100) {
				AddLife();
				coins = 0;
			}
		}

		public void AddLife () {
			lives++;
		}
	}
}
