using ApplicationCore.Entities;
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
    //[Authorize]
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> EditUserProfile(UserDetailsModel userDetailsModel)
        {
            var user = await _userRepository.Update(new User { Id = userDetailsModel.Id, FirstName = userDetailsModel.FirstName, LastName = userDetailsModel.LastName, DateOfBirth = userDetailsModel.DateOfBirth, Email = userDetailsModel.Email, PhoneNumber = userDetailsModel.PhoneNumber });
            return user != null ? true: false;
        }

        public async Task<UserDetailsModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetUserDetails(id);

            return new UserDetailsModel { FirstName = user.FirstName, LastName = user.LastName, DateOfBirth = user.DateOfBirth, Email = user.Email, PhoneNumber = user.PhoneNumber };
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

        // work here
        public async Task<MovieFavoriteDetailsModel> FavoriteMovie(MovieFavoriteDetailsModel favoriteModel)
        {
            var favorite = await _userRepository.FavoriteMovie(new Favorite { UserId = favoriteModel.UserId, MovieId = favoriteModel.MovieId });
            return new MovieFavoriteDetailsModel { UserId = favorite.UserId, MovieId = favorite.MovieId };
        }

        public async Task<List<MoviePurchaseDetailsResponseModel>> GetUserPurchasedMovies(int id)
        {
            var purchases = await _userRepository.GetUserPurchasedMovies(id);

            var purchaseCards = new List<MoviePurchaseDetailsResponseModel>();
            foreach (var purchase in purchases)
            {
                purchaseCards.Add(
                    new MoviePurchaseDetailsResponseModel {Card = new MovieCardResponseModel { Id = purchase.Movie.Id, PosterUrl = purchase.Movie.PosterUrl, Title = purchase.Movie.Title }, PurchaseDate = purchase.PurchaseDateTime, PurchaseAmount = purchase.TotalPrice, PurchaseNumber = purchase.PurchaseNumber }
                    );
            }
            return purchaseCards;
        }

        public async Task<MoviePurchaseDetailsModel> PurchaseMovie(MoviePurchaseDetailsModel purchaseModel)
        {
            var purchase = await _userRepository.PurchaseMovie(new Purchase { UserId = purchaseModel.UserId, PurchaseNumber = purchaseModel.PurchaseNumber, TotalPrice = purchaseModel.PurchaseAmount.Value, PurchaseDateTime = purchaseModel.PurchaseDate, MovieId = purchaseModel.MovieId });
            return new MoviePurchaseDetailsModel { UserId = purchase.UserId, PurchaseNumber = purchase.PurchaseNumber, PurchaseAmount = purchase.TotalPrice, PurchaseDate = purchase.PurchaseDateTime, MovieId = purchase.MovieId};
        }
    }
}
