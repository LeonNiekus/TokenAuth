using Case_SB_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case_SB_Web.Repository
{
    public class ProductRepository : IDisposable
    {
        private Entities _context = new Entities();

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}