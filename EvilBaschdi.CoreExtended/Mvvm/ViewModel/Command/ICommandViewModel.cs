using System.Windows;
using System.Windows.Input;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command
{
    /// <summary>
    ///     Container for CommandViewmodel.
    /// </summary>
    public interface ICommandViewModel
    {
        /// <summary>
        ///     Displaytext from command.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        ///     Imagepath if available.
        /// </summary>
        string ImagePath { get; set; }

        /// <summary>
        ///     Command to execute.
        /// </summary>
        ICommand Command { get; set; }

        /// <summary>
        ///     Acutal visibility.
        /// </summary>
        Visibility Visibility { get; set; }
    }
}