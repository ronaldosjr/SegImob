using System;
using NUnit.Framework;
using Sales.Domain.Entities;
using Sales.Domain.Exceptions;
using Sales.Domain.Specification.Restaurant;
using Sales.Domain.Test.Helpers;

namespace Sales.Domain.Test.Entities
{
    [TestFixture]
    public class ProductTest
    {
        private static readonly string _validName = "Teste case";
        private static readonly string _avaibleName = "Avaible name";
        private const decimal price = 2.4m;
        private static Product CreateValidProducts() => new Product(_validName, price);

        [Test]
        public void Should_Create_Product()
        {
            Assert.IsInstanceOf<Product>(CreateValidProducts());
        }

        [Test]
        public void Should_Not_Create_With_Null_Name()
        {
            Assert.Throws<CustomValidationException>(() => new Product(null, price));
        }

        [Test]
        public void Should_Not_Create_With_Empty_Name()
        {
            Assert.Throws<CustomValidationException>(() => new Product(string.Empty, price));
        }

        [Test]
        public void Should_Not_Create_With_Long_Name()
        {
            Assert.Throws<CustomValidationException>(() => new Product(_validName.ToLongName(Product.NAME_LENGTH), price));
        }
        
        [Test]
        public void Should_Validate_Products_With_Taken_Name()
        {
            var spec = new ProductNameTakenSpecification(CreateValidProducts());
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidProducts()), true);
        }

        [Test]
        public void Should_Validate_Products_With_Taken_Name_Lower_Case()
        {
            var spec = new ProductNameTakenSpecification(new Product(_validName.ToLower(), price));
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidProducts()), true);
        }

        [Test]
        public void Should_Validate_Products_With_Taken_Name_Upper_Case()
        {
            var spec = new ProductNameTakenSpecification(new Product(_validName.ToUpper(), price));
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidProducts()), true);
        }

        [Test]
        public void Should_Not_Validate_Products_With_Avaible_Name()
        {
            var spec = new ProductNameTakenSpecification(new Product(_avaibleName.ReverseString(), price));
            Assert.AreEqual(spec.IsSatisfiedBy(CreateValidProducts()), false);
        }

        [Test]
        public void Should_Validade_Products_With_Same_Id()
        {
            var spec = new ProductIdEqualsToSpecification(1);
            Assert.AreEqual(spec.IsSatisfiedBy(new Product { Id = 1 }), true);
        }

        [Test]
        public void Should_Not_Validade_Products_With_Diff_Id()
        {
            var spec = new ProductIdEqualsToSpecification(2);
            Assert.AreEqual(spec.IsSatisfiedBy(new Product { Id = 1 }), false);
        }
    }
}
