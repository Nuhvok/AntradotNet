using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
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

        //extra comment here
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

        public Task<List<MovieCardResponseModel>> GetUserFavoritedMovies(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovieCardResponseModel>> GetUserPurchasedMovies(int id)
        {
            throw new NotImplementedException();
        }
    }
}
