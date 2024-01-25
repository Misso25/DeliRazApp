using DeliRazApp.ViewModels;

namespace DeliRazApp.Views;

public partial class FriendProfilePage : ContentPage
{
	public FriendProfilePage(FriendProfilePageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}