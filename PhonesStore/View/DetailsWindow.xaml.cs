using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SQLiteApp
{
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(Phone selectedPhone, User SellerUser)
        {
            InitializeComponent();

            Seller.Text = SellerUser.Name;
            Email.Text = SellerUser.Email;
            Phone.Text = SellerUser.Phone;
            Location.Text = SellerUser.Location;
        }
    }
}