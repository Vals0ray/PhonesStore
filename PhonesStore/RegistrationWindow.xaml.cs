using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SQLiteApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public User regUser;
        public bool openLoginWindow = false;

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            regUser = new User();
            bool errors = false;
            Login_KeyDown(null, null);
            Phone_KeyDown(null, null);
            Email_KeyDown(null, null);
            Password_KeyDown(null, null);

            if (Login.Text.Length == 0)
            {
                TextBoxLoginErorr.Height = 16;
                TextBoxLoginErorr.Text = "Ви не ввели логін!";
                Login.BorderBrush = Brushes.Red;
                errors = true;
            }
            if (Phone.Text.Length == 0)
            {
                TextBoxPhoneErorr.Height = 16;
                TextBoxPhoneErorr.Text = "Ви не ввели номер телефону!";
                Phone.BorderBrush = Brushes.Red;
                errors = true;
            }
            if (Email.Text.Length == 0)
            {
                TextBoxEmailErorr.Height = 16;
                TextBoxEmailErorr.Text = "Ви не ввели почту!";
                Email.BorderBrush = Brushes.Red;
                errors = true;
            }
            if (Password.Password.Length == 0)
            {
                TextBoxPasswordErorr.Height = 16;
                TextBoxPasswordErorr.Text = "Ви не ввели пароль!";
                Password.BorderBrush = Brushes.Red;
                errors = true;
            }
            
            if (Login.Text.Length > 26 || Login.Text.Length < 6)
            {
                TextBoxLoginErorr.Height = 32;
                TextBoxLoginErorr.Text = "Логін повинен бути не більшим за 26 символів,\nта не меншим за 6 символів";
                Login.BorderBrush = Brushes.Red;
                errors = true;
            }
            else
            {
                regUser.Name = Login.Text;
            }

            if(Password.Password.Length < 6 || Password.Password.Length > 26)
            {
                TextBoxPasswordErorr.Height = 32;
                TextBoxPasswordErorr.Text = "Пароль повинен бути не більшим за 26 символів,\nта не меншим за 6 символів";
                Password.BorderBrush = Brushes.Red;
                errors = true;
            }
            else
            {
                regUser.Password = Password.Password;
            }

            if(Phone.Text.Length != 9)
            {
                TextBoxPhoneErorr.Height = 16;
                TextBoxPhoneErorr.Text = "Некоректний ввід номера телефону!";
                Phone.BorderBrush = Brushes.Red;
                errors = true;
            }
            else
            {
                regUser.Phone = "+380" + Phone.Text;
            }

            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if(Regex.IsMatch(Email.Text, pattern))
            {
                regUser.Email = Email.Text;
            }
            else
            {
                TextBoxEmailErorr.Height = 16;
                TextBoxEmailErorr.Text = "Некоректний ввід почти!";
                Email.BorderBrush = Brushes.Red;
                errors = true;
            }

            regUser.Location = Location.Text;

            if (errors)
            {
                regUser = null;
                return;
            }
            Close();
        }

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Login_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxLoginErorr.Height = 0;
            TextBoxLoginErorr.Text = "";
            Login.BorderBrush = Brushes.Gray;
        }

        private void Phone_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxPhoneErorr.Height = 0;
            TextBoxPhoneErorr.Text = "";
            Phone.BorderBrush = Brushes.Gray;
        }

        private void Email_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxEmailErorr.Height = 0;
            TextBoxEmailErorr.Text = "";
            Email.BorderBrush = Brushes.Gray;
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxPasswordErorr.Height = 0;
            TextBoxPasswordErorr.Text = "";
            Password.BorderBrush = Brushes.Gray;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Close();
            openLoginWindow = true;
        }
    }
}
