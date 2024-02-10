using System.Windows.Media;

namespace EvilBaschdi.Core.Wpf.Mvvm.ViewModel;

/// <summary>
/// </summary>
// ReSharper disable once UnusedType.Global
public class ControlContent
{
    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public Brush FillBrush { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once InconsistentNaming
    public string ImageResourceName { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once InconsistentNaming
    public int ImageSize { get; set; }
}