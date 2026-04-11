using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MockAuthPlayground.Models;
using MockAuthPlayground.Services;

namespace MockAuthPlayground.ViewModels;

public partial class RegisterViewModel : ViewModelBase
{
    // Boilerplate
    private readonly MainWindowViewModel _mainViewModel;
    private readonly UserService _userService = new UserService();

    public RegisterViewModel(MainWindowViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }
    // Boilerplate

    [ObservableProperty] private string _username = "";
    [ObservableProperty] private string _password = "";

    public void GoToLogin()
    {
        _mainViewModel.NavigateToLogin();
    }

    public void Register()
    {
        if (Username == "" | Password == "")
        {
            Console.WriteLine("Username & Password cannot be empty.");
        }
        else
        {
            _userService.Register(Username, Password);
            User? user = _userService.Login(Username, Password);
            // it will never be null cus we lowkey just registered them
            _mainViewModel.NavigateToDashboard(user);
        }
    
    }
}