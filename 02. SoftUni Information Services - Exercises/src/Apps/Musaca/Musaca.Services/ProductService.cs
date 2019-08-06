using Musaca.Data;
using Musaca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musaca.Services
{
    public class ProductService : IProductService
    {
        private readonly MusacaDbContext dbContext;

        public ProductService(MusacaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }
        public List<Product> GetAll()
        {
            var products = dbContext.Products.ToList();
            return products;
        }
        public Product GetByName(string name)
        {
            var product = dbContext.Products.SingleOrDefault(p => p.Name == name);
            return product;
        }
    }
}
