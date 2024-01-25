using CommunityToolkit.Mvvm.ComponentModel;
using DeliRazApp.Models;
using DeliRazApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.ViewModels
{
    [QueryProperty(nameof(SelectedFriend), "SelectedFriend")]
    public partial class FriendProfilePageViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel selectedFriend;
    }
}
