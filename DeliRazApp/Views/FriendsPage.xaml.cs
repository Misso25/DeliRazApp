using DeliRazApp.Models;
using DeliRazApp.ViewModels;

namespace DeliRazApp.Views;

public partial class FriendsPage : ContentPage
{
    private FriendsPageViewModel _viewModel;
    public FriendsPage(FriendsPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetFriendInfoListCommand.Execute(null);
    }
}