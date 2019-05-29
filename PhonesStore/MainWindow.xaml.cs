using System;
using System.Windows;

namespace SQLiteApp
{
    public partial class MainWindow : Window
    {
        ApplicationViewModel applicationViewModel;

        public MainWindow()
        {
            InitializeComponent();
            applicationViewModel = new ApplicationViewModel();
            DataContext = applicationViewModel;

            Loaded += RangeSlider_Loaded;
        }

        void RangeSlider_Loaded(object sender, RoutedEventArgs e)
        {
            LowerSlider.ValueChanged += LowerSlider_ValueChanged;
            UpperSlider.ValueChanged += UpperSlider_ValueChanged;
        }

        private void LowerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpperSlider.Value = Math.Max(UpperSlider.Value, LowerSlider.Value);
        }

        private void UpperSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LowerSlider.Value = Math.Min(UpperSlider.Value, LowerSlider.Value);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (applicationViewModel.close)
            {
                Close();
            }
            else
            {
                Name.Text = applicationViewModel.ConnectUser.Name;
                Location.Text = applicationViewModel.ConnectUser.Location;
                Phone.Text = applicationViewModel.ConnectUser.Phone;
                Email.Text = applicationViewModel.ConnectUser.Email;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            applicationViewModel.OpenAddWindow();
        }

        private void ButtonLeave_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            applicationViewModel.OpenLoginWindow();
            Window_Loaded(null, null);
            if (applicationViewModel.close)
            {
                return;
            }
            Show();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            applicationViewModel.OpenDetailsWindow(phonesList.SelectedItem);
        }


    }
}