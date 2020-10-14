using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Lib.Core;

namespace Lib.Uwp
{
    public class DialogService : IDialogService
	{
		public async Task ShowMessageAsync(string title, string message, string textYes)
		{
			var messageDialog = new MessageDialog(message, title);
			messageDialog.Commands.Add(new UICommand(textYes));
			messageDialog.DefaultCommandIndex = 0;
			messageDialog.CancelCommandIndex = 1;
			await messageDialog.ShowAsync();
		}

		public async Task<bool> ShowConfirmationAsync(string title, string text, string textYes, string textNo)
		{
			var yes = false;
			var messageDialog = new MessageDialog(text, title);
			var yesCommand = new UICommand(textYes, param => { yes = true; });
			var noCommand = new UICommand(textNo, param => { yes = false; });
			messageDialog.Commands.Add(yesCommand);
			messageDialog.Commands.Add(noCommand);
			await messageDialog.ShowAsync();
			return yes;
		}
	}
}