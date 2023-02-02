using EvilBaschdi.Core.Wpf.AppHelpers;

namespace EvilBaschdi.Core.Wpf.Tests.AppHelpers;

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