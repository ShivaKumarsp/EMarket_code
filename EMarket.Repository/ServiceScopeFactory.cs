using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace EMarket.Repository
{
    public class ServiceScopeFactory<T> : IServiceScopeFactory<T> where T : class
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ServiceScopeFactory(IServiceScopeFactory serviceScopeFactory) => _serviceScopeFactory = serviceScopeFactory;

        public IServiceScope<T> CreateScope() => new ServiceScope<T>(_serviceScopeFactory.CreateScope());
    }

    public class ServiceScope<T> : IServiceScope<T> where T : class
    {
        readonly IServiceScope _scope;

        public ServiceScope(IServiceScope scope) => _scope = scope;

        public T GetRequiredService() => _scope.ServiceProvider.GetRequiredService<T>();

        public T GetService() => _scope.ServiceProvider.GetService<T>();

        public IEnumerable<T> GetServices() => _scope.ServiceProvider.GetServices<T>();


        #region IDisposable/Dispose methods ( https://stackoverflow.com/a/538238/530545 )
        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool calledFromCodeNotTheGarbageCollector)
        {
            if (_disposed)
                return;
            if (calledFromCodeNotTheGarbageCollector)
            {
                // dispose of manged resources in here
                _scope?.Dispose();
            }
            _disposed = true;
        }

        ~ServiceScope() { Dispose(false); }
        #endregion

    }
}
