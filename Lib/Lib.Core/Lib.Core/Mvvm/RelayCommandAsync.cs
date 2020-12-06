using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lib.Core.Mvvm
{
    public class RelayCommandAsync : ICommand
    {
        private readonly Func<object, Task> _executeAsync;
        private readonly Predicate<object> _canExecute;

        public RelayCommandAsync(Func<Task> execute)
            : this(_ => execute())
        {
        }

        public RelayCommandAsync(Func<Task> execute, Func<bool> predicate)
            : this(_ => execute(), _ => predicate())
        {
        }

        public RelayCommandAsync(Func<object, Task> execute)
            : this(execute, null)
        {
        }

        public RelayCommandAsync(Func<object, Task> execute, Predicate<object> canExecute)
        {
            _executeAsync = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                ExecuteAsync(parameter);
            }
        }

        public Task ExecuteAsync(object parameter)
        {
            if (CanExecute(parameter))
            {
                return _executeAsync(parameter);
            }

            return Task.FromResult(true);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, System.EventArgs.Empty);
        }
    }

    public class RelayCommandAsync<T> : ICommand
        where T : class
    {
        private readonly Func<T, Task> _executeAsync;
        private readonly Predicate<object> _canExecute;

        public RelayCommandAsync(Func<T, Task> execute)
            : this(execute, null)
        {
        }

        public RelayCommandAsync(Func<T, Task> execute, Predicate<object> canExecute)
        {
            _executeAsync = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                ExecuteAsync(parameter);
            }
        }

        public Task ExecuteAsync(object parameter)
        {
            if (CanExecute(parameter))
            {
                return _executeAsync(parameter as T);
            }

            return Task.FromResult(true);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, System.EventArgs.Empty);
        }
    }
}