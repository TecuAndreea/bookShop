using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> Get(Expression<Func<Book, bool>> predicate = null);

        Task Insert(Book book);

        Task Update(Book book);

        Task Delete(Book book);
    }
}
