using System.Windows;

namespace EvilBaschdi.Core.Wpf;

/// <summary>
///     Interface for classes that handle the l on wpf.
/// </summary>
public interface IApplicationLayout :
    IRunFor<(bool Center, bool ResizeWithBorder400)>,
    IRunFor<(Window Window, bool Center, bool ResizeWithBorder400)>
{
}