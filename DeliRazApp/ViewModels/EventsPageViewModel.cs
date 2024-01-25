using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliRazApp.Models;
using DeliRazApp.Services;
using DeliRazApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.ViewModels
{
    public partial class EventsPageViewModel : ObservableObject
    {
        public ObservableCollection<EventModel> Events { get; set; } = new ObservableCollection<EventModel>();

        private readonly IEventService _eventService;
        private readonly IEventParticipantService _eventParticipantService;
        public EventsPageViewModel(IEventService eventService, IEventParticipantService eventParticipantService)
        {
            _eventParticipantService = eventParticipantService;
            _eventService = eventService;
        }

        [RelayCommand]
        private async Task GetEventList()
        {
            var eventIDList = await _eventParticipantService.GetEventList(App.CurrentUser.UserID);
            if (eventIDList?.Count > 0)
            {
                Events.Clear();
                foreach (var event1 in eventIDList)
                {
                    Events.Add(await _eventService.GetEventListByID(event1.EventID));
                }
            }
        }

        [RelayCommand]
        public async Task CreateNewEvent()
        {
            await Shell.Current.GoToAsync(nameof(EventsCreatePage));
        }
        [RelayCommand]
        async public Task OpenEvent(EventModel eventDetail)
        {
            if (eventDetail == null)
            {
                await Shell.Current.DisplayAlert("Lol","LOH","Back");
            }
            var selectedEvent = eventDetail;
            await Shell.Current.GoToAsync(nameof(EventPage), new Dictionary<string, object>
            {
                { "SelectedEvent", selectedEvent } 
            });
        }

        [RelayCommand]
        public async Task DisplayAction(EventModel eventModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Выбери действие!", "ОК", null, "Редактировать", "Удалить");
            if (response == "Редактировать")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("EventDetail", eventModel);

                await AppShell.Current.GoToAsync(nameof(EventsCreatePage), navParam);
            }
            else if (response == "Удалить")
            {
                var delResponse = await _eventService.DeleteEvent(eventModel);
                if (delResponse > 0)
                {
                    GetEventList();
                }
            }
        }
    }
}
