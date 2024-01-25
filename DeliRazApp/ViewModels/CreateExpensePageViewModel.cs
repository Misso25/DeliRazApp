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
    [QueryProperty(nameof(ExpenseDetail), "ExpenseDetail")]
    [QueryProperty(nameof(CurrentEvent), "CurrentEvent")]
    public partial class CreateExpensePageViewModel : ObservableObject
    {
        public ObservableCollection<UserModel> ParticipantList { get; set; } = new ObservableCollection<UserModel>();
        [ObservableProperty]
        public UserModel selectedParticipant;
        public ObservableCollection<UserModel> SelectedParticipants { get; set; } = new ObservableCollection<UserModel>();

        [ObservableProperty]
        UserModel selectedCreditor;
        [ObservableProperty]
        private ExpenseModel _expenseDetail = new ExpenseModel();
        [ObservableProperty]
        EventModel currentEvent;
        [ObservableProperty]
        int expenseAmount;
        [ObservableProperty]
        int debtAmount;

        private readonly IExpenseService _expenseService;
        private readonly IExpensePTService _expensePTService;
        private readonly IEventParticipantService _eventParticipantService;
        private readonly IUserService _userService;
        private readonly IDebtService _debtService;
        public CreateExpensePageViewModel(IExpenseService expenseService, IDebtService debtService, IExpensePTService expensePTService, IUserService userService, IEventParticipantService eventParticipantService)
        {
            _expenseService = expenseService;
            _expensePTService = expensePTService;
            _userService = userService;
            _ = GetParticipantInfoList();
            _eventParticipantService = eventParticipantService;
            _debtService = debtService;
        }

        [RelayCommand]
        public async Task CreateExpense()
        {
            int response = -1;
            ExpenseDetail.ExpenseID = new Random().Next(1000000, 9999999);
            ExpenseDetail.ExpenseCreditorName = selectedCreditor.UserName;
            ExpenseDetail.ExpenseAmount = expenseAmount;
            
            foreach (var participant in SelectedParticipants)
            {
                await _expensePTService.AddParticipantExpense(new Models.ExpensePTModel
                {
                    ExpenseID = ExpenseDetail.ExpenseID,
                    ParticipantID = participant.UserID,
                });
                if (participant.UserID != SelectedCreditor.UserID)
                {
                    await _debtService.AddDebt(new Models.DebtModel
                    {
                        DebtCreditorLogin = selectedCreditor.UserLogin,
                        DebtCreditorName = selectedCreditor.UserName,
                        DebtAmount = expenseAmount / SelectedParticipants.Count,
                        DebtDebtorLogin = participant.UserLogin,
                        DebtDebtorName = participant.UserName,
                        DebtEventID = CurrentEvent.EventID,
                        DebtExpenseID = ExpenseDetail.ExpenseID,
                    });
                }
            }

            response = await _expenseService.AddExpense(new Models.ExpenseModel
            {
                ExpenseID = ExpenseDetail.ExpenseID,
                ExpenseName = ExpenseDetail.ExpenseName,
                ExpenseAmount = ExpenseDetail.ExpenseAmount,
                ExpenseCreditorName = ExpenseDetail.ExpenseCreditorName,
                ExpenseEventID = currentEvent.EventID
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
        private async Task AddParticipant()
        {
            if (SelectedParticipant == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Вы не выбрали участника", "Ок");
            }
            else
            {
                if (SelectedParticipants.Contains(SelectedParticipant))
                {
                    await Shell.Current.DisplayAlert("Уже добавлен", "Этот пользователь уже добавлен", "Ок");
                }
                else
                {
                    SelectedParticipants.Add(selectedParticipant);
                    debtAmount = expenseAmount / SelectedParticipants.Count;
                }
            }
        }

        [RelayCommand]
        private async Task GetParticipantInfoList()
        {
            var currentEventID = CurrentEvent.EventID;
            var participantsList = await _eventParticipantService.GetParticipantList(currentEventID);
            foreach (var participant in participantsList)
            {
                ParticipantList.Add(await _userService.GetUserByID(participant.ParticipantID));
            }
            
        }
    }
}
