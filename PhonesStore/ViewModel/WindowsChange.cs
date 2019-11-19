using System.Windows;

namespace SQLiteApp.ViewModel
{
    internal static class WindowsChange
    {
        static WindowsChange()
        {

        }

        public static void OpenRegistrationWindow()
        {
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = regWindow;
        }

        public static void OpenLoginWindow()
        {
            View.LoginWindow loginWindow = new View.LoginWindow();
            loginWindow.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = loginWindow;
        }

        public static void OpenMainWindow(User ConnectedUser)
        {
            MainWindow mainWindow = new MainWindow
            {
                DataContext = new ApplicationViewModel(ConnectedUser)
            };

            mainWindow.Show();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = mainWindow;
        }

        public static void CloseSomeWindow<T>()
        {
            var windows = Application.Current.Windows;
            
            foreach (Window window in windows)
            {
                if (window is T)
                {
                    window.Close();
                }
            }
        }

        public static void ApplicationShutdown()
        {
            Application.Current.Shutdown();
        }
    }
}
