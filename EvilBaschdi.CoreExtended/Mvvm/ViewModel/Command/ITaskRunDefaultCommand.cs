using EvilBaschdi.Core;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command
{
    /// <inheritdoc cref="IDefaultCommand" />
    /// <inheritdoc cref="IRunTask" />
    // ReSharper disable once UnusedType.Global
    public interface ITaskRunDefaultCommand : IDefaultCommand, IRunTask
    {
    }
}