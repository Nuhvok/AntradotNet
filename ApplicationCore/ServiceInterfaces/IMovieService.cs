using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {

        // Expose the methods thgat are required by the client/views
        Task<IEnumerable<MovieCardResponseModel>> GetMovies();
        Task<IEnumerable<MovieCardResponseModel>> GetHighestGrossingMovies();
        Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenre(int id);

        // Task<MovieDetailsResponseModel> GetMovieDetailsById(int id, int userId);
        Task<MovieDetailsResponseModel> GetMovieDetailsById(int id);
    }
}
