namespace SQLiteApp.ViewModel
{
    public class DetailsWindowViewModel : Model.BaseVM
    {
        public User SelectedUser { get; set; }

        public Phone SelectedPhone { get; set; }

        public DetailsWindowViewModel(Phone selectedPhone, User SellerUser)
        {
            SelectedUser = SellerUser;
            SelectedPhone = selectedPhone;
        }
    }
}
