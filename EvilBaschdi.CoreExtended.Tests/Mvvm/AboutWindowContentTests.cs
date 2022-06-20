using EvilBaschdi.CoreExtended.Controls.About;

namespace EvilBaschdi.CoreExtended.Tests.Mvvm;

public class AboutContentTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AboutContent).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AboutContent sut)
    {
        sut.Should().BeAssignableTo<IAboutContent>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AboutContent).GetMethods().Where(method => !method.IsAbstract));
    }
}