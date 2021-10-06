using BusinessLayer.Interface;
using BusinessLayer.Models;
using Electrify.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ControllerTests
    {

        Mock<IPlanComparison> _service;
        VerivoxController _controller;
        ILogger<VerivoxController> _logger;
        IConfiguration _config;
        public ControllerTests()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _config = config;
            _service = new Mock<IPlanComparison>();            
            _controller = new VerivoxController(_service.Object, _logger, _config);

        }
        [Fact]
        public void GetProducts_OkResult()
        {
            _service.Setup(x => x.GetProducts()).Returns(Helper.GetProducts);
            var okResult = _controller.Products();
            Assert.IsType<OkObjectResult>(okResult.Result);           
        }

        [Fact]
        public void GetProducts_BadResult()
        {
            _service.Setup(x => x.GetProducts()).Returns(Helper.GetProductsNull);
            var badResult = _controller.Products();
            Assert.IsType<BadRequestObjectResult>(badResult.Result);
        }

        [Fact]
        public void ProductsCompare_OkResult()
        {
            _service.Setup(x => x.CompareTariff(It.IsAny<int>(), It.IsAny<int>())).Returns(Helper.CompareTariff);
            QueryParameters queryParameters = new QueryParameters() { Usage = 4500 };
            var okResult = _controller.ProductCompare(queryParameters);
            Assert.IsType<OkObjectResult>(okResult.Result);                        
        }

        [Fact]
        public void ProductsCompare_NullResult()
        {
            _service.Setup(x => x.CompareTariff(It.IsAny<int>(), It.IsAny<int>())).Returns(Helper.GetProductsNull);
            QueryParameters queryParameters = new QueryParameters() { Usage = 4500 };
            var badRequest = _controller.ProductCompare(queryParameters);
            Assert.IsType<BadRequestObjectResult>(badRequest.Result);                                  
        }

        [Fact]
        public void ProductsCompare_BadRequest()
        {
            QueryParameters queryParameters = new QueryParameters() { Usage = 0 };
            var badRequest = _controller.ProductCompare(queryParameters);
            Assert.IsType<BadRequestObjectResult>(badRequest.Result);
        }
    }
}
