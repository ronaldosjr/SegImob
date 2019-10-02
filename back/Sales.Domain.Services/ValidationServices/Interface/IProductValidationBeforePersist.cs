using System;
using System.Collections.Generic;
using System.Text;
using Sales.Domain.Entities;
using Sales.Domain.Services.ValidationServices.Common;

namespace Sales.Domain.Services.ValidationServices.Interface
{
    public interface IProductValidationBeforePersist : IValidationBeforePersist<Product>
    {
    }
}
