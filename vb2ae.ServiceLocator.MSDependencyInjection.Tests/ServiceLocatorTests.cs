using Microsoft.Extensions.DependencyInjection;
using vb2ae.ServiceLocator.MSDependencyInjection.Tests.Models;

namespace vb2ae.ServiceLocator.MSDependencyInjection.Tests
{
    public class MSDependencyInjectionServiceLocatorTests
    {
        private readonly IServiceProvider _serviceProvider;

        public MSDependencyInjectionServiceLocatorTests(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [Fact]
        public void GetAllInstances_Type_ReturnsInstances()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetAllInstances(typeof(IService));

            Assert.Single(result);
        }
        [Fact]
        public void GetAllInstances_Type_ReturnsInstancesWhenKeyIsUsed()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetAllInstances(typeof(IPet));

            Assert.Equal(2, result.Count());
        }
        [Fact]
        public void GetAllInstances_Generic_ReturnsInstances()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetAllInstances<ICar>();

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void GetAllInstances_Generic_ReturnsInstancesWithKey()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetAllInstances<IPet>();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetInstance_Type_ReturnsInstance()
        {
            var serviceType = typeof(IService);

            var result = CommonServiceLocator.ServiceLocator.Current.GetInstance(serviceType);

            Assert.True(result is ServiceImpl);
        }

        [Fact]
        public void GetInstance_Type_WithKey()
        {
            var serviceType = typeof(IPet);
            var key = "Cat";

            Assert.True(CommonServiceLocator.ServiceLocator.Current.GetInstance(serviceType, key) is Cat);
        }

        [Fact]
        public void GetInstance_Generic_ReturnsInstance()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetInstance<IService>();

            Assert.True(result is IService);
        }

        [Fact]
        public void GetInstance_Generic_WithKey()
        {
            var key = "Dog";

            Assert.True(CommonServiceLocator.ServiceLocator.Current.GetInstance<IPet>(key) is Dog);
        }

        [Fact]
        public void GetService_Generic_ReturnsService()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetService<IService>();

            Assert.True(result is IService);
        }

        [Fact]
        public void GetService_Type_ReturnsService()
        {
            var serviceType = typeof(IService);

            var result = CommonServiceLocator.ServiceLocator.Current.GetService(serviceType);

            Assert.True(result is IService);
        }
    }
}
