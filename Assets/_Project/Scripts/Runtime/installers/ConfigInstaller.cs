using superMarioBros.configs;
using UnityEngine;
using Zenject;


namespace superMarioBros.installers {
	public class ConfigInstaller : MonoInstaller {
		#region Set in Inspector
		[SerializeField] private Config[] configs;
		#endregion Set in Inspector


		public override void InstallBindings () {
			foreach (Config config in configs) {
				config.Initialize();
				
				Container.Bind(config.GetType())
				         .FromInstance(config)
				         .AsSingle();
			}
		}
	}
}
