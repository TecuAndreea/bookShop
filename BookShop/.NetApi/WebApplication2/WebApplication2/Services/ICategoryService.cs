using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> Get(Expression<Func<Category, bool>> predicate = null);

        Task Insert(Category category);

        Task Update(Category category);

        Task Delete(Category category);
    }
}
