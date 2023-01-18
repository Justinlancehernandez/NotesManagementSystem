using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
         public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public User AddUser(User user)
        {
            byte[] salt = GenerateSalt(user.password);
            string hash = GenerateHashPassword(user.password, salt);

            var newUser = new User()
            {
                userName = user.userName,
                name = user.name,
                salted = salt,
                hashed = hash,
            };
            _unitOfWork.Users.Add(newUser);
            _unitOfWork.Complete();
            return newUser;          
        }
        public User UpdateUser(User user)
        {
            byte[] salt = GenerateSalt(user.password);
            string hash = GenerateHashPassword(user.password, salt);
            var getUser = _unitOfWork.Users.GetById(user.userId);
            getUser.userName = user.userName;
            getUser.name = user.name;
            getUser.salted = salt;
            getUser.hashed = hash;

                     
            _unitOfWork.Complete();
            return getUser;
        }
        public void DeleteUser(int userId)
        {
            var getUser = _unitOfWork.Users.GetById(userId);
            _unitOfWork.Users.Remove(getUser);
            _unitOfWork.Complete();

        }
        public User LogInUser(string userName, string password)
        {
            var getUser = _unitOfWork.Users.GetUserByEmail(userName);
            if (getUser != null)
            {
                string hash = GenerateHashPassword(password, getUser.salted);
                if (getUser.hashed == hash)
                {
                    return getUser;
                }

                else return null;
            }

            else return null;
        }
        

        public string GenerateHashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;
        }
        public byte[] GenerateSalt(string password)
        {
            var salt = new byte[128 / 8];

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return salt;
        }
    }
}

