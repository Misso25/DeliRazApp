using DeliRazApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public interface IFriendService
    {
        Task<List<FriendModel>> GetFriendList(int id);

        Task<int> AddFriend(FriendModel friendModel);
        Task<int> DeleteFriend(FriendModel friendModel);
    }
}
