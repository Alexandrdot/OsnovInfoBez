using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows.Input;

namespace UserInfoMauiApp
{
	public class RegistrationViewModel:INotifyPropertyChanged
	{
		public ICommand SaveCommand { get; set; }
        public ICommand EnterCommand { get; set; }
        public ICommand IsEnabledSaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ObservableCollection<User> Users { get; set; } = new();
        string password = "";
        User user = null;
		string login = "";
		string truepassword = "";
		string username = "";
		string weight = "";
		string height = "";
		string gender = "";
		string phonenumber = "";
		string address = "";
		DateTime birthday = DateTime.MinValue;
        public RegistrationViewModel()
		{
            SaveCommand = new Command(SaveInfoAboutUser);
			EnterCommand = new Command(EnterProgramm);
            CancelCommand = new Command(Cancel);
		}
		public async void SaveInfoAboutUser()
		{
            if ((!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(TruePassword)
                && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Weight)
                && !string.IsNullOrEmpty(Height) && !string.IsNullOrEmpty(Gender)
                && !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Address)
                ) == false)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Введите все данные", "Ок");
                return;
            }
            if(TruePassword != Password)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Пароли не совпадают", "Ок");
                return;
            }
            if(Password.Length <= 4)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Пароль не надежен", "Ок");
                return;
            }
            if (!Password.Any(char.IsDigit) || !Password.Any(char.IsLetter))
            {
                await App.Current.MainPage.DisplayAlert("Ошибка", "Пароль должен содержать хотя бы одну букву и одну цифру", "Ок");
                return;
            }
            if (Users.Count != 0)
            {
                foreach (User o in Users)
                {
                    if (o.Login == Login)
                    {
                        await App.Current.MainPage.DisplayAlert("Ошибка", "Логин занят", "Ок");
                        return;
                    }  
                }
            }
            Users.Add(new User(Login, HashPassword(Password), UserName, PhoneNumber, Gender, Weight, Height, Address, Birthday));
            Clear();
            SaveInfo.SaveViewModels();
            await App.Current.MainPage.DisplayAlert("Уведомление", "Данные сохранены", "Ок");
            await App.Current.MainPage.Navigation.PopAsync();
		}
        async void Cancel()
        {
            Clear();
            User = null;
            await App.Current.MainPage.Navigation.PopAsync();
        }
        async void EnterProgramm()
		{
            //if (Users.Count != 0)
            if (Login != null && Password != null && Login !="" && Password != "")
            {
                foreach (User o_o in Users)
                {
                    if (o_o.Login == Login && o_o.Password == HashPassword(Password))
                    {
                        User = o_o;
                        break;
                    }
                }
                if (User == null)
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка", "Пользователь не найден", "Ок");
                    Clear();
                    return;
                }
            }
            

            //await App.Current.MainPage.Navigation.PushAsync(new UserInfoPage());
		}
        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        public void Clear()
        {
            Login = "";
            Password = "";
            UserName = "";
            PhoneNumber = "";
            Gender = "";
            Weight = "";
            Height = "";
            Address = "";
            Birthday = DateTime.MinValue;
            TruePassword = "";
        }
        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }

		public string Password
		{
			get => password;
			set
			{
				password = value;
				OnPropertyChanged();
			}
		}
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public string TruePassword
        {
            get => truepassword;
            set
            {
                truepassword = value;
                OnPropertyChanged();
            }
        }
        public string Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged();
            }
        }
        public string Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged();
            }
        }
        public string UserName
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => phonenumber;
            set
            {
                phonenumber = value;
                OnPropertyChanged();
            }
        }
        public DateTime Birthday
        {
            get => birthday;
            set
            {
                birthday = value;
                OnPropertyChanged();
            }
        }
     
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

	}
}

