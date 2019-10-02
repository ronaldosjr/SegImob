using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Services;
using Sales.Application.Services.Common;
using Sales.Application.Services.Interfaces;

namespace Sales.IoC.Modules
{
    public class ApplicationIoCModule
    {
        public ApplicationIoCModule(IServiceCollection services)
        {
            services.AddScoped<ISalesApplication, SalesApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<ISellerApplication, SellerApplication>();

        }
    }
}
