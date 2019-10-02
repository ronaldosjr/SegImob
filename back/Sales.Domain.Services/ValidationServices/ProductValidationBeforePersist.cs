using System;
using System.ComponentModel.DataAnnotations;
using Sales.Domain.Entities;
using Sales.Domain.Properties;
using Sales.Domain.Services.ValidationServices.Common;
using Sales.Domain.Services.ValidationServices.Interface;
using Sales.Domain.Specification.Restaurant;
using Sales.Infra.Repositories.Common;
using Sales.Infra.Repositories.Interfaces;

namespace Sales.Domain.Services.ValidationServices
{
    public class ProductValidationBeforePersist : ValidationBeforePersist<Product>, IProductValidationBeforePersist
    {
        private readonly IProductRepostitory _repository;

        public ProductValidationBeforePersist(IProductRepostitory repository)
        {
            _repository = repository;
        }

        public override bool CanPersist(Product entity)
        {
            base.CanPersist(entity);

            if (_repository.GetAsync(new ProductNameTakenSpecification(entity)).Result != null)
                throw new ValidationException(DomainValidationMessages.ProductAlreadyTaken);

            return true;
        }

    }
}
