using EvilBaschdi.CoreExtended.AppHelpers;

namespace EvilBaschdi.CoreExtended.Tests.AppHelpers;

public class AppSettingsBaseTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppSettingsBase).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AppSettingsBase sut)
    {
        sut.Should().BeAssignableTo<IAppSettingsBase>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppSettingsBase).GetMethods().Where(method => !method.IsAbstract));
    }
}