using DeliRazApp.Controls;
using DeliRazApp.Models;
using DeliRazApp.Views;
using DeliRazApp.Views.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.ViewModels.Authorization
{
    public partial class LoadingPageViewModel
    {
        public LoadingPageViewModel()
        {
            //CheckUserLoginDetails();
            CheckUserAuthorizated();
        }

        //private async void CheckUserLoginDetails()
        //{
        //    string userDetailsStr = Preferences.Get(nameof(App.UserDetails), "");

        //    if (string.IsNullOrWhiteSpace(userDetailsStr))
        //    {
        //        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        //    }
        //    else
        //    {
        //        var userInfo = JsonConvert.DeserializeObject<User>(userDetailsStr);
        //        App.UserDetails = userInfo;
        //        AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
        //        await Shell.Current.GoToAsync($"//{nameof(EventsPage)}");
        //    }
        //}

        private async void CheckUserAuthorizated()
        {
            string currentUserStr = Preferences.Get(nameof(App.CurrentUser), "");

            if (string.IsNullOrWhiteSpace(currentUserStr))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                var userInfo = JsonConvert.DeserializeObject<UserModel>(currentUserStr);
                App.CurrentUser = userInfo;
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                await Shell.Current.GoToAsync($"//{nameof(EventsPage)}");
            }
        }
    }
}
