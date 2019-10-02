using Sales.Domain.Entities.Common;
using Sales.Domain.Exceptions;
using Sales.Domain.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Entities
{
    public class SalesItem : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }   
        public Sale Sales { get; set; }
        public int SalesId { get; set; }
        public decimal Total { get; set; }

        public SalesItem()
        {

        }

        
        
        public override bool IsValid()
        {
            if (Product == null)
                throw new CustomValidationException(DomainValidationMessages.ProductNotFound);

            if (Amount <= 0)
                throw new CustomValidationException(DomainValidationMessages.InvalidAmount);

            return true;
        }
    }
}
