using DeliRazApp.ViewModels;

namespace DeliRazApp.Views;

public partial class CreateExpensePage : ContentPage
{
	public CreateExpensePageViewModel _viewModel;
	public CreateExpensePage(CreateExpensePageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetParticipantInfoListCommand.Execute(null);
    }
}