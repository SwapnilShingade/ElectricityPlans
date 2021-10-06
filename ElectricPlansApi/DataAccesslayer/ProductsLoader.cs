using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.IO;
using System.Runtime.Caching;

namespace DataAccesslayer
{
    public class ProductsLoader : IProductsLoader
    {
        private const string CacheKey = "Products";        
        public ProductsLoader()
        { }

        /// <summary>
        /// method reads all the products available
        /// </summary>
        /// <returns></returns>
        public ProductsCollectionDTO  GetProducts()
        {
            ObjectCache cache = MemoryCache.Default;            
            var json = File.ReadAllText(Directory.GetCurrentDirectory() + @"\" + "products.json");
            ProductsCollectionDTO products = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductsCollectionDTO>(json);
           
            //check and add Products to Cache as List of Products remains same
            //cache can be invaidated after a sapn of 1 hr
            
            if (cache.Contains(CacheKey))
                return (ProductsCollectionDTO)cache.Get(CacheKey);
            else
            {
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(CacheKey, products, cacheItemPolicy);
                return products;
            }
        }
    }
}
