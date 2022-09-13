using superMarioBros.gameplay;
using superMarioBros.levels;


namespace superMarioBros.signals {
	public static class GameplaySignal {
		public class LevelLoaded {
			public readonly ILevel Level;

			public LevelLoaded (ILevel level) {
				Level = level;
			}
		}

		public class PlayerDied {}

		public class LevelUnloaded {}

		public class PlayerSpawned {
			public readonly Mario Mario;

			public PlayerSpawned (Mario mario) {
				Mario = mario;
			}
		}
	}
}
