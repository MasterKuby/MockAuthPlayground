using MockAuthPlayground.Models;
using MockAuthPlayground.Services;

namespace MockAuthPlayground.ViewModels;

public partial class DashboardViewModel : ViewModelBase
{
    // Boilerplate
    private readonly MainWindowViewModel _mainViewModel;
    private readonly UserService _userService = new UserService();
    public DashboardViewModel(MainWindowViewModel mainViewModel, User user)
    {
        _mainViewModel = mainViewModel;
    }
    // Boilerplate
}