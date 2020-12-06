using Lib.Core;
using Lib.Core.Mvvm;
using System.ComponentModel;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Lib.Uwp.Mvvm
{
    public abstract class ViewBase : Page
	{
		private bool _isLoaded;
        protected IDispatcherService _dispatcherService;

        public ViewModelBase ViewModelBase => (ViewModelBase)DataContext;
        
        protected ViewBase()
		{
            _dispatcherService = DependencyInjector.Instance.Resolve<IDispatcherService>();
            SizeChanged += ViewBase_SizeChanged;
		}

		protected override async void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);
			NetworkInformation.NetworkStatusChanged -= ViewBase_NetworkStatusChanged;

			if (BottomAppBar != null)
			{
				BottomAppBar.Visibility = Visibility.Collapsed;
			}

			if (TopAppBar != null)
			{
				TopAppBar.Visibility = Visibility.Collapsed;
			}

			if (ViewModelBase != null)
			{
				ViewModelBase.PropertyChanged -= ViewModel_PropertyChanged;
				await ViewModelBase.OnNavigatedFromAsync();
			}
		}

		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			NetworkInformation.NetworkStatusChanged += ViewBase_NetworkStatusChanged;
			await _dispatcherService.RunAsync(HandleNetworkStatus);

			if (ViewModelBase != null)
			{
				if (!_isLoaded)
				{
					_isLoaded = true;
					await ViewModelBase.OnLoadedAsync(e.Parameter);
				}

				if (!ViewModelBase.IsLoading)
				{
					if (BottomAppBar != null)
					{
						BottomAppBar.Visibility = Visibility.Visible;
					}

					if (TopAppBar != null)
					{
						TopAppBar.Visibility = Visibility.Visible;
					}
				}

				var navigationMode = Core.NavigationMode.New;
				switch (e.NavigationMode)
				{
					case Windows.UI.Xaml.Navigation.NavigationMode.Back:
						navigationMode = Core.NavigationMode.Back;
						break;
					case Windows.UI.Xaml.Navigation.NavigationMode.Forward:
						navigationMode = Core.NavigationMode.Forward;
						break;
					case Windows.UI.Xaml.Navigation.NavigationMode.New:
						navigationMode = Core.NavigationMode.New;
						break;
					case Windows.UI.Xaml.Navigation.NavigationMode.Refresh:
						navigationMode = Core.NavigationMode.Refresh;
						break;
				}

				ViewModelBase.PropertyChanged += ViewModel_PropertyChanged;
				await ViewModelBase.OnNavigatedToAsync(navigationMode, e.Parameter);
			}
		}

		protected virtual void OnNetworkConnected()
		{
			if (ViewModelBase != null)
			{
				ViewModelBase.OnNetworkConnected();
			}
		}

		protected virtual void OnNetworkDisconnected()
		{
			if (ViewModelBase != null)
			{
				ViewModelBase.OnNetworkDisconnected();
			}
		}

		protected virtual void OnScreenOrientationLandscape()
		{
			if (ViewModelBase != null)
			{
				ViewModelBase.OnScreenOrientationLandscape();
			}
		}

		protected virtual void OnScreenOrientationPortrait()
		{
			if (ViewModelBase != null)
			{
				ViewModelBase.OnScreenOrientationPortrait();
			}
		}

		private void HandleNetworkStatus()
		{
			var profile = NetworkInformation.GetInternetConnectionProfile();
			var isNetworkAvailable = (profile != null && profile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
			if (isNetworkAvailable)
			{
				OnNetworkConnected();
			}
			else
			{
				OnNetworkDisconnected();
			}
		}

		private void HandleScreenOrientation()
		{
			if (DisplayHelper.IsLandscape())
			{
				OnScreenOrientationLandscape();
			}
			if (DisplayHelper.IsPortrait())
			{
				OnScreenOrientationPortrait();
			}
		}

		private async void ViewBase_NetworkStatusChanged(object sender)
		{
			await _dispatcherService.RunAsync(HandleNetworkStatus);
		}

		private async void ViewBase_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			await _dispatcherService.RunAsync(HandleScreenOrientation);
		}

		private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsLoading")
			{
				if (ViewModelBase.IsLoading)
				{
					if (BottomAppBar != null)
					{
						BottomAppBar.Visibility = Visibility.Collapsed;
					}

					if (TopAppBar != null)
					{
						TopAppBar.Visibility = Visibility.Collapsed;
					}
				}
				else
				{
					if (BottomAppBar != null)
					{
						BottomAppBar.Visibility = Visibility.Visible;
					}

					if (TopAppBar != null)
					{
						TopAppBar.Visibility = Visibility.Visible;
					}
				}
			}
		}
	}
}