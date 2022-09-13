using superMarioBros.extensions;
using UnityEngine;


namespace superMarioBros.levels {
	public class Level : MonoBehaviour, ILevel {
		#region Set in Inspector
		[SerializeField] private int world;
		[SerializeField] private int stage;

		[Space]
		[SerializeField] private Transform playerSpawnLocation;
		#endregion Set in Inspector

		public int World => world;
		public int Stage => stage;

		public Vector2Int PlayerSpawnLocation => playerSpawnLocation.position.RoundToVector2Int();

		public void Discard () {
			Destroy(gameObject);
		}
	}
}
