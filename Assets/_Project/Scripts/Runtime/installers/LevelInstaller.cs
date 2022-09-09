using superMarioBros.services;
using Zenject;


namespace superMarioBros.installers {
	public class LevelInstaller : MonoInstaller {
		public override void InstallBindings () {
			InstallLevelLoader();
		}

		private void InstallLevelLoader () {
			Container.Bind <LevelLoader>()
			         .AsSingle();
		}
	}
}
