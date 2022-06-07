using EvilBaschdi.Core;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;

/// <inheritdoc cref="IDefaultCommand" />
/// <inheritdoc cref="ITaskValue" />
// ReSharper disable once UnusedType.Global
public interface IDefaultCommandRunAsync : IDefaultCommand, ITaskValue
{
}