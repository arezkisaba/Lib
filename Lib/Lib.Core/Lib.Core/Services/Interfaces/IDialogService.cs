using System.Threading.Tasks;

namespace Lib.Core
{
	public interface IDialogService
    {
		Task ShowMessageAsync(string title, string message, string textYes);

		Task<bool> ShowConfirmationAsync(string title, string text, string textYes, string textNo);
	}
}