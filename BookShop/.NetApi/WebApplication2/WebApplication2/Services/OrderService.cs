using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _appDbContext;

        private DbSet<Order> table;

        public OrderService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            table = _appDbContext.Set<Order>();
        }

        public async Task Delete(Order order)
        {
            table.Remove(order);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> Get(Expression<Func<Order, bool>> predicate = null)
        {
            if (predicate != null)
                return await table.Where(predicate).ToListAsync();

            return await table.ToListAsync();
        }

        public async Task Insert(Order order)
        {
            await table.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            table.Update(order);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
