using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> RegisterUser(UserRegisterRequestModel model)
        {
            var dbUser = await _userRepository.GetUserByEmail(model.Email);

            if(dbUser != null)
            {
                throw new Exception("Email in use");
            }

            var salt = GenerateSalt();

            var hashedPassword = GetHashedPassword(model.Password, salt);

            var user = new User
            {
                Email = model.Email,
                HashedPassword = hashedPassword,
                Salt = salt,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var creaedUser = await _userRepository.Add(user);
            return creaedUser.Id;

        }

        public async Task<UserLoginResponseModel> ValidateUser(LoginRequestModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if(user == null)
            {
                //return null;

                throw new Exception();
            }

            var hashedPassword = GetHashedPassword(model.Password, user.Salt);
            if(hashedPassword == user.HashedPassword)
            {
                var userLoginResponseModel = new UserLoginResponseModel 
                {
                    Id = user.Id,
                    Email = user.Email,
                    DateOfBirth= user.DateOfBirth,
                    FirstName= user.FirstName,
                    LastName= user.LastName
                };
                return userLoginResponseModel;
            }
            return null;
        }

        private string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                    password: password,
                                                                    salt: Convert.FromBase64String(salt),
                                                                    prf: KeyDerivationPrf.HMACSHA512,
                                                                    iterationCount: 10000,
                                                                    numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
