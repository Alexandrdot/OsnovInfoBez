namespace UserInfoMauiApp
{
	public class User
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public string UserName { get; set; }
        public string PhoneNumber { get; set; }
		public string Gender { get; set; }
		public string Weight { get; set; }
        public string Height { get; set; }
		public string Address { get; set; }
		public DateTime Birthday { get; set; }

        public User(string login, string password, string username, string phonenumber, string gender, string weight, string height, string address, DateTime date)
		{
			Login = login;
			Password = password;
			UserName = username;
			PhoneNumber = phonenumber;
			Gender = gender;
			Weight = weight;
			Height = height;
			Address = address;
			Birthday = date;
		}
	}
}

