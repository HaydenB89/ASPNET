using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CornerstonePRSPractice.Models;

namespace CornerstonePRSPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestLinesController : ControllerBase
    {
        private readonly PrsDbContext _context;

        public RequestLinesController(PrsDbContext context)
        {
            _context = context;
        }

        //*me PUT: api/RequestLines/Recalculate/5
        [HttpPut("recalculate/{requestId}")]
        private async Task<IActionResult> RecalculateRequest(int requestId) {

            var request = await _context.Requests.FindAsync(requestId);

            request.Total = (from rl in _context.RequestLines
                             join p in _context.Products
                             on rl.ProductId equals p.Id
                             where rl.RequestId == requestId
                             select new {
                                 LineTotal = rl.Qty * p.Price
                             }).Sum(x => x.LineTotal);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        // GET: api/RequestLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestLine>>> GetRequestLines()
        {
            return await _context.RequestLines
                                    .Include(x => x.Product)
                                        .ThenInclude(x => x.Vendor)
                                    .ToListAsync();
        }

        // GET: api/RequestLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestLine>> GetRequestLine(int id)
        {
            var requestLine = await _context.RequestLines
                                            .Include(x => x.Product)
                                                .ThenInclude(x => x.Vendor)
                                            .SingleOrDefaultAsync(x => x.Id == id);

            if (requestLine == null)
            {
                return NotFound();
            }

            return requestLine;
        }

        // PUT: api/RequestLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestLine(int id, RequestLine requestLine)
        {
            if (id != requestLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
              //*me
                await RecalculateRequest(requestLine.RequestId);
                //*end mine
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestLineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RequestLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestLine>> PostRequestLine(RequestLine requestLine)
        {
            _context.RequestLines.Add(requestLine);
            await _context.SaveChangesAsync();
            //*me
            await RecalculateRequest(requestLine.RequestId);
            //*end mine

            return CreatedAtAction("GetRequestLine", new { id = requestLine.Id }, requestLine);
        }

        // DELETE: api/RequestLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestLine(int id)
        {
            var requestLine = await _context.RequestLines.FindAsync(id);
            if (requestLine == null)
            {
                return NotFound();
            }

            _context.RequestLines.Remove(requestLine);
            await _context.SaveChangesAsync();
            //*me
            await RecalculateRequest(requestLine.RequestId);
            //*end mine

            return NoContent();
        }

        private bool RequestLineExists(int id)
        {
            return _context.RequestLines.Any(e => e.Id == id);
        }
    }
}
