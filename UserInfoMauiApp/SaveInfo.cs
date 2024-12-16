using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Xml;

namespace UserInfoMauiApp
{
    public class SavedData
    {
        public List<User> UserSave { get; set; }
    }

    public class SaveInfo
    {
        private static readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Data3.json");
        public static void SaveViewModels()
        {


            try
            {
                var dataToSave = new SavedData
                {
                    UserSave = new List<User>(App.RegistrationViewModel.Users),
                };
                string jsonData = JsonConvert.SerializeObject(dataToSave, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения ViewModel: {ex.Message}");
            }
        }

        public static void LoadViewModels()
        {

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                var loadedData = JsonConvert.DeserializeObject<SavedData>(jsonData);

                if (loadedData != null)
                {
                    App.RegistrationViewModel.Users = new ObservableCollection<User>(loadedData.UserSave);
                }
            }
        }
        
    }
}

