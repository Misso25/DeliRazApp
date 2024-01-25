using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliRazApp.Models;
using DeliRazApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        [ObservableProperty]
        string userLogin = App.CurrentUser.UserLogin;
        [ObservableProperty]
        string userName = App.CurrentUser.UserName;
        [ObservableProperty]
        string userID = App.CurrentUser.UserID.ToString();
        [ObservableProperty]
        string userPhoneNumber = App.CurrentUser.UserPhoneNumber;
        [ObservableProperty]
        string userBankName = App.CurrentUser.UserBankName;

        [RelayCommand]
        async Task EditeProfile()
        {
            await Shell.Current.GoToAsync(nameof(EditingProfilePage));
        }
    }
}
