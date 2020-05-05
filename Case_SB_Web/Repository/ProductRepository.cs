using Case_SB_Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Case_SB_Web.Repository
{
    public class ProductRepository : IDisposable
    {
        private Entities _context = new Entities();

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProductsWithDescriptions()
        {
            return _context.Products.Where(p => p.Description != null).ToList();
        }

        public Product GetFirstProduct()
        {
            return _context.Products.First();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}