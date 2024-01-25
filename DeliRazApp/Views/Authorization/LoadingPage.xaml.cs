using DeliRazApp.ViewModels.Authorization;

namespace DeliRazApp.Views.Authorization;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}