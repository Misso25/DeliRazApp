using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliRazApp.Models;
using DeliRazApp.Services;
using DeliRazApp.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.ViewModels
{
    [QueryProperty(nameof(SelectedEvent), "SelectedEvent")]
    public partial class EventPageViewModel : ObservableObject
    {
        [ObservableProperty]
        EventModel selectedEvent;
        public ObservableCollection<ExpenseModel> Expenses { get; set; } = new ObservableCollection<ExpenseModel>();
        public ObservableCollection<DebtModel> Debts { get; set; } = new ObservableCollection<DebtModel>();
        public ObservableCollection<UserModel> Participants { get; set; } = new ObservableCollection<UserModel>();

        private readonly IExpenseService _expenseService;
        private readonly IUserService _userService;
        private readonly IDebtService _debtService;
        private readonly IEventParticipantService _eventParticipantService;
        public EventPageViewModel(IExpenseService expenseService, IEventParticipantService eventParticipantService, IUserService userService, IDebtService debtService)
        {
            _expenseService = expenseService;
            _userService = userService;
            _eventParticipantService = eventParticipantService;
            _debtService = debtService;
        }

        [RelayCommand]
        private async Task GetExpenseList()
        {
            var expenseList = await _expenseService.GetExpenseListInEvent(SelectedEvent.EventID);
            if (expenseList?.Count > 0)
            {
                Expenses.Clear();
                foreach (var expense in expenseList)
                {
                    Expenses.Add(expense);
                }
            }
        }

        [RelayCommand]
        async Task GetDebtList()
        {
            var debtList = await _debtService.GetDebtListByEventID(SelectedEvent.EventID);
            if (debtList?.Count > 0)
            {
                Debts.Clear();
                foreach (var debt in debtList)
                {
                    Debts.Add(debt);
                }
            }
        }

        [RelayCommand]
        async Task GetParticipantList()
        {
            var currentEventID = SelectedEvent.EventID;
            var participantList = await _eventParticipantService.GetParticipantList(currentEventID);
            if (participantList?.Count > 0)
            {
                Participants.Clear();
                foreach (var participant in participantList)
                {
                    Participants.Add(await _userService.GetUserByID(participant.ParticipantID));
                }
            }
        }

        [RelayCommand]
        async Task CreateNewExpense()
        {
            var currentEvent = SelectedEvent;
            await Shell.Current.GoToAsync(nameof(CreateExpensePage), new Dictionary<string, object>
            {
                { "CurrentEvent", currentEvent }
            });
        }

        [RelayCommand]
        async Task OpenExpense(ExpenseModel expenseDetail) 
        {
            if (expenseDetail == null)
            {
                await Shell.Current.DisplayAlert("Lol", "LOH", "Back");
            }
            var selectedExpense = expenseDetail;
            await Shell.Current.GoToAsync(nameof(ExpensePage), new Dictionary<string, object>
            {
                { "SelectedExpense", selectedExpense },
            });
        }

        public async Task DisplayAction(ExpenseModel expenseModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Выбери действие!", "ОК", null, "Редактировать", "Удалить");
            if (response == "Редактировать")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("ExpenseDetail", expenseModel);

                await AppShell.Current.GoToAsync(nameof(CreateExpensePage), navParam);
            }
            else if (response == "Удалить")
            {
                var delResponse = await _expenseService.DeleteExpense(expenseModel);
                if (delResponse > 0)
                {
                    GetExpenseList();
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
            if (friendDetail.UserID == App.CurrentUser.UserID) 
            {
                await Shell.Current.DisplayAlert("Это твой профиль", "не надо сюда лезть!", "Назад");
            }
            else
            {
                var selectedFriend = friendDetail;
                await Shell.Current.GoToAsync(nameof(FriendProfilePage), new Dictionary<string, object>
                {
                    {"SelectedFriend", selectedFriend }
                });
            }
        }
    }
}
