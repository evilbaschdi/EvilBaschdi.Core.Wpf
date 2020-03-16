using System.ComponentModel;
using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.Mvvm.ViewModel
{
    public class ApplicationStyleViewModelTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ApplicationStyleViewModel).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(ApplicationStyleViewModel sut)
        {
            sut.Should().BeAssignableTo<INotifyPropertyChanged>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ApplicationStyleViewModel).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}