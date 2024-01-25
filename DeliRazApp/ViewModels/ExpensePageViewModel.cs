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
    [QueryProperty(nameof(SelectedExpense), "SelectedExpense")]
    public partial class ExpensePageViewModel : ObservableObject
    {
        [ObservableProperty]
        ExpenseModel selectedExpense;
        public ObservableCollection<DebtModel> Debts { get; set; } = new ObservableCollection<DebtModel>();
        public ObservableCollection<UserModel> Participants { get; set; } = new ObservableCollection<UserModel>();

        private readonly IUserService _userService;
        private readonly IDebtService _debtService;
        private readonly IExpensePTService _expensePTService;

        public ExpensePageViewModel(IExpensePTService expensePTService, IUserService userService, IDebtService debtService)
        {
            _userService = userService;
            _expensePTService = expensePTService;
            _debtService = debtService;
        }

        [RelayCommand]
        async Task GetDebtList()
        {
            var debtList = await _debtService.GetDebtListByExpenseID(SelectedExpense.ExpenseID);
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
            var currentExpenseID = SelectedExpense.ExpenseID;
            var participantList = await _expensePTService.GetParticipantList(currentExpenseID);
            if (participantList?.Count > 0)
            {
                Participants.Clear();
                foreach (var participant in participantList)
                {
                    Participants.Add(await _userService.GetUserByID(participant.ParticipantID));
                }
            }
        }
    }
}
