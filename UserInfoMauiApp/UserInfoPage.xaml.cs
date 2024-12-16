namespace UserInfoMauiApp;

public partial class UserInfoPage : ContentPage
{
    private RegistrationViewModel _registrationViewModel;
    public UserInfoPage(RegistrationViewModel registrationViewModel)
	{
		InitializeComponent();
        _registrationViewModel = registrationViewModel;
        BindingContext = _registrationViewModel;
    }
}
