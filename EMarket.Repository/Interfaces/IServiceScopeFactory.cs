using System;
using System.Collections.Generic;

namespace EMarket.Repository
{
    public interface IServiceScopeFactory<T> where T : class
    {
        IServiceScope<T> CreateScope();
    }

    public interface IServiceScope<T> : IDisposable where T : class
    {
        T GetRequiredService();
        T GetService();
        IEnumerable<T> GetServices();
    }

}
