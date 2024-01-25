using DeliRazApp.Views.Authorization;
using DeliRazApp.ViewModels.Authorization;
using DeliRazApp.ViewModels;
using DeliRazApp.Views;
using DeliRazApp.Services;

namespace DeliRazApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Evolventa-Regular.ttf", "EvolventaRegular");
                fonts.AddFont("Evolventa-Bold.ttf", "EvolventaBold");
            });

        //Services
        builder.Services.AddTransient<IEventService, EventService>();
        builder.Services.AddTransient<IExpenseService, ExpenseService>();
        builder.Services.AddTransient<IDebtService, DebtService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IFriendService, FriendService>();
        builder.Services.AddTransient<IEventParticipantService, EventParticipantService>();
        builder.Services.AddTransient<IExpensePTService, ExpensePTService>();

        //Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoadingPage>();
        builder.Services.AddTransient<EventsPage>();
        builder.Services.AddTransient<EventsCreatePage>();
        builder.Services.AddTransient<FriendsPage>();
        builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddTransient<CreateExpensePage>();
        builder.Services.AddTransient<EditingProfilePage>();
        builder.Services.AddTransient<EventPage>();
        builder.Services.AddTransient<ExpensePage>();
        builder.Services.AddTransient<FriendProfilePage>();
        builder.Services.AddTransient<RegistrationPage>();

        //View Models
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<LoadingPageViewModel>();
        builder.Services.AddTransient<EventsPageViewModel>();
        builder.Services.AddTransient<EventsCreatePageViewModel>();
        builder.Services.AddTransient<FriendsPageViewModel>();
        builder.Services.AddSingleton<ProfilePageViewModel>();
        builder.Services.AddTransient<CreateExpensePageViewModel>();
        builder.Services.AddTransient<EditingProfilePageViewModel>();
        builder.Services.AddTransient<EventPageViewModel>();
        builder.Services.AddTransient<ExpensePageViewModel>();
        builder.Services.AddTransient<FriendProfilePageViewModel>();
        builder.Services.AddTransient<RegistrationPageViewModel>();

        return builder.Build();
    }
}
