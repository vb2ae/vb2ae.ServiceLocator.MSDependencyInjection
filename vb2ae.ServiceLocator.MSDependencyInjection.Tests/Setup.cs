using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace vb2ae.ServiceLocator.MSDependencyInjection.Tests
{
    public class Setup : Xunit.Di.Setup
    {
        private readonly IHostBuilder _defaultBuilder;
        private IServiceProvider _services;
        private bool _built = false;

        public Setup()
        {
            _defaultBuilder = Host.CreateDefaultBuilder();
            _services = Build();
        }
        private IServiceProvider Build()
        {
            if (_built)
                throw new InvalidOperationException("Build can only be called once.");
            _built = true;

            _defaultBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IService, ServiceImpl>();
                // where ServiceImpl implements IService
                // ... add other services when needed
            });

            _services = _defaultBuilder.Build().Services;
            CommonServiceLocator.ServiceLocator.SetLocatorProvider(() => new vb2ae.ServiceLocator.MSDependencyInjection.MSDependencyInjectionServiceLocator(_services));
            return _services;
        }
    }
}
