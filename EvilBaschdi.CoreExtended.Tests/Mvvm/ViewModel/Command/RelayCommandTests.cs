using System.Linq;
using System.Windows.Input;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.Mvvm.ViewModel.Command;

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
        assertion.Verify(typeof(RelayCommand).GetMethods().Where(method => !method.IsAbstract & !method.Name.StartsWith("add_") & !method.Name.StartsWith("remove_")));
    }
}