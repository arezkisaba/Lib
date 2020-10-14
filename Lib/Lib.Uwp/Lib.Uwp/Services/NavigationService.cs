using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Lib.Core;

namespace Lib.Uwp
{
    public class NavigationService : INavigationService
	{
		public void ClearBackStack()
		{
			var rootFrame = Window.Current.Content as Frame;
			if (rootFrame != null)
			{
				rootFrame.BackStack.Clear();
			}
		}

		public void GoBack()
		{
			var rootFrame = Window.Current.Content as Frame;
			if (rootFrame != null)
			{
				if (rootFrame.CanGoBack)
				{
					rootFrame.GoBack();
				}
			}
		}

		public void NavigateTo(Type view, object parameter = null)
		{
			var rootFrame = Window.Current.Content as Frame;
			if (rootFrame != null)
			{
				var typeName = view.ToString();
				typeName = typeName.Replace("Model", string.Empty);
				var type = Type.GetType(typeName);
				if (type != null)
				{
					rootFrame.Navigate(type, parameter);
				}
			}
		}
	}
}