using EvilBaschdi.Core.Wpf.AppHelpers;

namespace EvilBaschdi.Core.Wpf.Tests.AppHelpers;

public class ScreenShotTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ScreenShot).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(ScreenShot sut)
    {
        sut.Should().BeAssignableTo<IScreenShot>();
    }

    //[Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    //public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    //{
    //    assertion.Verify(typeof(ScreenShot).GetMethods().Where(method => !method.IsAbstract));
    //}
}