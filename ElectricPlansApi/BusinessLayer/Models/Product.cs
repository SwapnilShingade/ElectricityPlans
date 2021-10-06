using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models
{
    public class Product
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int ConsumptionCharge { get; set; }
        public int BaseCost { get; set; }
        public int Tariff { get; set; }  
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Products
    {
        public List<Product> ProductCollection { get; set; }
    }
    public class QueryParameters
    {
        [Required]      
        public int Usage { get; set; }
    }
}
