﻿using UnityEngine;

namespace extensions {
	public static class TransformExtensions {
		public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection) {
			Vector2 direction = other.position - transform.position;
			return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
		}
	}
}