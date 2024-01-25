namespace DeliRazApp.Views;
using DeliRazApp.ViewModels;

public partial class ExpensePage : ContentPage
{
	private ExpensePageViewModel _viewModel;
	public ExpensePage(ExpensePageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetParticipantListCommand.Execute(null);
        _viewModel.GetDebtListCommand.Execute(null);
    }
}