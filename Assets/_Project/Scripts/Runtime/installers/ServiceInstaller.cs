using superMarioBros.gameStateMachine;
using superMarioBros.services;
using Zenject;


namespace superMarioBros.installers {
	public class ServiceInstaller : MonoInstaller {
		public override void InstallBindings () {
			InstallPlainClassFactory();
			InstallGameStateMachine();
		}

		private void InstallPlainClassFactory () {
			Container.Bind <PlainClassFactory>()
			         .AsSingle();
		}

		private void InstallGameStateMachine () {
			Container.BindInterfacesAndSelfTo <GameStateMachine>()
			         .AsSingle();
		}
	}
}
