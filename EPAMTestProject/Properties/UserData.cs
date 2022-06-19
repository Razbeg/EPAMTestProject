using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace EPAMTestProject.Properties
{
    public class UserData
    {
        private User _userData;

        public string InvalidEmail = "asdf";
        public string InvalidPassword = "aTd32f@";

        public string EmptyEmail = "";
        public string EmptyPassword = "";

        public string ValidEmail => _userData.Email;
        public string ValidPassword => _userData.Password;

        public void InitializeData()
        {
            try
            {
                var jsonDirectory = $"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent}\\Properties\\UserData.json";

                ReadJSON(jsonDirectory);
            }
            catch (Exception ex)
            {

            }
        }

        private void ReadJSON(string jsonDirectory)
        {
            var jsonFile = File.ReadAllText(jsonDirectory);

            _userData = JsonSerializer.Deserialize<User>(jsonFile);
        }
    }
}
