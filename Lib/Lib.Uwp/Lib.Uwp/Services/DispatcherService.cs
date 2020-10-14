using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Lib.Core;

namespace Lib.Uwp
{
    public class DispatcherService : IDispatcherService
	{
		public bool HasThreadAccess()
		{
			return CoreApplication.MainView.CoreWindow.Dispatcher.HasThreadAccess;
		}

		public async Task RunAsync(Action action)
		{
			var finished = false;

			await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
			{
				try
				{
					action();
				}
				catch (Exception)
				{
				}
				finally
				{
					finished = true;
				}
			});

			while (!finished)
			{
			}
		}
	}
}