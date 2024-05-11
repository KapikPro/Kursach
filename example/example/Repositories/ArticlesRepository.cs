using example.Data;
using SQLitePCL;
using example.Models;
using Microsoft.EntityFrameworkCore;

namespace example.Repositories
{
    public class ArticlesRepository
    {
        private ApplicationDbContext _context;

        public ArticlesRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<List<Articles>> GetArticlesAsync()
        {
            return await _context.Articles.ToListAsync();
        }
    }
}
