using CommunityToolkit.Mvvm.Input;
using DeliRazApp.Views.Authorization;
using DeliRazApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DeliRazApp.Models;

namespace DeliRazApp.ViewModels
{
    public partial class AppShellViewModel
    {
        [RelayCommand]
        async Task SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.CurrentUser)))
            {
                Preferences.Remove(nameof(App.CurrentUser));
            }
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
