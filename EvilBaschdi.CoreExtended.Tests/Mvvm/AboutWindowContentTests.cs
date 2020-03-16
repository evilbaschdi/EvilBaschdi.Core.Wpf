using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Mvvm;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.Mvvm
{
    public class AboutWindowContentTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AboutWindowContent).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(AboutWindowContent sut)
        {
            sut.Should().BeAssignableTo<IAboutWindowContent>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AboutWindowContent).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}