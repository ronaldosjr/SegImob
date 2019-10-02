using System;
using System.Collections.Generic;
using Sales.Domain.Entities.Common;
using Sales.Domain.Exceptions;
using Sales.Domain.Properties;

namespace Sales.Domain.Entities
{
    public class Product : BaseEntity
    {
        public const int NAME_LENGTH = 255;
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<SalesItem> SalesItem { get; set; }

        public Product()
        {

        }

        
        public sealed override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new CustomValidationException(DomainValidationMessages.NameCantBeNull);

            if (Name.Trim().Length > NAME_LENGTH)
                throw new CustomValidationException(DomainValidationMessages.NameTooLong);

            if (Price <= 0)
                throw new CustomValidationException(DomainValidationMessages.PriceInvalid);

            return true;
        }

      
        
    }
}
