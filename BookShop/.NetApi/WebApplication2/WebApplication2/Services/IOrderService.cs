using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> Get(Expression<Func<Order, bool>> predicate = null);

        Task Insert(Order order);

        Task Update(Order order);

        Task Delete(Order order);
    }
}
