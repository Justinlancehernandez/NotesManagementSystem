using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
         User AddUser(User user);
         User UpdateUser(User user);
         void DeleteUser(int userId);
        User LogInUser(string userName, string password);
         string GenerateHashPassword(string password, byte[] salt);
         byte[] GenerateSalt(string password);


    }
}
