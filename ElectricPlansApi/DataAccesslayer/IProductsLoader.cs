using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IProductsLoader
    {
        ProductsCollectionDTO GetProducts();
    }
}
