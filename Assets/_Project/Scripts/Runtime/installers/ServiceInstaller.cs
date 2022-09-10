using superMarioBros.gameStateMachine;
using superMarioBros.services;
using Zenject;


namespace superMarioBros.installers {
	public class ServiceInstaller : MonoInstaller {
		public override void InstallBindings () {
			InstallPlainClassFactory();
			InstallGameObjectFactory();

			InstallGameStateMachine();

			InstallLevelLoader();
		}

		private void InstallPlainClassFactory () {
			Container.Bind <PlainClassFactory>()
			         .AsSingle();
		}

		private void InstallGameObjectFactory () {
			Container.Bind <GameObjectFactory>()
			         .AsSingle();
		}

		private void InstallGameStateMachine () {
			Container.BindInterfacesAndSelfTo <GameStateMachine>()
			         .AsSingle();
		}

		private void InstallLevelLoader () {
			Container.Bind <LevelLoader>()
			         .AsSingle();
		}
	}
}
