using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Domain.Entities.Common;
using Sales.Domain.Exceptions;
using Sales.Domain.Properties;

namespace Sales.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Sale()
        {

        }

        
        public decimal Total { get; set ; }
        public IEnumerable<SalesItem> SalesItem { get; set; }
        public Seller Seller { get; set; }
        public int SellerId { get; set; }

        public sealed override bool IsValid()
        {
            if (SellerId == 0)
                throw new CustomValidationException(DomainValidationMessages.SellerNotInformed);
            
            if (!SalesItem.Any())
                throw new CustomValidationException(DomainValidationMessages.SaleWithouItems);

            if (Total <= 0)
                throw new CustomValidationException(DomainValidationMessages.PriceInvalid);

            return true;
        }
    }
}
