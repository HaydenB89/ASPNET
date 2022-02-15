using Microsoft.EntityFrameworkCore;
using PRSLibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibraryProject.Controllers {
    public class RequestsController {
        private readonly PRSDbContext _context;

        public RequestsController(PRSDbContext context) {
            this._context = context;
        }

        public IEnumerable<Request> GetRequestsInReview(int userId) {
            var requests = _context.Requests
                                        Where(x => x.Status == "REVIEW"
                                                && xUserId != userId)
                                        ToList();
            return requests;
        }

        public void SetApproved(Request request) {
            request.Status = "APPROVED";
            Change(request);
        }

        public void SetRejected(Request request) {
            request.Status = "REJECTED";
            Change(request);
        }

        private void Change(Request request) {
            throw new NotImplementedException();
        }

        public void SetReview(Request request) {
            if (request.Total <= 50) {
                request.Status = "APPROVED";
            }
            else {
                request.Status = "REVIEW";
            }
            Change(request);
        }

        public IEnumerable<Request> GetAll() {
            return _context.Requests.Include(x => x.User).ToList();
        }

        public Request GetByPk(int id) {
            return _context.Requests.Find(id);
        }

        public Request Create(Request request) {
            if (request == null) {
                throw new ArgumentNullException("request");
            }
            if (request.Id != 0) {
                throw new ArgumentException("Request.Id must be zero!");
            }
            _context.Requests.Add(request);
            _context.SaveChanges();
            return request;
        }

        public void Delete(int id) {

        }
    }
}
