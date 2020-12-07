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
        ///     Command to execute.
        /// </summary>
        // ReSharper disable UnusedMemberInSuper.Global
        ICommand Command { get; set; }
        // ReSharper restore UnusedMemberInSuper.Global

        /// <summary>
        ///     ImagePath if available.
        /// </summary>
        // ReSharper disable UnusedMember.Global
        string ImagePath { get; set; }
        // ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Display text from command.
        /// </summary>
        // ReSharper disable UnusedMember.Global
        string Text { get; set; }
        // ReSharper restore UnusedMember.Global

        /// <summary>
        ///     Actual visibility.
        /// </summary>
        // ReSharper disable UnusedMember.Global
        Visibility Visibility { get; set; }
        // ReSharper restore UnusedMember.Global
    }
}