using Musaca.Models;
using System.Collections.Generic;

namespace Musaca.Services
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        List<Product> GetAll();
        Product GetByName(string name);
    }
}