using Sales.Domain.Entities;
using Sales.Domain.Exceptions;
using Sales.Domain.Properties;
using Sales.Domain.Services.ValidationServices.Common;
using Sales.Domain.Services.ValidationServices.Interface;
using Sales.Domain.Specification.Seller;
using Sales.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Domain.Services.ValidationServices
{
    public class SellerValidationBeforePersist : ValidationBeforePersist<Seller>, ISellerValidationBeforePersist
    {
        private readonly ISellerRepository _repository;

        public SellerValidationBeforePersist(ISellerRepository repository)
        {
            _repository = repository;
        }

        public override bool CanPersist(Seller seller)
        {
            base.CanPersist(seller);

            if (_repository.GetAsync(new SellerNameTakenSpecification(seller)).Result != null)
                throw new CustomValidationException(DomainValidationMessages.SellerAlreadyTaken);

            return true;
        }
    }
}
