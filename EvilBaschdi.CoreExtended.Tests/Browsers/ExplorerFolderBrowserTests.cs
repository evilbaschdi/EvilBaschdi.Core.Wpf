using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Browsers;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.Browsers
{
    public class ExplorerFolderBrowserTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ExplorerFolderBrowser).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(ExplorerFolderBrowser sut)
        {
            sut.Should().BeAssignableTo<IFolderBrowser>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(ExplorerFolderBrowser).GetMethods().Where(method => !method.IsAbstract & !method.Name.StartsWith("set_")));
        }
    }
}