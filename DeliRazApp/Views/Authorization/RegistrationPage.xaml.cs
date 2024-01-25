using DeliRazApp.ViewModels.Authorization;

namespace DeliRazApp.Views.Authorization;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage(RegistrationPageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}