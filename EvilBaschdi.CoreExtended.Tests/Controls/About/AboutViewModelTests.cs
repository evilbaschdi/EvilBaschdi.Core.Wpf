using EvilBaschdi.CoreExtended.Controls.About;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel;

namespace EvilBaschdi.CoreExtended.Tests.Controls.About
{
    public class AboutViewModelTests
    {
        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AboutViewModel).GetConstructors());
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Constructor_ReturnsInterfaceName(AboutViewModel sut)
        {
            sut.Should().BeAssignableTo<IAboutModel>();
            sut.Should().BeAssignableTo<ApplicationStyleViewModel>();
        }

        [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
        public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AboutViewModel).GetMethods().Where(method => !method.IsAbstract));
        }
    }
}