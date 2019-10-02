using System;
using Microsoft.Extensions.DependencyInjection;
using Sales.IoC.Modules;

namespace Sales.IoC
{
    public static class InjectionContainer
    {
        public static void DoInjection(IServiceCollection services)
        {
            _ = new RepositoryIoCModule(services);
            _ = new DomainIoCModules(services);
            _ = new ApplicationIoCModule(services);
        }
    }
}
