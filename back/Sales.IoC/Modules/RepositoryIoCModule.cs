using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Sales.Infra.Context;
using Sales.Infra.Repositories;
using Sales.Infra.Repositories.Common;
using Sales.Infra.Repositories.Interfaces;

namespace Sales.IoC.Modules
{
    public class RepositoryIoCModule
    {
        public RepositoryIoCModule(IServiceCollection services)
        {
            services.AddScoped<IConnection, Connection>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<IProductRepostitory, ProductRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();

        }
    }
}
