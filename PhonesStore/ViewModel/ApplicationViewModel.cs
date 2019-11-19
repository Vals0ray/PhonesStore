using SQLiteApp.Model;
using SQLiteApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace SQLiteApp.ViewModel
{
    public class ApplicationViewModel : BaseVM
    {
        ApplicationContext db;
        User connectUser;
        Phone selectedPhone;
        List<Phone> copyPhones;
        List<Phone> RemoveSlider;
        public bool tmp = true;

        private ObservableCollection<PhoneModel> phoneModels;
        public ObservableCollection<PhoneModel> PhoneModels
        {
            get { return phoneModels; }
            set
            {
                phoneModels = value;
                OnPropertyChanged("PhoneModels");
            }
        }

        private ObservableCollection<Phone> phones;
        public ObservableCollection<Phone> Phones
        {
            get { return phones; }
            set
            {
                phones = value;
                OnPropertyChanged("Phones");
            }
        }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        public List<Phone> CopyPhones
        {
            get { return copyPhones; }
            set
            {
                copyPhones = value;
                OnPropertyChanged("Phones");
            }
        }

        public User ConnectUser
        {
            get { return connectUser; }
            set
            {
                connectUser = value;
                OnPropertyChanged("ConnectUser");
            }
        }

        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel(User connectedUser)
        {
            ConnectUser = connectedUser;
            db = new ApplicationContext();

            db.Phones.Load();
            Phones = db.Phones.Local;

            db.Users.Load();
            Users = db.Users.Local;

            db.PhoneModels.Load();
            PhoneModels = db.PhoneModels.Local;
        }

        public void OpenAddWindow()
        {
            AddWindow addWindow = new AddWindow();

            if (addWindow.ShowDialog() == false)
            {
                if (addWindow.addNewPhone == null)
                {
                    return;
                }
                else
                {
                    addWindow.addNewPhone.Seller = connectUser.Id;
                    db.Phones.Local.Add(addWindow.addNewPhone);
                    db.SaveChanges();
                }
            }
        }

        public RelayCommand LeaveButtonClick
        {
            get
            {
                return new RelayCommand((value) =>
                {
                    WindowsChange.OpenLoginWindow();
                });
            }
        }

        public RelayCommand AddButtomClick
        {
            get
            {
                return new RelayCommand((value) =>
                {
                    OpenAddWindow();
                });
            }
        }

        public RelayCommand ItemClick
        {
            get
            {
                return new RelayCommand((value) =>
                {
                    selectedPhone = value as Phone;

                    if (selectedPhone != null)
                    {
                        var seller = Users.First(user => user.Id == selectedPhone.Seller);
                        DetailsWindow detailsWindow = new DetailsWindow(selectedPhone, seller);
                        detailsWindow.DataContext = new ViewModel.DetailsWindowViewModel(selectedPhone, seller);
                        detailsWindow.ShowDialog();
                    }
                });
            }
        }

        public RelayCommand Command
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    CheckBox checkBox = obj as CheckBox;

                    if ((bool)checkBox.IsChecked && CopyPhones == null)
                    {
                        CopyPhones = Phones.Where(p => p.Company != checkBox.Content.ToString()).ToList();
                        foreach (var p in CopyPhones)
                        {
                            Phones.Remove(p);
                        }
                    }
                    else if ((bool)checkBox.IsChecked && CopyPhones != null)
                    {
                        foreach (var p in CopyPhones)
                        {
                            if (p.Company == checkBox.Content.ToString())
                            {
                                Phones.Add(p);
                            }
                        }
                        CopyPhones.RemoveAll(p => p.Company == checkBox.Content.ToString());
                    }
                    else
                    {
                        CopyPhones.AddRange(Phones.Where(p => p.Company == checkBox.Content.ToString()));
                        foreach (var p in CopyPhones)
                        {
                            if (p.Company == checkBox.Content.ToString())
                            {
                                Phones.Remove(p);
                            }
                        }

                        if (Phones.Count == 0)
                        {
                            foreach (var p in CopyPhones)
                            {
                                Phones.Add(p);
                            }

                            CopyPhones = null;
                        }
                    }
                });
            }
        }

        public RelayCommand CommandSortSlider
        {
            get
            {
                return new RelayCommand((value) =>
                {
                    UIElementCollection prices = value as UIElementCollection;

                    RemoveSlider = new List<Phone>();
                    foreach (Phone p in phones)
                    {
                        if (Convert.ToInt32(prices[0].ToString().Remove(0, 33)) > p.Price)
                        {
                            RemoveSlider.Add(p);
                        }
                        else if (Convert.ToInt32(prices[2].ToString().Remove(0, 33)) < p.Price)
                        {
                            RemoveSlider.Add(p);
                        }
                    }

                    foreach (Phone p in RemoveSlider)
                    {
                        db.Phones.Local.Remove(p);
                    }
                });
            }
        }

        public RelayCommand CommandSearchButtom
        {
            get
            {
                return new RelayCommand((value) =>
                {
                });
            }
        }
    }
}