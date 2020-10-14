using System;
using System.Threading.Tasks;

namespace Lib.Core
{
	public interface IDispatcherService
	{
		bool HasThreadAccess();

		Task RunAsync(Action action);
	}
}