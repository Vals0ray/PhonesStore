using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace SQLiteApp.ViewModel
{
    class RegistrationViewModel : Model.BaseVM
    {
        public string Login { get; set; }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                if (char.IsDigit(value[value.Length - 1])
                    && value.Length <= 9)
                {
                    phone = value;
                }
            }
        }

        public string Email { get; set; }

        public string Location { get; set; }

        private string Password { get; set; }

        public RelayCommand RegButtonClick => 
            new RelayCommand((value) =>
            {
                var passwordBox = value as System.Windows.Controls.PasswordBox;
                if (passwordBox != null)
                {
                    Password = passwordBox.Password;
                }

                User user = new User()
                {
                    Name = Login,
                    Phone = Phone,
                    Email = Email,
                    Location = Location,
                    Password = Password
                };

                string message = "";
                var results = new List<ValidationResult>();
                var context = new ValidationContext(user);
                if (!Validator.TryValidateObject(user, context, results, true))
                {
                    foreach (var error in results)
                    {
                        message += error.ErrorMessage + '\n';
                    }
                    MessageBox.Show(message);
                }
                else
                {
                    WindowsChange.OpenMainWindow(user);
                }
            });

        public RelayCommand BackButtonClick =>
        new RelayCommand((value) => WindowsChange.OpenLoginWindow());

        public RelayCommand ExitButtonClick => 
        new RelayCommand((value) => WindowsChange.ApplicationShutdown());
    }
}