using UnityEngine;


public abstract class GroundMob : LevelElement {
	protected virtual void Awake () {
		BlockHit.OnBlockHit += OnBlockHitCallback;
	}

	protected virtual void OnDestroy () {
		BlockHit.OnBlockHit -= OnBlockHitCallback;
	}

	private void OnBlockHitCallback (Vector2Int blockCoords) {
		if (IsStandingOnBlock(blockCoords))
			Hit();
	}

	protected virtual bool IsStandingOnBlock (Vector2Int blockCoords) {
		Vector2Int position = Position;
		return blockCoords.x == position.x && position.y - blockCoords.y == 1;
	}

	protected abstract void Hit ();
}
