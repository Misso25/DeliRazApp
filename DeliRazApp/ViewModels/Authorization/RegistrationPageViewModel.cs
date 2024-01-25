using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliRazApp.Controls;
using DeliRazApp.Models;
using DeliRazApp.Services;
using DeliRazApp.Views;
using DeliRazApp.Views.Authorization;
using Newtonsoft.Json;

namespace DeliRazApp.ViewModels.Authorization
{
    [QueryProperty(nameof(CurrentUser), "CurrentUser")]
    public partial class RegistrationPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserModel _currentUser = new UserModel();

        private readonly IUserService _userService;

        public RegistrationPageViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        public async Task RegisterUser()
        {
            int response = -1;

            if (await _userService.GetUserByLogin(CurrentUser.UserLogin) != null) 
            {
                await Shell.Current.DisplayAlert("Ошибка", "Такой логин уже зарегестрирован", "Ок");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(CurrentUser.UserName) && !string.IsNullOrWhiteSpace(CurrentUser.UserLogin) && !string.IsNullOrWhiteSpace(CurrentUser.UserPassword))
                {
                    response = await _userService.AddUser(new Models.UserModel
                    {
                        UserName = CurrentUser.UserName,
                        UserLogin = CurrentUser.UserLogin,
                        UserPassword = CurrentUser.UserPassword,
                    });

                    var currentUser = await _userService.GetUserByLogin(CurrentUser.UserLogin);

                    if (Preferences.ContainsKey(nameof(App.CurrentUser)))
                    {
                        Preferences.Remove(nameof(App.CurrentUser));
                    }
                    string currentUserStr = JsonConvert.SerializeObject(currentUser);
                    Preferences.Set(nameof(App.CurrentUser), currentUserStr);
                    App.CurrentUser = currentUser;
                    AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

                    if (response > 0)
                    {
                        await Shell.Current.GoToAsync($"//{nameof(EventsPage)}");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Заполнены не все поля", "Заполните все поля!", "OK");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Заполнены не все поля", "Заполните все поля!", "OK");
                }
            }
        }

        [RelayCommand]
        async Task OpenLoginPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
