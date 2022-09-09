using DG.Tweening;
using superMarioBros.services;
using UnityEngine.SceneManagement;
using Zenject;


namespace superMarioBros.gameplay {
	public class GameManager : IInitializable {
		public int Lives {get; private set;}
		public int Coins {get; private set;}


		private LevelLoader levelLoader;


		public int World => levelLoader.LoadedLevel.World;
		public int Stage => levelLoader.LoadedLevel.Stage;

		private bool IsGameOver => Lives <= 0;


		[Inject]
		private void Inject (LevelLoader pLevelLoader) {
			levelLoader = pLevelLoader;
		}

		public void Initialize () {
			NewGame();
		}

		private void NewGame () {
			Lives = 3; // TODO move to config
			Coins = 0; // TODO move to currency service

			levelLoader.LoadLevel(1, 1);
		}

		public void NextLevel () {
			levelLoader.LoadLevel(World, Stage + 1);
		}

		public void ResetLevel () {
			DOTween.Sequence()
			       .OnStart(null)    // TODO disable input
			       .OnComplete(null) // TODO enable input
			       .SetDelay(1)
			       .AppendCallback(() => {
				       Lives--; // TODO move to PlayerData

				       if (IsGameOver) {
					       GameOver();
					       return;
				       }

				       levelLoader.LoadLevel(World, Stage);
				       SceneManager.LoadScene($"{World.ToString()}-{Stage.ToString()}");
			       });
		}

		private void GameOver () {
			NewGame();
		}

		public void AddCoin () {
			Coins++;

			if (Coins < 100)
				return;

			AddLife();
			Coins = 0;
		}

		public void AddLife () {
			Lives++;
		}
	}
}
