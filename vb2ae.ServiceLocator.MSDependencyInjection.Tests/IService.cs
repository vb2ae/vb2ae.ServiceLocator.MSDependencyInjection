namespace vb2ae.ServiceLocator.MSDependencyInjection.Tests
{
    public interface IService
    {
        void DoSomething();
    }

    public class ServiceImpl : IService
    {
        public void DoSomething()
        {
            // do something
        }
    }
}
