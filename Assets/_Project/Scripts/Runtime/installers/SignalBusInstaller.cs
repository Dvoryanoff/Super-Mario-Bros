using superMarioBros.signals;
using Zenject;


namespace superMarioBros.installers {
	public class SignalBusInstaller : MonoInstaller {
		public override void InstallBindings () {
			Zenject.SignalBusInstaller.Install(Container);

			DeclareGameplaySignals();
		}

		private void DeclareGameplaySignals () {
			Container.DeclareSignal <GameplaySignal.LevelLoaded>().OptionalSubscriber();
			Container.DeclareSignal <GameplaySignal.LevelUnloaded>().OptionalSubscriber();

			Container.DeclareSignal <GameplaySignal.PlayerSpawned>().OptionalSubscriber();
			Container.DeclareSignal <GameplaySignal.PlayerDied>().OptionalSubscriber();
		}
	}
}
