using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Browsers;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.Browsers
{
    public class NetworkBrowserTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(NetworkBrowser).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(NetworkBrowser sut)
        {
            sut.Should().BeAssignableTo<INetworkBrowser>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(NetworkBrowser).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}