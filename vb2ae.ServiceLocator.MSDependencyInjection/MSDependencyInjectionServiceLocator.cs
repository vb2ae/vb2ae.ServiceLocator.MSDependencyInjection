using CommonServiceLocator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace vb2ae.ServiceLocator.MSDependencyInjection
{
    public class MSDependencyInjectionServiceLocator : IServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public MSDependencyInjectionServiceLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return _serviceProvider.GetServices<TService>();
        }

        public object GetInstance(Type serviceType)
        {
            return _serviceProvider.GetRequiredService(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            // Microsoft.Extensions.DependencyInjection does not support keyed services out of the box.
            // You might need to implement a custom logic or use a third-party library for this.
            throw new NotSupportedException("Keyed services are not supported.");
        }

        public TService GetInstance<TService>()
        {
            return _serviceProvider.GetRequiredService<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            // Microsoft.Extensions.DependencyInjection does not support keyed services out of the box.
            // You might need to implement a custom logic or use a third-party library for this.
            throw new NotSupportedException("Keyed services are not supported.");
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }
    }
}

