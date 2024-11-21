namespace vb2ae.ServiceLocator.MSDependencyInjection.Tests
{
    public class ServiceLocatorTests
    {
        [Fact]
        public void VerifyServiceLocatorCanLoadClass()
        {
            var service = CommonServiceLocator.ServiceLocator.Current.GetInstance<IService>();
            Assert.NotNull(service);
        }
    }
}