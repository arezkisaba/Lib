namespace Lib.Core
{
	public interface IDependencyInjector
	{
		void Register<TInterface>(object type) where TInterface : class;
		TInterface Resolve<TInterface>() where TInterface : class;
	}
}