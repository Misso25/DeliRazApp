using DeliRazApp.ViewModels;
using DeliRazApp.Views;
using DeliRazApp.Views.Authorization;

namespace DeliRazApp
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
            this.BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(EventsPage), typeof(EventsPage));
            Routing.RegisterRoute(nameof(FriendsPage), typeof(FriendsPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(EditingProfilePage), typeof(EditingProfilePage));
            Routing.RegisterRoute(nameof(EventsCreatePage), typeof(EventsCreatePage));
            Routing.RegisterRoute(nameof(EventPage), typeof(EventPage));
            Routing.RegisterRoute(nameof(FriendProfilePage), typeof(FriendProfilePage));
            Routing.RegisterRoute(nameof(ExpensePage), typeof(ExpensePage));
            Routing.RegisterRoute(nameof(CreateExpensePage), typeof(CreateExpensePage));

        }
	}

}