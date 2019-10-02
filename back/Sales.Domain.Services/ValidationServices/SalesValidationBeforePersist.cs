using System;
using System.ComponentModel.DataAnnotations;
using Sales.Domain.Entities;
using Sales.Domain.Properties;
using Sales.Domain.Services.ValidationServices.Common;
using Sales.Domain.Services.ValidationServices.Interface;
using Sales.Infra.Repositories.Common;
using Sales.Infra.Repositories.Interfaces;

namespace Sales.Domain.Services.ValidationServices
{
    public class SalesValidationBeforePersist : ValidationBeforePersist<Sale>, ISalesValidationBeforePersist
    {
  
        public override bool CanPersist(Sale entity)
        {
            base.CanPersist(entity);
                        
            return true;
        }
    }
}
