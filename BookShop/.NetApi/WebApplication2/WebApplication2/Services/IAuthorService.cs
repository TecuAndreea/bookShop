using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> Get(Expression<Func<Author, bool>> predicate = null);

        Task Insert(Author author);

        Task Update(Author author);

        Task Delete(Author author);
    }
}
