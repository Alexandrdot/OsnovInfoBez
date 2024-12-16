namespace UserInfoMauiApp;

public partial class RegistrationPage : ContentPage
{
    private RegistrationViewModel _registrationViewModel;
    public RegistrationPage(RegistrationViewModel registrationViewModel)
	{
		InitializeComponent();
        _registrationViewModel = registrationViewModel;
        BindingContext = _registrationViewModel;
    }
    private void TextToChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry == null || string.IsNullOrEmpty(e.NewTextValue))
            return;
        // Фильтруем только буквы (и пробелы между ними)
        string filteredText = new string(e.NewTextValue.Where(c => char.IsLetter(c) || c == ' ').ToArray());
        // Если текст изменился, обновляем текст в поле
        if (e.NewTextValue != filteredText)
            entry.Text = filteredText;
    }
    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;

        // Оставляем только цифры
        string filteredText = new string(e.NewTextValue.Where(char.IsDigit).ToArray());

        // Если текст изменился после фильтрации, обновляем поле ввода
        if (e.NewTextValue != filteredText)
        {
            entry.Text = filteredText;
        }
    }

}
