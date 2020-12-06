using System.Windows.Input;

namespace Lib.Core
{
    public static class CommandExtensions
	{
		public static void RaiseCanExecuteChanged(this ICommand command)
		{
			var relayCommand = command as RelayCommand;
			if (relayCommand != null)
			{
				relayCommand.RaiseCanExecuteChanged();
			}
		}
	}
}