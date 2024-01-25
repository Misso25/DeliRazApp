using DeliRazApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public interface IUserService
    {
        Task<int> AddUser(UserModel userModel);
        Task<int> UpdateUser(UserModel userModel);
        Task<UserModel> GetUserByLogin(string userLogin);
        Task<UserModel> GetUserByID(int userID);
    }
}
