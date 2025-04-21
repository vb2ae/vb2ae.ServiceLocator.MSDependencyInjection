using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using vb2ae.ServiceLocator.MSDependencyInjection.Tests.Models;
using Xunit.Sdk;
using Xunit.v3;
[assembly: CaptureConsole]
[assembly: TestPipelineStartup(typeof(vb2ae.ServiceLocator.MSDependencyInjection.Tests.Setup))]
namespace vb2ae.ServiceLocator.MSDependencyInjection.Tests
{
    public class Setup : ITestPipelineStartup
    {
        private readonly IHostBuilder _defaultBuilder = Host.CreateDefaultBuilder();
        private IServiceProvider _services;

        public Setup()
        {
            Console.WriteLine("Setup");
        }

        public async ValueTask StartAsync(IMessageSink diagnosticMessageSink)
        {
            Console.WriteLine("StartAsync");
            _services = Build();
            await Task.CompletedTask; // This method is required by the interface but can be empty in this case.
        }

        public async ValueTask StopAsync()
        {
            await Task.CompletedTask; // This method is required by the interface but can be empty in this case.
        }

        private IServiceProvider Build()
        {
            Console.WriteLine("Adding Services to Dependency Injection.");
            _defaultBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IService, ServiceImpl>();
                services.AddTransient<ICar, Ford>();
                services.AddTransient<ICar, Toyota>();
                services.AddTransient<ICar, Chevy>();
                services.AddKeyedTransient<IPet, Dog>("Dog");
                services.AddKeyedTransient<IPet, Cat>("Cat");
            });

            _services = _defaultBuilder.Build().Services;
            CommonServiceLocator.ServiceLocator.SetLocatorProvider(() => new vb2ae.ServiceLocator.MSDependencyInjection.MSDependencyInjectionServiceLocator(_services));
            return _services;
        }
    }
}
