using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<List<MoviePurchaseDetailsResponseModel>> GetUserPurchasedMovies(int id);
        Task<List<MovieCardResponseModel>> GetUserFavoritedMovies(int id);
        Task<UserDetailsModel> GetUserDetails(int id);
        Task<bool> EditUserProfile(UserDetailsModel userDetailsModel);
        Task<MoviePurchaseDetailsModel> PurchaseMovie(MoviePurchaseDetailsModel purchaseModel);
        Task<MovieFavoriteDetailsModel> FavoriteMovie(MovieFavoriteDetailsModel favoriteModel);
    }
}
