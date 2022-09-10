using Zenject;


namespace superMarioBros.gameStateMachine.states {
	public abstract class GameStateBase {
		protected GameStateMachine stateMachine;


		[Inject]
		private void Inject (GameStateMachine stateMachine) {
			this.stateMachine = stateMachine;
		}


		public virtual void OnEnter () {}
		public virtual void OnExit () {}
	}
}
