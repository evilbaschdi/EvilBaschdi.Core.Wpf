using System.Diagnostics;
using EvilBaschdi.Core;

namespace EvilBaschdi.CoreExtended.AppHelpers;

/// <inheritdoc cref="IValueFor{TIn,TOut}" />
/// <inheritdoc cref="IRunFor{TIn}" />
public interface IProcessByPath : IValueFor<string, Process>, IRunFor<string>
{
}