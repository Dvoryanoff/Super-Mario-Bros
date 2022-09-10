using superMarioBros.gameplay;
using superMarioBros.services;
using Zenject;


namespace superMarioBros.installers {
	public class LevelInstaller : MonoInstaller {
		public override void InstallBindings () {
			InstallLevelLoader();
			InstallGameManager();
		}

		private void InstallLevelLoader () {
			Container.Bind <LevelLoader>()
			         .AsSingle();
		}

		private void InstallGameManager () {
			Container.BindInterfacesAndSelfTo <GameManager>()
			         .AsSingle();
		}
	}
}
