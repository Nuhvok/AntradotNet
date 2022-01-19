using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmail(string email);

        Task<IEnumerable<Movie>> GetUserFavoritedMovies(int id);

        Task<IEnumerable<Purchase>> GetUserPurchasedMovies(int id);

        Task<User> GetUserDetails(int id);

        Task<Purchase> PurchaseMovie(Purchase purchase);

        Task<Favorite> FavoriteMovie(Favorite favorite);
    }
}
