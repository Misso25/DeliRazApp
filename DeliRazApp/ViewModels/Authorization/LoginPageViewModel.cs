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
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserModel _currentUser = new UserModel();

        private readonly IUserService _userService;

        public LoginPageViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        async Task Login()
        {
            if (!string.IsNullOrWhiteSpace(CurrentUser.UserLogin) && !string.IsNullOrWhiteSpace(CurrentUser.UserPassword))
            {
                if (await _userService.GetUserByLogin(CurrentUser.UserLogin) == null)
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Такой аккаунт еще не зарегестрирован", "Ок");
                }
                else
                {
                    var currentUser = await _userService.GetUserByLogin(CurrentUser.UserLogin);
                    if (currentUser.UserPassword != CurrentUser.UserPassword)
                    {
                        await Shell.Current.DisplayAlert("Ошибка", "Неверный пароль!", "Ок");
                    }
                    else
                    {
                        if (Preferences.ContainsKey(nameof(App.CurrentUser)))
                        {
                            Preferences.Remove(nameof(App.CurrentUser));
                        }
                        string currentUserStr = JsonConvert.SerializeObject(currentUser);
                        Preferences.Set(nameof(App.CurrentUser), currentUserStr);
                        App.CurrentUser = currentUser;
                        AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

                        await Shell.Current.GoToAsync($"//{nameof(EventsPage)}");
                    }
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Заполнены не все поля", "Заполните все поля!", "OK");
            }
        }

        [RelayCommand]
        async Task OpenRegistrationPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
        }
    }
}
