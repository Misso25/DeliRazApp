using DeliRazApp.ViewModels.Authorization;

namespace DeliRazApp.Views.Authorization;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
	
}
