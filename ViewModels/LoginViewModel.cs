using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MockAuthPlayground.Models;
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
    
    [ObservableProperty] private string _username = "";
    [ObservableProperty] private string _password = "";
    
    public void GoToRegister()
    {
        _mainViewModel.NavigateToRegister();
    }
    
    public void Login()
    {
        User? user = _userService.Login(Username, Password);

        if (user != null)
        {
            _mainViewModel.NavigateToDashboard(user);
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }
        
    }
}