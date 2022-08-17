using EvilBaschdi.CoreExtended.Controls.About;

namespace EvilBaschdi.CoreExtended.Tests.Controls.About
{
    public class AboutModelTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AboutModel).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(AboutModel sut)
        {
            sut.Should().BeAssignableTo<IAboutModel>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AboutModel).GetMethods().Where(method => !method.IsAbstract & !method.Name.StartsWith("set")));
        }
    }
}