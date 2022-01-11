using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class OrderBookService : IOrderBookService
    {
        private readonly AppDbContext _appDbContext;

        private DbSet<OrderBook> table;

        public OrderBookService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            table = _appDbContext.Set<OrderBook>();
        }

        public async Task Delete(OrderBook orderBook)
        {
            table.Remove(orderBook);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderBook>> Get(Expression<Func<OrderBook, bool>> predicate = null)
        {
            if (predicate != null)
                return await table.Where(predicate)
                    .Include(o => o.Book)
                    .Include(o => o.Order)
                    .ToListAsync();

            return await table
                    .Include(o => o.Book)
                    .Include(o => o.Order)
                    .ToListAsync();
        }

        public async Task Insert(OrderBook orderBook)
        {
            await table.AddAsync(orderBook);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(OrderBook orderBook)
        {
            table.Update(orderBook);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
