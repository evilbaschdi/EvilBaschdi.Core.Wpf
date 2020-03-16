using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.Metro;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.Metro
{
    public class DialogServiceTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(DialogService).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(DialogService sut)
        {
            sut.Should().BeAssignableTo<IDialogService>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(DialogService).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}