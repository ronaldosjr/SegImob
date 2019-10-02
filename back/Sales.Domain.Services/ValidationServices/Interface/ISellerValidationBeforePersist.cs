using Sales.Domain.Entities;
using Sales.Domain.Services.ValidationServices.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Services.ValidationServices.Interface
{
    public interface ISellerValidationBeforePersist : IValidationBeforePersist<Seller>
    {
    }
}
