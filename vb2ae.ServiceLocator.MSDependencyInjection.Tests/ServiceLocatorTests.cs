using Microsoft.Extensions.DependencyInjection;
using vb2ae.ServiceLocator.MSDependencyInjection.Tests.Models;
using vb2ae.ServiceLocator.MSDependencyInjection.Tests.Models.Orderers;
namespace vb2ae.ServiceLocator.MSDependencyInjection.Tests
{
    [TestCaseOrderer(typeof(PriorityOrderer))]
    public class MSDependencyInjectionServiceLocatorTests
    {
        public MSDependencyInjectionServiceLocatorTests()
        {
        }

        [Fact]
        [TestPriority(13)]
        public void GetAllInstances_Type_ReturnsInstances()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetAllInstances(typeof(IService));

            Assert.Single(result);
        }
        [Fact]
        [TestPriority(1)]
        public void GetAllInstances_Type_ReturnsInstancesWhenKeyIsUsed()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetAllInstances(typeof(IPet));
            foreach (var item in result)
            {
                Console.WriteLine(item.GetType().Name);
            }
            Assert.Equal(2, result.Count());
        }
        [Fact]
        [TestPriority(2)]
        public void GetAllInstances_Generic_ReturnsInstances()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetAllInstances<ICar>();

            Assert.Equal(3, result.Count());
        }

        [Fact]
        [TestPriority(3)]
        public void GetAllInstances_Generic_ReturnsInstancesWithKey()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetAllInstances<IPet>();
            foreach (var item in result)
            {
                Console.WriteLine(item.GetType().Name);
            }
            Assert.Equal(2, result.Count());
        }

        [Fact]
        [TestPriority(4)]
        public void GetInstance_Type_ReturnsInstance()
        {
            var serviceType = typeof(IService);

            var result = CommonServiceLocator.ServiceLocator.Current.GetInstance(serviceType);

            Assert.True(result is ServiceImpl);
        }

        [Fact]
        [TestPriority(5)]
        public void GetInstance_Type_WithKey()
        {
            var serviceType = typeof(IPet);
            var key = "Cat";

            Assert.True(CommonServiceLocator.ServiceLocator.Current.GetInstance(serviceType, key) is Cat);
        }

        [Fact]
        [TestPriority(6)]
        public void GetInstance_Type_WithNullKey()
        {
            var serviceType = typeof(IPet);

            Assert.True(CommonServiceLocator.ServiceLocator.Current.GetInstance(serviceType, null) is IPet);
        }

        [Fact]
        [TestPriority(7)]
        public void GetInstance_Generic_ReturnsInstance()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetInstance<IService>();

            Assert.True(result is IService);
        }

        [Fact]
        [TestPriority(8)]
        public void GetInstance_Generic_WithKey()
        {
            var key = "Dog";

            Assert.True(CommonServiceLocator.ServiceLocator.Current.GetInstance<IPet>(key) is Dog);
        }

        [Fact]
        [TestPriority(9)]
        public void GetInstance_Generic_WithNullKey()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPet>(null);
            Assert.True(result is IPet);
        }

        [Fact]
        [TestPriority(10)]
        public void GetInstance_Generic_WithNullKey_NotRegisterClass()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetInstance<IAmNotUsed>(null);
            Assert.True(result is null);
        }
        [Fact]
        [TestPriority(11)]
        public void GetService_Generic_ReturnsService()
        {
            var result = CommonServiceLocator.ServiceLocator.Current.GetService<IService>();

            Assert.True(result is IService);
        }

        [Fact]
        [TestPriority(12)]
        public void GetService_Type_ReturnsService()
        {
            var serviceType = typeof(IService);

            var result = CommonServiceLocator.ServiceLocator.Current.GetService(serviceType);

            Assert.True(result is IService);
        }
    }
}
