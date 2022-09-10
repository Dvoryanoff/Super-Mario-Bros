using superMarioBros.gameplay;
using Zenject;


namespace superMarioBros.installers {
	public class LevelInstaller : MonoInstaller {
		public override void InstallBindings () {
			InstallGameManager();
		}


		private void InstallGameManager () {
			Container.BindInterfacesAndSelfTo <GameManager>()
			         .AsSingle();
		}
	}
}
