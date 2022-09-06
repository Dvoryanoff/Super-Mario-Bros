using extensions;
using UnityEngine;


public abstract class LevelElement : MonoBehaviour {
	protected Vector2Int Position => transform.position.RoundToVector2Int();
}