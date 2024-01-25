using DeliRazApp.ViewModels;

namespace DeliRazApp.Views;

public partial class EditingProfilePage : ContentPage
{
	public EditingProfilePage(EditingProfilePageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}