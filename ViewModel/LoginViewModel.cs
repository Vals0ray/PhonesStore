using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace SQLiteApp.ViewModel
{
    class LoginViewModel : Model.BaseVM
    {
        private readonly ApplicationContext db = new ApplicationContext();

        public ObservableCollection<User> Users { get; set; }

        public User ConnectedUser { get; set; }

        public string Login { get; set; } = "Yaroslav";

        private string Password { get; set; }

        public LoginViewModel()
        {
            db.Users.Load();
            Users = db.Users.Local;
        }

        public RelayCommand LoginButtonClick => 
            new RelayCommand((value) =>
            {
                var passwordBox = value as System.Windows.Controls.PasswordBox;
                if (passwordBox != null)
                {
                    Password = passwordBox.Password;
                }

                if (Users.Any(user => user.Name == Login && user.Password == Password))
                {
                    ConnectedUser = Users?.First(user => user.Name == Login && user.Password == Password);
                    WindowsChange.OpenMainWindow(ConnectedUser);
                }
                else
                {
                    MessageBox.Show("Uncorrect Login or Password!", "User has not found");
                }
            });

        public RelayCommand RegTextBlockClick => 
        new RelayCommand((value) => WindowsChange.OpenRegistrationWindow());

        public RelayCommand ExitButtinClick => 
        new RelayCommand((value) => WindowsChange.ApplicationShutdown());
    }
}