using PRSLibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibraryProject.Controllers
{
    public class VendorsController {

        private readonly PRSDbContext _context;

        public VendorsController(PRSDbContext context) {
            this._context = context;
        }

        public IEnumerable<Vendor> GetAll() {
            return _context.Vendors.ToList();
        }

        public Vendor GetByPK(int id) {
            return _context.Vendors.Find(id);
        }

        public Vendor Create(Vendor vendor) {
            _context.Vendors.Add(vendor);
            _context.SaveChanges();
            return vendor;
        }

        public void Change(Vendor vendor) {
            _context.SaveChanges();
        }

        public void Remove(int id) {
            var vendor = _context.Vendors.Find(id);
            if (vendor != null) {
                _context.Vendors.Remove(vendor);
                _context.SaveChanges();
            }
        }
    }
}
