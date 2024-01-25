using DeliRazApp.ViewModels;

namespace DeliRazApp.Views;

public partial class EventsPage : ContentPage
{
	private EventsPageViewModel _viewModel;
	public EventsPage(EventsPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.GetEventListCommand.Execute(null);
    }
}