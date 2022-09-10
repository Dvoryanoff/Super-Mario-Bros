// ReSharper disable UnusedMember.Local

using UnityEngine;


namespace superMarioBros.configs {
	[CreateAssetMenu(menuName = "Super Mario Bros/App Config")]
	public class AppConfig : Config {
		#region Set in Inspector
		[SerializeField] private FrameRate    targetFrameRate = FrameRate._60;
		[SerializeField] private SleepTimeout sleepTimeout    = SleepTimeout.NeverSleep;
		[SerializeField] private bool         multiTouchEnabled;
		#endregion Set in Inspector


		public override void Initialize () {
			Application.targetFrameRate = (int)targetFrameRate;
			Screen.sleepTimeout         = (int)sleepTimeout;
			Input.multiTouchEnabled     = multiTouchEnabled;
		}

		private enum FrameRate {
			_60  = 60,
			_120 = 120
		}

		private enum SleepTimeout {
			NeverSleep    = UnityEngine.SleepTimeout.NeverSleep,
			SystemSetting = UnityEngine.SleepTimeout.SystemSetting
		}
	}
}
