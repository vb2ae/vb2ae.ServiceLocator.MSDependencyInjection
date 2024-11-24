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
            var allServices = new List<object>();
            var services = _serviceProvider.GetServices(serviceType);
            if (services != null)
            {
                allServices.AddRange(services);
            }
            var keyedServices = _serviceProvider.GetKeyedServices(serviceType, KeyedService.AnyKey);
            if (keyedServices != null)
            {
                allServices.AddRange(keyedServices);
            }
            return allServices;
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            var allServices = new List<TService>();
            var services = _serviceProvider.GetServices<TService>();
            if (services != null)
            {
                allServices.AddRange(services);
            }
            var keyedServices = _serviceProvider.GetKeyedServices<TService>(KeyedService.AnyKey);
            if (keyedServices != null)
            {
                allServices.AddRange(keyedServices);
            }
            return allServices;
        }

        public object GetInstance(Type serviceType)
        {
            return _serviceProvider.GetRequiredService(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            // Microsoft.Extensions.DependencyInjection does not support keyed services out of the box.
            // You might need to implement a custom logic or use a third-party library for this.
            return _serviceProvider.GetRequiredKeyedService(serviceType, key);
        }

        public TService GetInstance<TService>()
        {
            return _serviceProvider.GetRequiredService<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            return _serviceProvider.GetKeyedService<TService>(key);
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

