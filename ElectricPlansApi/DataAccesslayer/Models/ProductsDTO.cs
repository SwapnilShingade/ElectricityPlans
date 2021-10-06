using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class ProductsDTO
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int ConsumptionCharge { get; set; }
        public int BaseCost { get; set; }
        public int Tariff { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ProductsCollectionDTO
    {
        public List<ProductsDTO> ProductCollection { get; set; }
    }
}
