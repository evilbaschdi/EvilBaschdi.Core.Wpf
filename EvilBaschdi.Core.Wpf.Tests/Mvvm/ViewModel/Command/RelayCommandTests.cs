using System.Windows.Input;
using EvilBaschdi.Core.Wpf.Mvvm.ViewModel.Command;

namespace EvilBaschdi.Core.Wpf.Tests.Mvvm.ViewModel.Command;

public class RelayCommandTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(RelayCommand).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(RelayCommand sut)
    {
        sut.Should().BeAssignableTo<ICommand>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(RelayCommand).GetMethods().Where(method => !method.IsAbstract & !method.Name.StartsWith("add_") & !method.Name.StartsWith("remove_") &
                                                                           !method.Name.StartsWith("CanExecute") & !method.Name.StartsWith("Execute")));
    }
}