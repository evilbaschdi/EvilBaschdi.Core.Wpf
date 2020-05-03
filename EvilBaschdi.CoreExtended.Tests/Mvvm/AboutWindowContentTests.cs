using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Controls.About;
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
            assertion.Verify(typeof(AboutContent).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(AboutContent sut)
        {
            sut.Should().BeAssignableTo<IAboutContent>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AboutContent).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}