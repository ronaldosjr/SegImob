using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sales.Application.Dtos;
using Sales.Application.Services.Interfaces;
using Sales.Application.Test.Helpers;

namespace Sales.Application.Test.Services
{
    public class ProductApplicationTest
    {
        private readonly IProductApplication _application;

        public ProductApplicationTest() => _application = ObjectInitiliazer.CreateProductApplication();

        private ProductDto CreateValidProduct(string name) => new ProductDto { Name = name, Price = 2.3m };

        [Test]
        public void Should_Add_Product()
        {
            var product = CreateValidProduct("product insert");
            var saved = _application.AddAsync(product);
            Assert.IsTrue(saved.Id > 0);
        }

        [Test]
        public void Should_Update_Product()
        {
            var added = _application.AddAsync(CreateValidProduct("product update")).Result;
            added.Name = "New Name";
            var update = _application.Update(added);       
            Assert.IsTrue(update.Name.Equals(added.Name));
        }

        [Test]
        public void Should_Delete_Product()
        {
            var added = _application.AddAsync(CreateValidProduct("product delete"));
            Assert.DoesNotThrow(() => _application.Delete(added.Id));
        }

        [Test]
        public void Should_Get_All()
        {
            var productList = new List<ProductDto>
            {
                CreateValidProduct("product 1"),
                CreateValidProduct("product 2"),
                CreateValidProduct("product 3"),
            };

            foreach (var item in productList)
                _application.AddAsync(item);

            var listAdded = _application.GetAllAsync().Result.ToList();

            foreach (var item in productList)
                Assert.IsTrue(listAdded.Any(i => i.Name.Equals(item.Name)));

        }

        [Test(ExpectedResult = true)]
        public bool Should_Name_Taken()
        {
            var added = _application.AddAsync(CreateValidProduct("product taken"));
            var newer = CreateValidProduct("product taken");
            newer.Id = 9999;
            return _application.IsNameTaken(newer);
        }

        [Test]
        public void Should_Get_By_Id()
        {
            var added = _application.AddAsync(CreateValidProduct("product by id"));
            Assert.IsNotNull(_application.GetByIdAsync(added.Id));
        }
    }
}
