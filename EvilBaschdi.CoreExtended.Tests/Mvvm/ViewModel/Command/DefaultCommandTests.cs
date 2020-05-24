using System.ComponentModel;
using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.Mvvm.ViewModel.Command
{
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
            assertion.Verify(typeof(DefaultCommand).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}