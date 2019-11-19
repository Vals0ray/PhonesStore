using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SQLiteApp
{
    public partial class AddWindow : Window
    {
        public Phone addNewPhone;

        public AddWindow()
        {
            InitializeComponent();
        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            openFileDialog.Title = "Choose photo for your phone";
            if (openFileDialog.ShowDialog() == true)
            {
                string picLoc1 = openFileDialog.FileName.ToString();
                Image.Source = new BitmapImage(new Uri(picLoc1));
            }
        }

        private void AddnewPhone_Click(object sender, RoutedEventArgs e)
        {
            bool errors = false;
            addNewPhone = new Phone();

            if (Image.Source == null)
            {
                errors = true;
            }

            if(Model.Text.Length == 0 || Model.Text.Length > 50)
            {
                Model.BorderBrush = Brushes.Red;
                errors = true;
            }


            if (Price.Text.Length == 0 || Price.Text.Length > 50)
            {
                Price.BorderBrush = Brushes.Red;
                errors = true;
            }

            if (Screen.Text.Length == 0 || Screen.Text.Length > 50)
            {
                Screen.BorderBrush = Brushes.Red;
                errors = true;
            }

            if (Battery.Text.Length == 0 || Battery.Text.Length > 50)
            {
                Battery.BorderBrush = Brushes.Red;
                errors = true;
            }

            if (OperativeMemory.Text.Length == 0 || OperativeMemory.Text.Length > 50)
            {
                OperativeMemory.BorderBrush = Brushes.Red;
                errors = true;
            }

            if (BuildInMemory.Text.Length == 0 || BuildInMemory.Text.Length > 50)
            {
                BuildInMemory.BorderBrush = Brushes.Red;
                errors = true;
            }

            if (MainCamera.Text.Length == 0 || MainCamera.Text.Length > 50)
            {
                MainCamera.BorderBrush = Brushes.Red;
                errors = true;
            }

            if (FrontCamera.Text.Length == 0 || FrontCamera.Text.Length > 50)
            {
                FrontCamera.BorderBrush = Brushes.Red;
                errors = true;
            }

            if (errors)
            {
                addNewPhone = null;
                return;
            }
            else
            {
                addNewPhone.Image = Image.Source.ToString();
                addNewPhone.Model = Model.Text;
                addNewPhone.Company = Company.Text;
                addNewPhone.Price = Convert.ToInt32(Price.Text);
                addNewPhone.Screen = Convert.ToDouble(Screen.Text);
                addNewPhone.Battery = Convert.ToInt32(Battery.Text);
                addNewPhone.OperativeMemory = Convert.ToInt32(OperativeMemory.Text);
                addNewPhone.BuiltInMemory = Convert.ToInt32(BuildInMemory.Text);
                addNewPhone.MainCamera = Convert.ToInt32(MainCamera.Text);
                addNewPhone.FrontCamera = Convert.ToInt32(FrontCamera.Text);
                addNewPhone.Description = Description.Text;
                Close();
            }
        }

        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Screen_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"\d\.\d");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Model_KeyDown(object sender, KeyEventArgs e)
        {
            Model.BorderBrush = Brushes.Gray;
        }

        private void Price_KeyDown(object sender, KeyEventArgs e)
        {
            Price.BorderBrush = Brushes.Gray;
        }

        private void Company_KeyDown(object sender, KeyEventArgs e)
        {
            Company.BorderBrush = Brushes.Gray;
        }

        private void LoadImage_KeyDown(object sender, KeyEventArgs e)
        {
            LabelError.Height = 0;
            LabelError.Content = "";
        }

        private void Screen_KeyDown(object sender, KeyEventArgs e)
        {
            Screen.BorderBrush = Brushes.Gray;
        }

        private void Battery_KeyDown(object sender, KeyEventArgs e)
        {
            Battery.BorderBrush = Brushes.Gray;
        }

        private void OperativeMemory_KeyDown(object sender, KeyEventArgs e)
        {
            OperativeMemory.BorderBrush = Brushes.Gray;
        }

        private void BuildInMemory_KeyDown(object sender, KeyEventArgs e)
        {
            BuildInMemory.BorderBrush = Brushes.Gray;
        }

        private void MainCamera_KeyDown(object sender, KeyEventArgs e)
        {
            MainCamera.BorderBrush = Brushes.Gray;
        }

        private void FrontCamera_KeyDown(object sender, KeyEventArgs e)
        {
            FrontCamera.BorderBrush = Brushes.Gray;
        }
    }
}
