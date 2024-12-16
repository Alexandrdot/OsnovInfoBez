namespace UserInfoMauiApp;

public partial class App : Application
{
    public static RegistrationViewModel RegistrationViewModel { get; set; } = new();
    
    public App()
	{
		InitializeComponent();
        SaveInfo.LoadViewModels();
        MainPage = new NavigationPage(new MainPage(RegistrationViewModel));
    }
}

