using UnityEngine;


namespace extensions {
	public static class Vector3Extensions {
		public static Vector2Int RoundToVector2Int (this Vector3 vector) {
			return new Vector2Int(
				Mathf.RoundToInt(vector.x),
				Mathf.RoundToInt(vector.y)
			);
		}

		public static Vector2Int FloorToVector2Int (this Vector3 vector) {
			return new Vector2Int(
				Mathf.FloorToInt(vector.x),
				Mathf.FloorToInt(vector.y)
			);
		}

		public static Vector2Int CeilToVector2Int (this Vector3 vector) {
			return new Vector2Int(
				Mathf.CeilToInt(vector.x),
				Mathf.CeilToInt(vector.y)
			);
		}
	}
}
