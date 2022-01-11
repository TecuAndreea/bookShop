using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _appDbContext;

        private DbSet<Author> table;

        public AuthorService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            table = _appDbContext.Set<Author>();
        }

        public async Task Delete(Author author)
        {
            table.Remove(author);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> Get(Expression<Func<Author, bool>> predicate = null)
        {
            if (predicate != null)
                return await table.Where(predicate).ToListAsync();

            return await table.ToListAsync();
        }

        public async Task Insert(Author author)
        {
            await table.AddAsync(author);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Author author)
        {
            table.Update(author);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
