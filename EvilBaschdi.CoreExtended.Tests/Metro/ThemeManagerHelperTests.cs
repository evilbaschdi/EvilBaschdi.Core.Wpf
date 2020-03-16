using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Metro;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.Metro
{
    public class ThemeManagerHelperTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ThemeManagerHelper).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(ThemeManagerHelper sut)
        {
            sut.Should().BeAssignableTo<IThemeManagerHelper>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ThemeManagerHelper).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}