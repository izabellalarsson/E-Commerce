using System;
using System.Collections.Generic;
using NUnit.Framework;
using FakeItEasy;
using System.Linq;

namespace ECommerce.Models
{
    public class ProductServiceTests
    {
        public ProductServiceTests()
        {
        }
        private IProductRepository productRepository;

        private ProductService productService;

        [SetUp]
        public void SetUp()
        {
            this.productRepository = A.Fake<IProductRepository>();
            
            this.productService = new ProductService(this.productRepository);
        }

        // Test for Get method
        [Test]
        public void Get_ReturnsProductItemsFromRepository()
        {
            // Arrange
            var productItem = new Product
            {
                ProductId = 12,
                ProductName = "Beer",
                ProductImage = null,
                ProductPrice = "120",
                ProductDescription = "This is my favorite beer"
            };

            var productItems = new List<Product> { productItem };

            A.CallTo(() => this.productRepository.Get()).Returns(productItems);

            // Act
            var result = this.productService.Get().Single();

            // Assert
            Assert.That(result, Is.EqualTo(productItem));
        }

        // Test for Get method with given valid id
        [Test]
        public void Get_GivenValidId_ReturnsResultFromRepository()
        {
            // Arrange
            var productItem = new Product
            {
                ProductId = 12,
                ProductName = "Beer",
                ProductImage = null,
                ProductPrice = "120",
                ProductDescription = "This is my favorite beer"
            };

            A.CallTo(() => this.productRepository.Get(12)).Returns(productItem);

            // Act
            var result = this.productService.Get(12);

            // Assert
            Assert.That(result, Is.EqualTo(productItem));
        }
    }
}
