using PRSLibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibraryProject.Controllers {
    public class ProductsController {
        private readonly PRSDbContext _context;

        public ProductsController(PRSDbContext context) {
            this._context = context;
        }

        public IEnumerable<Product> GetAll() {
            return _context.Products.ToList();
        }

        public Product GetByPk(int id) {
            return _context.Products.Find(id);
        }
    }
}
