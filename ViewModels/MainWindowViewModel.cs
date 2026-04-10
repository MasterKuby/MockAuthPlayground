using CommunityToolkit.Mvvm.ComponentModel;
using MockAuthPlayground.Models;

namespace MockAuthPlayground.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase currentView;
    
    public MainWindowViewModel()
    {
        CurrentView = new LoginViewModel(this);
    }
    
    public void NavigateToLogin()
    {
        CurrentView = new LoginViewModel(this);
    }
    
    public void NavigateToRegister()
    {
        CurrentView = new RegisterViewModel(this);
    }
    
    public void NavigateToDashboard(User user)
    {
        CurrentView = new DashboardViewModel(this, user);
    }
    
    public string Greeting { get; } = "Welcome to Avalonia!";
}