using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<User> GetUserDetails(int id)
        {
            var user = await _dbContext.Users.Where(u => u.Id == id).SingleOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<Movie>> GetUserFavoritedMovies(int id)
        {
            var movies = await _dbContext.Movies.Join(_dbContext.Favorites, m => m.Id, f => f.MovieId, (m, f) => new { m.Id,m.PosterUrl, m.Title, f.UserId}).Where(f => f.UserId == id).Select(m => new Movie { Id = m.Id, PosterUrl = m.PosterUrl, Title = m.Title}).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetUserPurchasedMovies(int id)
        {
            var movies = await _dbContext.Movies.Join(_dbContext.Purchases, m => m.Id, p => p.MovieId, (m, p) => new { m.Id, m.PosterUrl, m.Title, p.UserId }).Where(p => p.UserId == id).Select(m => new Movie { Id = m.Id, PosterUrl = m.PosterUrl, Title = m.Title }).ToListAsync();
            return movies;
        }
    }
}
