using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var movies = await _dbContext.Movies.Take(100).ToListAsync();
            return movies;
        }
        public async Task<IEnumerable<Movie>> Get30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(x => x.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int id)
        {
            var movies = await _dbContext.Movies.Join(_dbContext.MovieGenres, m => m.Id, g => g.MovieId, (m, g) => new { m.Id, m.PosterUrl, m.Title, g.GenreId}).Where(g => g.GenreId == id).Select(m => new Movie { Id = m.Id, PosterUrl = m.PosterUrl, Title = m.Title }).ToListAsync();
            return movies;
        }

        public async override Task<Movie> GetById(int id)
        {
            var movieDetails = await _dbContext.Movies.Include(m=> m.CastOfMovie).ThenInclude(m=> m.Cast)
                .Include(m=> m.GenreOfMovie).ThenInclude(m=> m.Genre)
                .Include(m=> m.Trailers).FirstOrDefaultAsync(m=> m.Id == id);
            if (movieDetails == null) return null;

            var rating = await _dbContext.Reviews.Where(m => m.MovieId == id).DefaultIfEmpty().AverageAsync(r=> r == null ? 0 : r.Rating);
            movieDetails.Rating = rating;
            return movieDetails;
        }
    }
}
