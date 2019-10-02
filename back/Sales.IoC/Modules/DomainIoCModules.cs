using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Sales.Domain.Services.ValidationServices;
using Sales.Domain.Services.ValidationServices.Common;
using Sales.Domain.Services.ValidationServices.Interface;

namespace Sales.IoC.Modules
{
    public class DomainIoCModules
    {
        public DomainIoCModules(IServiceCollection services)
        {
            services.AddScoped<ISalesValidationBeforePersist, SalesValidationBeforePersist>();
            services.AddScoped<IProductValidationBeforePersist, ProductValidationBeforePersist>();
            services.AddScoped<ISellerValidationBeforePersist, SellerValidationBeforePersist>();
        }
    }
}
