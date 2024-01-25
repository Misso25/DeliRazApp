using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliRazApp.Models;
using DeliRazApp.Services;
using DeliRazApp.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Graphics.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.ViewModels
{
    public partial class FriendsPageViewModel : ObservableObject
    {
        public ObservableCollection<UserModel> Friends { get; set; } = new ObservableCollection<UserModel>();
        [ObservableProperty]
        string entryID;

        private readonly IFriendService _friendService;
        private readonly IUserService _userService;
        public FriendsPageViewModel(IFriendService friendService, IUserService userService)
        {
            _friendService = friendService;
            _userService = userService;
        }

        [RelayCommand]
        private async Task GetFriendInfoList()
        {
            var friendList = await _friendService.GetFriendList(App.CurrentUser.UserID);
            if (friendList?.Count > 0)
            {
                Friends.Clear();
                foreach (var friend in friendList)
                {
                    Friends.Add(await _userService.GetUserByID(friend.FriendIdSecond));
                }
            }
        }

        [RelayCommand]
        async Task AddFriend()
        {
            var entryUserID = Int32.Parse(entryID);
            int response = -1;
            if (entryUserID < 1) 
            {
                await Shell.Current.DisplayAlert("Ошибка", "Неверно введен ID пользователя", "Ок");
            }
            else
            {
                if (entryUserID == App.CurrentUser.UserID)
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Вы не можете добавить сами себя", "Ок");
                }
                else
                {
                    if (await _userService.GetUserByID(entryUserID) == null)
                    {
                        await Shell.Current.DisplayAlert("Ошибка", "Аккаунта с таким ID не существует ", "Ок");
                    }
                    else
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                response = await _friendService.AddFriend(new Models.FriendModel
                                {
                                    FriendIdFirst = App.CurrentUser.UserID,
                                    FriendIdSecond = entryUserID
                                });
                            }
                            else
                            {
                                response = await _friendService.AddFriend(new Models.FriendModel
                                {
                                    FriendIdFirst = entryUserID,
                                    FriendIdSecond = App.CurrentUser.UserID
                                });
                            }
                        }

                        if (response > 0)
                        {
                            await Shell.Current.DisplayAlert("Друг добавлен", "Успешное добавление друга", "Ок");
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Не создано", "Что-то пошло не так", "OK");
                        }
                    }
                }
            }
        }

        [RelayCommand]
        async Task OpenProfileFriend(UserModel friendDetail)
        {
            if (friendDetail == null)
            {
                await Shell.Current.DisplayAlert("Lol", "LOH", "Back");
            }
            var selectedFriend = friendDetail;
            await Shell.Current.GoToAsync(nameof(FriendProfilePage), new Dictionary<string, object>
            {
                {"SelectedFriend", selectedFriend }
            });
        }
    }
}
