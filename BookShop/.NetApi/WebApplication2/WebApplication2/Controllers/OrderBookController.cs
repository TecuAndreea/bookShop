using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderBookController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderBook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderBook>>> GetOrderBooks()
        {
            return await _context.OrderBooks.ToListAsync();
        }

        // GET: api/OrderBook/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderBook>> GetOrderBook(int id)
        {
            var orderBook = await _context.OrderBooks.FindAsync(id);

            if (orderBook == null)
            {
                return NotFound();
            }

            return orderBook;
        }

        // PUT: api/OrderBook/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderBook(int id, OrderBook orderBook)
        {
            if (id != orderBook.OrderBookId)
            {
                return BadRequest();
            }

            _context.Entry(orderBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderBookExists(id))
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

        // POST: api/OrderBook
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderBook>> PostOrderBook(OrderBook orderBook)
        {
            _context.OrderBooks.Add(orderBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderBook", new { id = orderBook.OrderBookId }, orderBook);
        }

        // DELETE: api/OrderBook/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderBook(int id)
        {
            var orderBook = await _context.OrderBooks.FindAsync(id);
            if (orderBook == null)
            {
                return NotFound();
            }

            _context.OrderBooks.Remove(orderBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderBookExists(int id)
        {
            return _context.OrderBooks.Any(e => e.OrderBookId == id);
        }
    }
}
