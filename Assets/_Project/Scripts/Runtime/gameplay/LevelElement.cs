using superMarioBros.extensions;
using UnityEngine;


namespace superMarioBros.gameplay {
	public abstract class LevelElement : MonoBehaviour {
		protected Vector2Int Position => transform.position.RoundToVector2Int();
	}
}