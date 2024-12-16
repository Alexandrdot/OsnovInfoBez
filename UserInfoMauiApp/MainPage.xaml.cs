namespace UserInfoMauiApp;

public partial class MainPage : ContentPage
{
    private RegistrationViewModel _registrationViewModel;

    public MainPage(RegistrationViewModel registrationViewModel)
	{
        InitializeComponent();
        _registrationViewModel = registrationViewModel;
        BindingContext = _registrationViewModel;

        
		
	}

	async void OpenRegistrationPage(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new RegistrationPage(_registrationViewModel));
    }
    async void OpenUserInfoPage(object sender, EventArgs e)
    {
        if (App.RegistrationViewModel.User != null)
            await Navigation.PushAsync(new UserInfoPage(_registrationViewModel));
    }
}


