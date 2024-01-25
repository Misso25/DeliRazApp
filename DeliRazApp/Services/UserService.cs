using DeliRazApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public class UserService : IUserService
    {
        private SQLiteAsyncConnection _dbConnection;

        public UserService()
        {
            SetUpDb();
        }

        private void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RazDeli.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                _dbConnection.CreateTableAsync<UserModel>();
            }
        }

        public Task<int> AddUser(UserModel userModel)
        {
            return _dbConnection.InsertAsync(userModel);
        }

        public Task<int> UpdateUser(UserModel userModel)
        {
            return _dbConnection.UpdateAsync(userModel);
        }

        public Task<UserModel> GetUserByLogin(string userLogin)
        {
            var user = _dbConnection.Table<UserModel>().FirstOrDefaultAsync(x => x.UserLogin == userLogin);
            return user;
        }

        public Task<UserModel> GetUserByID(int userID)
        {
            var user = _dbConnection.Table<UserModel>().FirstOrDefaultAsync(x => x.UserID == userID);
            return user;
        }
    }
}
