using DeliRazApp.Models;
using DeliRazApp.ViewModels;
using DeliRazApp.Views;

namespace DeliRazApp
{
    public partial class App : Application
    {
        public static User UserDetails;
        public static UserModel CurrentUser;
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
