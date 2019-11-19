using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SQLiteApp
{
    public partial class LoginWindow : Window
    {
        public ObservableCollection<User> Users { get; set; }
        public User connectUser { get; set; }

        public bool openRegistrationWindow = false;

        public LoginWindow(ObservableCollection<User> users)
        {
            InitializeComponent();
            Users = users;
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            foreach (User user in Users)
            {
                if (Login.Text == user.Name && Password.Password == user.Password)
                {
                    connectUser = user;
                    Close();
                    return;
                }
            }

            if (connectUser == null)
            {
                TextBoxErorr.Height = 16;
                TextBoxErorr.Text = "Uncorrect login or password, try again!";
                Login.BorderBrush = Brushes.Red;
                Password.BorderBrush = Brushes.Red;
            }
        }

        private new void KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxErorr.Height = 0;
            TextBoxErorr.Text = "";
            Login.BorderBrush = Brushes.Gray;
            Password.BorderBrush = Brushes.Gray;
        }

        public void RegBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
            openRegistrationWindow = true;
        }
    }
}