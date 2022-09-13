using UnityEngine;


namespace superMarioBros.extensions {
	public static class Vector2IntExtensions {
		public static Vector3 ToVector3 (this Vector2Int vector) {
			return new Vector3(vector.x, vector.y);
		}
	}
}
