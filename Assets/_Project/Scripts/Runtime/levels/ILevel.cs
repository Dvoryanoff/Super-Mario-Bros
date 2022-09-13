using UnityEngine;


namespace superMarioBros.levels {
	public interface ILevel {
		int World {get;}
		int Stage {get;}

		Vector2Int PlayerSpawnLocation {get;}

		void Discard ();
	}
}
