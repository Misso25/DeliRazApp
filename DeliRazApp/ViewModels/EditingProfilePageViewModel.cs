using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeliRazApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.ViewModels
{
    public partial class EditingProfilePageViewModel : ObservableObject
    {
        [RelayCommand]
        async Task SaveInfoProfile()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
