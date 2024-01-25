using DeliRazApp.Models;
using DeliRazApp.ViewModels;

namespace DeliRazApp.Views;

public partial class EventPage : ContentPage
{
    private EventPageViewModel _viewModel;
	public EventPage(EventPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetExpenseListCommand.Execute(null);
        _viewModel.GetParticipantListCommand.Execute(null);
        _viewModel.GetDebtListCommand.Execute(null);
    }
}