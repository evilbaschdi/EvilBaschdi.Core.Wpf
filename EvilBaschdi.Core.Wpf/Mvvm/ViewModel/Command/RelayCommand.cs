﻿// ReSharper disable UnusedMember.Global

using System.Windows.Input;

namespace EvilBaschdi.Core.Wpf.Mvvm.ViewModel.Command;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
/// <param name="execute"></param>
/// <param name="canExecute"></param>
/// <exception cref="ArgumentNullException"></exception>
public class RelayCommand(
    Action<object> execute,
    Predicate<object> canExecute) : ICommand
{
    private Predicate<object> _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
    private Action<object> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

    /// <summary>
    /// </summary>
    /// <param name="execute"></param>
    public RelayCommand(Action<object> execute)
        : this(execute, DefaultCanExecute)
    {
    }

    /// <summary>
    /// </summary>
    public event EventHandler CanExecuteChanged
    {
        add
        {
            if (value == null)
            {
                return;
            }

            CommandManager.RequerySuggested += value;
            CanExecuteChangedInternal += value;
        }

        remove
        {
            if (value == null)
            {
                return;
            }

            CommandManager.RequerySuggested -= value;
            CanExecuteChangedInternal -= value;
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    /// <summary>
    /// </summary>
    /// <param name="parameter"></param>
    public void Execute(object parameter)
    {
        _execute(parameter);
    }

    private event EventHandler CanExecuteChangedInternal;

    /// <summary>
    /// </summary>
    public void OnCanExecuteChanged()
    {
        var handler = CanExecuteChangedInternal;
        //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
        handler?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// </summary>
    public void Destroy()
    {
        _canExecute = _ => false;
        _execute = _ => { };
    }

    private static bool DefaultCanExecute(object parameter)
    {
        return true;
    }
}