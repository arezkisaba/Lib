using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Linq.Expressions;

namespace Lib.Core.Mvvm
{
    [Serializable]
    public abstract class BindableBase : INotifyPropertyChanged
    {
        private Guid _id = Guid.NewGuid();
        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged(nameof(Id));
            }
        }

        private int _index;
        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                NotifyPropertyChanged(nameof(Index));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                NotifyPropertyChanged(nameof(IsLoading));
            }
        }

        private bool _isLoadingInBackground;
        public bool IsLoadingInBackground
        {
            get { return _isLoadingInBackground; }
            set
            {
                _isLoadingInBackground = value;
                NotifyPropertyChanged(nameof(IsLoadingInBackground));
            }
        }

        private string _loadingText;
        public string LoadingText
        {
            get { return _loadingText; }
            set
            {
                _loadingText = value;
                NotifyPropertyChanged(nameof(LoadingText));
            }
        }

        private bool _isSelected;
        public bool IsSelected
		{
			get { return _isSelected; }
			set
			{
				_isSelected = value;
				NotifyPropertyChanged(nameof(IsSelected));
			}
		}

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void NotifyPropertyChanged<T>(Expression<Func<T>> selectorExpression)
        {
            if (selectorExpression == null)
            {
                throw new ArgumentNullException("selectorExpression");
            }

            var body = selectorExpression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("The body must be a member expression");
            }

            NotifyPropertyChanged(body.Member.Name);
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            NotifyPropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> selectorExpression)
        {
            NotifyPropertyChanged(selectorExpression);
        }

        #endregion
    }

    public abstract class BindableBase<T> : BindableBase
	{
		private T _obj;

		public T Obj
		{
			get { return _obj; }
			set
			{
				_obj = value;
				NotifyPropertyChanged();
			}
		}

		protected BindableBase()
		{
		}

		protected BindableBase(T obj)
		{
			Obj = obj;
		}
	}
}