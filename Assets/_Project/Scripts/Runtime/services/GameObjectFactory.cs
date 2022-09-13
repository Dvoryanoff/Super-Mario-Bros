using UnityEngine;
using Zenject;


namespace superMarioBros.services {
	public class GameObjectFactory {
		private readonly DiContainer container;


		public GameObjectFactory (DiContainer container) {
			this.container = container;
		}


		public GameObject Create (GameObject original) {
			return Create(original, Vector3.zero, Quaternion.identity, null);
		}

		public GameObject Create (GameObject original, Transform parent) {
			return Create(original, Vector3.zero, Quaternion.identity, parent);
		}

		public GameObject Create (GameObject original, Vector3 position, Quaternion rotation) {
			return Create(original, position, rotation, null);
		}

		public GameObject Create (GameObject original, Vector3 position, Quaternion rotation, Transform parent) {
			return container.InstantiatePrefab(original, position, rotation, parent);
		}


		public TComponent Create<TComponent> (TComponent original) where TComponent : Component {
			return Create(original, Vector3.zero, Quaternion.identity, null);
		}

		public TComponent Create<TComponent> (TComponent original, Transform parent) where TComponent : Component {
			return Create(original, Vector3.zero, Quaternion.identity, parent);
		}

		public TComponent Create<TComponent> (TComponent original, Vector3 position, Quaternion rotation) where TComponent : Component {
			return Create(original, position, rotation, null);
		}

		public TComponent Create<TComponent> (TComponent original, Vector3 position, Quaternion rotation, Transform parent) where TComponent : Component {
			return container.InstantiatePrefabForComponent <TComponent>(original, position, rotation, parent);
		}


		// TODO add methods for Addressables
	}
}
