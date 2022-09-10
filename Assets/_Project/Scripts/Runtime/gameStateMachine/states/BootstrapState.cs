using UnityEngine;


namespace superMarioBros.gameStateMachine.states {
	public class BootstrapState : GameStateBase {
		public override void OnEnter () {
			Debug.LogWarning("BOOTSTRAP");
		}
	}
}
