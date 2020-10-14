using System;

namespace Lib.Core
{
	public interface INavigationService
	{
		void ClearBackStack();

		void GoBack();

		void NavigateTo(Type view, object parameter = null);
	}
}