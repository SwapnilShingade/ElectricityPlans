using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IPlanComparison
    {
        List<Product> GetProducts();
        List<Product> CompareTariff(int consumption, int flatRateConsumption);
    }
}
