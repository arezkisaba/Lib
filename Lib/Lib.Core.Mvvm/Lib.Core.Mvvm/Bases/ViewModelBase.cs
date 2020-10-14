using System.Threading.Tasks;
using System.Windows.Input;

namespace Lib.Core.Mvvm
{
    public abstract class ViewModelBase : BindableBase
	{
        private INavigationService _navigationService;

        private ICommand _goBackCommand;
        public ICommand GoBackCommand
		{
			get
			{
				if (_goBackCommand == null)
				{
					_goBackCommand = new RelayCommand(obj => GoBack());
				}

				return _goBackCommand;
			}
		}

        private bool _isLoadingBackground;
        public bool IsLoadingBackground
		{
			get { return _isLoadingBackground; }
			set
			{
				_isLoadingBackground = value;
				NotifyPropertyChanged();
			}
		}

        private bool _isNetworkAvailable;
        public bool IsNetworkAvailable
		{
			get { return _isNetworkAvailable; }
			set
			{
				_isNetworkAvailable = value;
				NotifyPropertyChanged();
			}
		}

        public ViewModelBase()
        {
            _navigationService = DependencyInjector.Instance.Resolve<INavigationService>();
        }

		public void GoBack()
		{
            _navigationService.GoBack();
		}

		public virtual Task OnLoadedAsync(object parameter)
		{
            return Task.CompletedTask;
		}

		public virtual Task OnNavigatedFromAsync()
        {
            return Task.CompletedTask;
        }

		public virtual Task OnNavigatedToAsync(NavigationMode navigationMode, object parameter)
        {
            return Task.CompletedTask;
        }

		public virtual void OnNetworkConnected()
		{
			IsNetworkAvailable = true;
		}

		public virtual void OnNetworkDisconnected()
		{
			IsNetworkAvailable = false;
		}

		public virtual void OnScreenOrientationLandscape()
		{
		}

		public virtual void OnScreenOrientationPortrait()
		{
		}
    }
}