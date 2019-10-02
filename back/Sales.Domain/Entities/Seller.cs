using Sales.Domain.Entities.Common;
using Sales.Domain.Exceptions;
using Sales.Domain.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Entities
{
    public class Seller : BaseEntity
    {
        public const int NAME_LENGTH = 255;
        public const decimal COMMISSION = 0.05m;
        public string Name { get; set; }
        public IEnumerable<Sale> Sales { get; set; }

        public Seller()
        {

        }

        public Seller(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Length > NAME_LENGTH)
                throw new CustomValidationException(DomainValidationMessages.NameTooLong);

            return true;
        }
    }
}
