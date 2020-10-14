using System;
using System.Collections.Generic;

namespace Lib.Core
{
    public class DependencyInjector : IDependencyInjector
	{
		private static DependencyInjector _instance;
		private readonly Dictionary<Type, object> _container;

        public static DependencyInjector Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DependencyInjector();
                }

                return _instance;
            }
        }
        
		protected DependencyInjector()
		{
			_container = new Dictionary<Type, object>();
		}

		public void Register<TInterface>(object type) where TInterface : class
        {
            if (_container.ContainsKey(typeof(TInterface)))
            {
                _container.Remove(typeof(TInterface));
            }

			_container.Add(typeof(TInterface), type);
		}

		public TInterface Resolve<TInterface>() where TInterface : class
        {
            object service;
            _container.TryGetValue(typeof(TInterface), out service);
            return service as TInterface;
		}
	}
}