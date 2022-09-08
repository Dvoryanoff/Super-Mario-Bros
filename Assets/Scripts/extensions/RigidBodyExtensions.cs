using UnityEngine;


namespace extensions {
	public static class RigidBodyExtensions {
		private static readonly int LayerMask;


		static RigidBodyExtensions () {
			LayerMask = UnityEngine.LayerMask.GetMask("Default");
		}

		public static bool Raycast (this Rigidbody2D rigidbody, Vector2 direction) {
			const float radius   = 0.4f;
			const float distance = 0.375f;

			if (rigidbody.isKinematic)
				return false;

			RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction.normalized, distance, LayerMask);
			return hit.collider != null && hit.rigidbody != rigidbody;
		}
	}
}
