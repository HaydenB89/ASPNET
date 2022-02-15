using Microsoft.EntityFrameworkCore;
using PRSLibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibraryProject.Controllers {
    internal class RequestLinesController {

        private readonly PRSDbContext _context;

        public RequestLinesController(PRSDbContext context) {
            this._context = context;
        }

        private void RecalculateRequestTotal(int requestId) {
            var request = _context.Requests.Find(requestId);

            request.Total = (from rl in _context.RequestLines
                            join p in _context.Products
                            on rl.ProductId equals p.Id
                            where rl.RequestId == requestId
                            select new {
                                LineTotal = rl.Quantity * p.Price
                            }).Sum(x => x.LineTotal);
            _context.SaveChanges();
        }

        public IEnumerable<RequestLine> GetAll() {
            return _context.RequestLines
                            .Include(x => x.Product)
                            .Include(x => x.Request)
                            .ToList();
        }

        public RequestLine GetByPk(int id) {
            return _context.RequestLines
                                .Include(x => x.Product)
                                .Include()
        }
    }
}
