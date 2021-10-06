using BusinessLayer.Interface;
using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PlanComparisonService : IPlanComparison
    {
        public IProductsLoader _productsLoader;        
        public PlanComparisonService() { }
        public PlanComparisonService(IProductsLoader productsLoader)
        {
            _productsLoader = productsLoader;
        }

        /// <summary>
        /// calculates total tariff for based on product type
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns>Products with Total Tariff</returns>
        public List<Product> CompareTariff(int consumption, int flatRateConsumption)
        {
            List<Product> response = null;
            try
            {
                var products = GetProducts();
                if (products != null)
                {
                    response = products.Select(x => new Product()
                    {
                        Type = x.Type,
                        Name = x.Name,
                        ConsumptionCharge = x.ConsumptionCharge,
                        BaseCost = x.BaseCost,
                        Tariff = CalculateTariff(x, consumption, flatRateConsumption),
                    }).OrderBy(x => x.Tariff).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured at ComapareTariff Method: {ex.Message}");
            }
            return response;
        }

        /// <summary>
        /// gets all the product type available
        /// </summary>
        /// <returns>all the product types available</returns>
        public List<Product> GetProducts() 
        {           
            List<Product> products = null;
            try
            {
                ProductsCollectionDTO prodcutsDto = _productsLoader.GetProducts();
                if (prodcutsDto != null)
                {
                    products = prodcutsDto.ProductCollection.Select(x => new Product()
                    {
                        BaseCost = x.BaseCost,
                        ConsumptionCharge = x.ConsumptionCharge,
                        Name = x.Name,
                        Type = x.Type,
                        Description = x.Description,
                        ImageUrl = x.ImageUrl
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occured at GetProducts Method: {ex.Message}");
            }
            return products;
        }

        private int CalculateTariff(Product product, int consumption, int flatRateConsumption)
        {
            var totalTariff = product.Type switch
            {
                Constants.ProductB => consumption > flatRateConsumption ? ((consumption - flatRateConsumption) * product.ConsumptionCharge / 100) + product.BaseCost : product.BaseCost,
                Constants.ProductA => (product.BaseCost * 12) + (consumption * product.ConsumptionCharge / 100),
                _ => 0,
            };
            return totalTariff;
        }
    }
}
