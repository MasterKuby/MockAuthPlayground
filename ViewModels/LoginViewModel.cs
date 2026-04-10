using CommunityToolkit.Mvvm.ComponentModel;
using MockAuthPlayground.Services;

namespace MockAuthPlayground.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    // Boilerplate
    private readonly MainWindowViewModel _mainViewModel;
    private readonly UserService _userService = new UserService();
    public LoginViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }
    // Boilerplate
    
    [ObservableProperty] private string username = "";
    [ObservableProperty] private string password = "";

    public void GoToRegister()
    {
        _mainViewModel.NavigateToRegister();
    }
}