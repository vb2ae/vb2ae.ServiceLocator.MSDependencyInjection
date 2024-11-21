# vb2ae.ServiceLocator.MSDependencyInjection
[![.NET](https://github.com/vb2ae/vb2ae.ServiceLocator.MSDependencyInjection/actions/workflows/dotnet.yml/badge.svg)](https://github.com/vb2ae/vb2ae.ServiceLocator.MSDependencyInjection/actions/workflows/dotnet.yml)

[![CodeQL](https://github.com/vb2ae/vb2ae.ServiceLocator.MSDependencyInjection/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/vb2ae/vb2ae.ServiceLocator.MSDependencyInjection/actions/workflows/github-code-scanning/codeql)

[![Dependabot Updates](https://github.com/vb2ae/vb2ae.ServiceLocator.MSDependencyInjection/actions/workflows/dependabot/dependabot-updates/badge.svg)](https://github.com/vb2ae/vb2ae.ServiceLocator.MSDependencyInjection/actions/workflows/dependabot/dependabot-updates)

The purpose of this class library is to be able to use Microsoft.Extensions.DependencyInjection with the common service locator.



## example 
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
