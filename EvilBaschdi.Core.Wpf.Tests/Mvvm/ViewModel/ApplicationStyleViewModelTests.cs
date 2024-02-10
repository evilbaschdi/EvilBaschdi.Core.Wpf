using System.ComponentModel;
using EvilBaschdi.Core.Wpf.Mvvm.ViewModel;

namespace EvilBaschdi.Core.Wpf.Tests.Mvvm.ViewModel;

public class ApplicationStyleViewModelTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ApplicationLayoutViewModel).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(ApplicationLayoutViewModel sut)
    {
        sut.Should().BeAssignableTo<INotifyPropertyChanged>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ApplicationLayoutViewModel).GetMethods().Where(method => !method.IsAbstract));
    }
}