using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using BusinessLayer;
using BusinessLayer.Models;

namespace UnitTests
{
    public class PlanServiceTests
    {
        public Mock<IProductsLoader> _productsLoader;
        public PlanComparisonService planComparisonService;

        public PlanServiceTests()
        {           
            _productsLoader = new Mock<IProductsLoader>();
            _productsLoader.Setup(x => x.GetProducts()).Returns(Helper.GetProductsDTO);
            planComparisonService = new PlanComparisonService(_productsLoader.Object);
        }

        [Fact]
        public void GetProducts_OkResult()
        {
            var okResult = planComparisonService.GetProducts();
            Assert.IsType<List<Product>>(okResult);
            Assert.Equal(2, okResult.Count);
        }

        [Fact]
        public void GetProducts_NullResult()
        {
            _productsLoader.Setup(x => x.GetProducts()).Returns(Helper.GetProductsDTONull); 
            var nullResult = planComparisonService.GetProducts();            
            Assert.Null(nullResult);
        }
    }
}
