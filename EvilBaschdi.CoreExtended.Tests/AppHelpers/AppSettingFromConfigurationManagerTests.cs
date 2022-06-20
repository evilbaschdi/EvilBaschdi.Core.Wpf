using EvilBaschdi.CoreExtended.AppHelpers;

namespace EvilBaschdi.CoreExtended.Tests.AppHelpers;

public class AppSettingFromConfigurationManagerTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppSettingFromConfigurationManager).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AppSettingFromConfigurationManager sut)
    {
        sut.Should().BeAssignableTo<IAppSettingFromConfigurationManager>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(
            typeof(AppSettingFromConfigurationManager).GetMethods().Where(method => !method.IsAbstract));
    }
}