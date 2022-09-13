using System.Collections.Generic;
using System.Linq;
using superMarioBros.configs;
using UnityEngine;


namespace superMarioBros.levels {
	[CreateAssetMenu(menuName = "Super Mario Bros/Level Sequence")]
	public class LevelSequence : Config {
		#region Set in Inspector
		[SerializeField] private List <Level> levels;
		#endregion Set in Inspector


		public Level this [int levelIndex] {
			get {
				if (levelIndex < levels.Count)
					return levels[levelIndex];

				Debug.LogWarning($"Level Sequence does not contain level at index: \"{levelIndex}\". Cycling around.");
				levelIndex %= levels.Count;

				return levels[levelIndex];
			}
		}

		public Level this [int world, int stage] => levels.First(level => level.World == world && level.Stage == stage);
	}
}
