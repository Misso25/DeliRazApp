using DeliRazApp.Models;
using DeliRazApp.ViewModels;

namespace DeliRazApp.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfilePageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}