using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.CoreExtended.AppHelpers;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.CoreExtended.Tests.AppHelpers;

public class AutoStartTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AutoStart).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AutoStart sut)
    {
        sut.Should().BeAssignableTo<IAutoStart>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AutoStart).GetMethods().Where(method => !method.IsAbstract));
    }
}