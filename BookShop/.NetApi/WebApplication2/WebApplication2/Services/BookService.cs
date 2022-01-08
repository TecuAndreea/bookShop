using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _appDbContext;

        private DbSet<Book> table;

        public BookService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            table = _appDbContext.Set<Book>();
        }

        public async Task Delete(Book book)
        {
            table.Remove(book);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get(Expression<Func<Book, bool>> predicate = null)
        {
            if (predicate != null)
                return await table.Where(predicate)
                    .Include(a => a.Author)
                    .Include(c => c.Category)
                    .ToListAsync();

            return await table
                    .Include(a => a.Author)
                    .Include(c => c.Category)
                    .ToListAsync();
        }

        public async Task Insert(Book book)
        {
            await table.AddAsync(book);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            table.Update(book);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
