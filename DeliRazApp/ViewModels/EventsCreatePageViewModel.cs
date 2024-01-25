using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliRazApp.Models;
using DeliRazApp.Services;
using DeliRazApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.ViewModels
{
    [QueryProperty(nameof(SelectedFriends), "SelectedFriends")]
    [QueryProperty(nameof(EventDetail), "EventDetail")]
    public partial class EventsCreatePageViewModel : ObservableObject
    {
        public ObservableCollection<UserModel> FriendsList { get; set; } = new ObservableCollection<UserModel>();
        [ObservableProperty]
        public UserModel selectedFriend;
        public ObservableCollection<UserModel> SelectedFriends { get; set; } = new ObservableCollection<UserModel>();
        [ObservableProperty]
        private EventModel _eventDetail = new EventModel();

        private readonly IEventService _eventService;
        private readonly IFriendService _friendService;
        private readonly IUserService _userService;
        private readonly IEventParticipantService _eventParticipantService;
        public EventsCreatePageViewModel(IEventService eventService, IEventParticipantService eventParticipantService, IFriendService friendService, IUserService userService)
        {
            _eventParticipantService = eventParticipantService;
            _eventService = eventService;
            _friendService = friendService;
            _userService = userService;
            _ = GetFriendInfoList();
        }

        [RelayCommand]
        public async Task CreateEvent()
        {
            int response = -1;   
            EventDetail.EventID = new Random().Next(1000000, 9999999);

            await _eventParticipantService.AddParticipantEvent(new Models.EventParticipantModel
            {
                EventID = EventDetail.EventID,
                ParticipantID = App.CurrentUser.UserID,

            });
            foreach(var friend in SelectedFriends) 
            {
                await _eventParticipantService.AddParticipantEvent(new Models.EventParticipantModel
                {
                    EventID = EventDetail.EventID,
                    ParticipantID = friend.UserID,
                });
            }
            response = await _eventService.AddEvent(new Models.EventModel
            {
                EventID = EventDetail.EventID,
                EventName = EventDetail.EventName,
                EventDate = EventDetail.EventDate,
            });
            if (response > 0)
            {
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Не создано", "Что-то пошло не так", "OK");
            }
        }

        [RelayCommand]
        private async Task AddFriend()
        {
            if (SelectedFriend == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Вы не выбрали друга", "Ок");
            }
            else
            {
                if (SelectedFriends.Contains(SelectedFriend))
                {
                    await Shell.Current.DisplayAlert("Уже добавлен", "Этот друг уже добавлен", "Ок");
                }
                else
                {
                    SelectedFriends.Add(selectedFriend);
                }
            }
        }

        private async Task GetFriendInfoList()
        {
            var friendList = await _friendService.GetFriendList(App.CurrentUser.UserID);
            if (friendList?.Count > 0)
            {
                FriendsList.Clear();
                foreach (var friend in friendList)
                {
                    FriendsList.Add(await _userService.GetUserByID(friend.FriendIdSecond));
                }
            }
        }
    }
}
