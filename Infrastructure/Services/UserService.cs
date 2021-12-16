using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> EditUserProfile(UserDetailsModel userDetailsModel)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDetailsModel>> GetUserDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieCardResponseModel>> GetUserFavoritedMovies(int id)
        {
            var movies = await _userRepository.GetUserFavoritedMovies(id);
            
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(
                    new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title }
                    );
            }
            return movieCards;
        }

        public async Task<List<MovieCardResponseModel>> GetUserPurchasedMovies(int id)
        {
            var movies = await _userRepository.GetUserPurchasedMovies(id);

            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(
                    new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title }
                    );
            }
            return movieCards;
        }
    }
}
