using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SQLiteApp
{
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(Phone selectedPhone, User SellerUser)
        {
            InitializeComponent();

            Image.Source = new BitmapImage(new Uri(selectedPhone.Image));
            Model.Text = selectedPhone.Model;
            Company.Text = selectedPhone.Company;
            Price.Text = selectedPhone.Price.ToString() + " грн";
            Screen.Text = selectedPhone.Screen.ToString() + "''";
            Battery.Text = selectedPhone.Battery.ToString() + " mA*год";
            OperativeMemory.Text = selectedPhone.OperativeMemory.ToString() + " ГБ";
            BuiltInMemory.Text = selectedPhone.MainCamera.ToString() + " ГБ";
            MainCamera.Text = selectedPhone.MainCamera.ToString() + " Мп";
            FrontCamera.Text = selectedPhone.FrontCamera.ToString() + " Мп";
            Description.Text = selectedPhone.Description.ToString();
            Seller.Text = SellerUser.Name;
            Email.Text = SellerUser.Email;
            Phone.Text = SellerUser.Phone;
            Location.Text = SellerUser.Location;
        }
    }
}
