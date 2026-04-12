using CommunityToolkit.Mvvm.ComponentModel;
using MockAuthPlayground.Models;
using MockAuthPlayground.Services;

namespace MockAuthPlayground.ViewModels;

public partial class DashboardViewModel : ViewModelBase
{
    // Boilerplate
    private readonly MainWindowViewModel _mainViewModel;
    private readonly UserService _userService = new UserService();
    private readonly User _user;

    [ObservableProperty] private string _username;
    [ObservableProperty] private string _password;
    [ObservableProperty] private int _funds;
    [ObservableProperty] private int _id;
    [ObservableProperty] private bool _isWelcomeVisible = true;
    
    public DashboardViewModel(MainWindowViewModel mainViewModel, User user)
    {
        _mainViewModel = mainViewModel;
        _user = user;
        
        Username = user.Username;
        Funds = user.Funds;
        Id = user.Id;
        Password = user.Password;
    }
    // Boilerplate

    public void Logout()
    {
        _mainViewModel.NavigateToLogin();
    }
    
}