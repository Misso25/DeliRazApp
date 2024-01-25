using DeliRazApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public class FriendService : IFriendService
    {
        private SQLiteAsyncConnection _dbConnection;

        public FriendService()
        {
            SetUpDb();
        }

        private void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RazDeli.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                _dbConnection.CreateTableAsync<FriendModel>();
            }
        }

        public Task<int> AddFriend(FriendModel friendModel)
        {
            return _dbConnection.InsertAsync(friendModel);
        }

        public Task<int> DeleteFriend(FriendModel friendModel)
        {
            return _dbConnection.DeleteAsync(friendModel);
        }

        public Task<List<FriendModel>> GetFriendList(int id)
        {
            var friendList = _dbConnection.Table<FriendModel>().Where(x => x.FriendIdFirst == id).ToListAsync();
            return friendList;
        }
    }
}
