using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Metro;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.Metro
{
    public class ApplicationStyleSettingsTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ApplicationStyleSettings).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(ApplicationStyleSettings sut)
        {
            sut.Should().BeAssignableTo<IApplicationStyleSettings>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ApplicationStyleSettings).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}