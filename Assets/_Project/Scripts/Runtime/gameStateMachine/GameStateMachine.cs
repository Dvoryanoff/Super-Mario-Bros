using superMarioBros.gameStateMachine.states;
using superMarioBros.services;
using Zenject;


namespace superMarioBros.gameStateMachine {
	public class GameStateMachine : IInitializable {
		private readonly PlainClassFactory factory;

		private GameStateBase currentState;


		public GameStateMachine (PlainClassFactory factory) {
			this.factory = factory;
		}

		public void Enter<TState> () where TState : GameStateBase, new() {
			currentState?.OnExit();
			currentState = factory.Create <TState>();
			currentState.OnEnter();
		}

		public void Initialize () {
			Enter <BootstrapState>();
		}
	}
}
