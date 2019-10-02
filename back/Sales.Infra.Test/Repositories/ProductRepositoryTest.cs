using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Sales.Domain.Entities;
using Sales.Domain.Specification.Restaurant;
using Sales.Infra.Repositories.Common;


namespace Sales.Infra.Test.Repositories
{
    public class ProductRepositoryTest
    {
        private readonly IRepository<Product> _repository;

        public ProductRepositoryTest()
        {
            var mock = new Mock<IRepository<Product>>();
            var lista = Task.Run(() => FakeProducts().ToList());

            mock.Setup(t => t.AddAsync(It.IsAny<Product>())).Verifiable();
            mock.Setup(t => t.Update(It.IsAny<Product>())).Verifiable();
            mock.Setup(t => t.Delete(It.IsAny<int>())).Verifiable();
            mock.Setup(t => t.GetAllAsync()).Returns(lista);
            mock.Setup(t => t.GetAsync(It.IsAny<ProductIdEqualsToSpecification>()))
                .Returns(async (ProductIdEqualsToSpecification spec) => (await lista).FirstOrDefault(spec.ToExpression().Compile()));
            mock.Setup(t => t.Find(It.IsAny<ProductIdEqualsToSpecification>()))
                .Returns((ProductIdEqualsToSpecification spec) => lista.Result.Where(spec.ToExpression().Compile()).ToList());

            _repository = mock.Object;

        }


        [Test]
        public void Should_Add_Product()
        {
            Assert.DoesNotThrow(() => _repository.AddAsync(CreateFakeProduct()));
        }


        [Test]
        public void Should_Edit_Product()
        {
            Assert.DoesNotThrow(() => _repository.Update(CreateFakeProduct()));
        }

        [Test]
        public void Should_Remove_Product()
        {
            Assert.DoesNotThrow(() => _repository.Delete(CreateFakeProduct().Id));
        }

        [Test]
        public void Should_Get_Product()
        {
            var product = CreateFakeProduct();
            product.Id = 1;
            var findById = new ProductIdEqualsToSpecification(product.Id);

            Assert.AreEqual(_repository.GetAsync(findById)?.Id, product.Id);
        }

        [Test]
        public void Should_Find_Product()
        {
            var product = CreateFakeProduct();
            product.Id = 2;
            var findById = new ProductIdEqualsToSpecification(product.Id);
            Assert.AreEqual(_repository.Find(findById).FirstOrDefault()?.Id, product.Id);
        }

        [Test]
        public void Should_Get_All_Product()
        {
            Assert.AreEqual(_repository.GetAllAsync().Result.Count, FakeProducts().Count());
        }

        private Product CreateFakeProduct() => new Product("Fake", 2m);


        private IEnumerable<Product> FakeProducts() => new List<Product>
            {
                new Product("Fake1", 2m){Id = 1},
                new Product("Fake2", 3m){Id = 2},
                new Product("Fake3", 4m){Id = 3},
            };
        
    }
}
