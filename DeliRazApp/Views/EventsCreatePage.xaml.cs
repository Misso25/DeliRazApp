using DeliRazApp.ViewModels;

namespace DeliRazApp.Views;

public partial class EventsCreatePage : ContentPage
{
	public EventsCreatePage(EventsCreatePageViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}