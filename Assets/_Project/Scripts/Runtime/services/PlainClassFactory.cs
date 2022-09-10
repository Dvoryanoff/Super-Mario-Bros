using System.Collections.Generic;
using Zenject;


namespace superMarioBros.services {
	public class PlainClassFactory {
		private readonly DiContainer container;


		public PlainClassFactory (DiContainer container) {
			this.container = container;
		}

		public T Create<T> () where T : class, new() {
			return container.Instantiate <T>();
		}

		public T Create<T> (IEnumerable <object> @params) where T : class, new() {
			return container.Instantiate <T>(@params);
		}
	}
}
