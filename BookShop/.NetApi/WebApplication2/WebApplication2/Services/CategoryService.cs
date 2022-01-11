using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _appDbContext;

        private DbSet<Category> table;

        public CategoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            table = _appDbContext.Set<Category>();
        }

        public async Task Delete(Category category)
        {
            table.Remove(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> Get(Expression<Func<Category, bool>> predicate = null)
        {
            if (predicate != null)
                return await table.Where(predicate).ToListAsync();

            return await table.ToListAsync();
        }

        public async Task Insert(Category category)
        {
            await table.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            table.Update(category);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
