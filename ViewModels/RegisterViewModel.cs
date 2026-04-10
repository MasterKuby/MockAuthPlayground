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
    
    
}