﻿using System;
namespace ECommerce.UnitTests
{
    using NUnit.Framework;

    public class ProductTest
    {
        public ProductTest()
        {
        }

        [Test]
        public void AddProduct_GivenProcuct_ReturnsSuccess()
        {
            //Arrange 
            //const AddCargoResult Cargo = ;

            var expectedResult = "success";
            var addProduct = ProductId;

            //Act 
            var result = product.Add(new ("Medical Supplies", 4));

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }


    }
}
