namespace DeliRazApp.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

		if (App.CurrentUser != null)
		{
			lblNameUser.Text = App.CurrentUser.UserName;
			lblLoginName.Text = App.CurrentUser.UserLogin;
		}
	}
}