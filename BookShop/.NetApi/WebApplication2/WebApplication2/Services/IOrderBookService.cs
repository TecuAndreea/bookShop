using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IOrderBookService
    {
        Task<IEnumerable<OrderBook>> Get(Expression<Func<OrderBook, bool>> predicate = null);

        Task Insert(OrderBook orderBook);

        Task Update(OrderBook orderBook);

        Task Delete(OrderBook orderBook);
    }
}
