using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.AppHelpers;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.AppHelpers;

public class AutoStartByConfigurationTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AutoStartByConfiguration).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AutoStartByConfiguration sut)
    {
        sut.Should().BeAssignableTo<IAutoStartByConfiguration>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AutoStartByConfiguration).GetMethods().Where(method => !method.IsAbstract));
    }
}