using System.ComponentModel;
using EvilBaschdi.Core.Wpf.Mvvm.ViewModel.Command;

namespace EvilBaschdi.Core.Wpf.Tests.Mvvm.ViewModel.Command;

public class DefaultCommandTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(DefaultCommand).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(DefaultCommand sut)
    {
        sut.Should().BeAssignableTo<ICommandViewModel>();
        sut.Should().BeAssignableTo<INotifyPropertyChanged>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(DefaultCommand).GetMethods()
                                               .Where(method => !method.IsAbstract & !method.Name.StartsWith("set_") & !method.Name.StartsWith("add_") &
                                                                !method.Name.StartsWith("remove_")));
    }
}