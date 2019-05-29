using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SQLiteApp
{
    public partial class LoginWindow : Window
    {
        public ObservableCollection<User> users { get; set; }
        public User connectUser { get; set; }
        public bool openRegistrationWindow = false;

        public LoginWindow(ObservableCollection<User> u)
        {
            InitializeComponent();
            users = u;
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            foreach (User u in users)
            {
                if (Login.Text == u.Name && Password.Password == u.Password)
                {
                    TextBoxErorr.Height = 16;
                    TextBoxErorr.Text = $"Connected as {u.Name}!";
                    connectUser = u;
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

        private void KeyDown(object sender, KeyEventArgs e)
        {
            TextBoxErorr.Height = 0;
            TextBoxErorr.Text = "";
            Login.BorderBrush = Brushes.Gray;
            Password.BorderBrush = Brushes.Gray;

            if (e.Key == Key.Enter)
            {
                ButtonEnter_Click(null, null);
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Text boxes
        private void ForgotBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ForgotBox.Foreground = new SolidColorBrush(Colors.Orange);
            ForgotBox.TextDecorations = TextDecorations.Underline;
            ForgotBox.Cursor = Cursors.Hand;
        }

        private void ForgotBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ForgotBox.Foreground = new SolidColorBrush(Colors.White);
            ForgotBox.TextDecorations = null;
            ForgotBox.Cursor = Cursors.Arrow;
        }

        private void RegBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            RegBox.Foreground = new SolidColorBrush(Colors.Orange);
            RegBox.TextDecorations = TextDecorations.Underline;
            RegBox.Cursor = Cursors.Hand;
        }

        private void RegBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            RegBox.Foreground = new SolidColorBrush(Colors.White);
            RegBox.TextDecorations = null;
            RegBox.Cursor = Cursors.Arrow;
        }

        // Buttons
        private void EnterButton_MouseEnter(object sender, MouseEventArgs e)
        {
            EnterButton.Background = Brushes.Orange;
            EnterButton.Cursor = Cursors.Hand;
        }

        private void EnterButton_MouseLeave(object sender, MouseEventArgs e)
        {
            EnterButton.Background = Brushes.GhostWhite;
            EnterButton.Cursor = Cursors.Arrow;
        }

        private void ExitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitButton.Background = Brushes.Orange;
            ExitButton.Cursor = Cursors.Hand;
        }

        private void ExitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ExitButton.Background = Brushes.GhostWhite;
            ExitButton.Cursor = Cursors.Arrow;
        }

        public void RegBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
            openRegistrationWindow = true;
        }
    }
}
