using BusinessLayer.Models;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public static class Helper
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>() {
             new Product ()
             {
                 Type =  "ProductA",
                 Name = "Basic Electricity Tariff",
                 ConsumptionCharge = 22,
                 BaseCost =  5,
                 Tariff = 0
             },
             new Product()
             {
                Type =  "ProductB",
                Name = "Packaged Tariff",
                ConsumptionCharge =  30,
                BaseCost =  800,
                Tariff = 0
             }
            };
        }
        public static List<Product> GetProductsNull()
        {
            return null;
        }
        public static List<Product> CompareTariff()
        {
            return new List<Product>() {
             new Product ()
             {
                 Type =  "ProductA",
                 Name = "Basic Electricity Tariff",
                 ConsumptionCharge = 22,
                 BaseCost =  5,
                 Tariff = 1050
             },
             new Product()
             {
                Type =  "ProductB",
                Name = "Packaged Tariff",
                ConsumptionCharge =  30,
                BaseCost =  800,
                Tariff = 950
             }
            };
        }

        public static ProductsCollectionDTO GetProductsDTO()
        {
            return new ProductsCollectionDTO()
            {
                ProductCollection = new List<ProductsDTO>() {
             new ProductsDTO ()
             {
                 Type =  "ProductA",
                 Name = "Basic Electricity Tariff",
                 ConsumptionCharge = 22,
                 BaseCost =  5,
                 Tariff = 0
             },
             new ProductsDTO()
             {
                Type =  "ProductB",
                Name = "Packaged Tariff",
                ConsumptionCharge=  30,
                BaseCost =  800,
                Tariff = 0
             }
            }
            };
        }
        public static ProductsCollectionDTO GetProductsDTONull()
        {
            return null;
        }
    }
}
