using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace ECommerce.Models
{
    using NUnit.Framework;

    public class ProductServiceTests
    {
        private ProductService productService;

        [SetUp]
        public void SetUp()
        {
            this.productService = new ProductService(new ProductRepository(
                "Server=localhost;port=8889;Database=e-Commerce;Uid=root;Pwd=root;"));
        }

        [Test]
        public void Get_ReturnsResultsFromDatabase()
        {
            // Act
            var result = this.productService.Get();
            // Assert
            Assert.That(result.Count, Is.EqualTo(4));

            Assert.That(result[1].ProductId, Is.EqualTo(2));

            Assert.That(result[1].ProductName, Is.EqualTo("Beer"));

            Assert.That(result[1].ProductDescription, Is.EqualTo("Just another good beer"));

            Assert.That(result[1].ProductPrice, Is.EqualTo(120));

        }

        [Test]
        public void Get_GivenId_ReturnsResultFromDatabase()
        {
            // Act
            var result = this.productService.Get(2);

            // Assert
            Assert.That(result.ProductId, Is.EqualTo(2));
            Assert.That(result.ProductName, Is.EqualTo("Beer"));
            Assert.That(result.ProductDescription, Is.EqualTo("Just another good beer"));
            Assert.That(result.ProductPrice, Is.EqualTo(120));

        }

        [Test]
        public void Add_GivenValidProductItem_SavesIt()
        {
            // Arrange
            const string ExpectedName = "HappyBeer";
            const string ExpectedDescription = "A Happy Beer";
            const int ExpectedPrice = 200;

            var productItem = new Product
            {
                ProductId = 5,
                ProductName = ExpectedName,
                ProductDescription = ExpectedDescription,
                ProductPrice = ExpectedPrice
            };

            // Act
            Product addNewProduct;
            using (new TransactionScope())
            {
                this.productService.Add(productItem);

                addNewProduct = this.productService.Get().Last();
            }

            // Assert
            Assert.That(productItem, Is.Not.Null);
            Assert.That(productItem.ProductId, Is.GreaterThanOrEqualTo(1));
            Assert.That(productItem.ProductName, Is.EqualTo(ExpectedName));
            Assert.That(productItem.ProductDescription, Is.EqualTo(ExpectedDescription));
            Assert.That(productItem.ProductPrice, Is.EqualTo(ExpectedPrice));


        }
    }
}
