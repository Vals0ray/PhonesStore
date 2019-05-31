using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace SQLiteApp
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        static Dictionary<string, bool> isCheck = new Dictionary<string, bool>
        {
            {"Apple",   false },
            {"Asus",   false },
            {"Blackview", false },
            {"Doogee",   false },
            {"Elephone", false },
            {"HTC",   false },
            {"Honor", false },
            {"Huawei",   false },
            {"LG", false },
            {"Leagoo",   false },
            {"Lenovo", false },
            {"Meizu",   false },
            {"Motorola", false },
            {"Nokia",   false },
            {"OnePlus", false },
            {"Philips",   false },
            {"Prestigio", false },
            {"Samsung",   false },
            {"Sony", false },
            {"TP-Link", false },
            {"Xiaomi", false },
            {"ZTE", false }
        };

        ApplicationContext db;
        ObservableCollection<Phone> phones;
        ObservableCollection<User> users;
        User connectUser;
        Phone selectedPhone;
        ObservableCollection<Phone> copyPhones;
        ObservableCollection<Phone>[] NamesToRemove = new ObservableCollection<Phone>[isCheck.Count];
        ObservableCollection<Phone>[] NamesToRemove2 = new ObservableCollection<Phone>[isCheck.Count];
        ObservableCollection<Phone> RemoveSearch = new ObservableCollection<Phone>(); 
        List<Phone> RemoveSlider;
        List<Phone> RemoveSerch = new List<Phone>();
        RelayCommand checkBoxSortCommand, sliderSortCommand, commandSearchButtom;
        public bool close;
        public bool tmp = true;

        public ObservableCollection<Phone> Phones
        {
            get { return phones; }
            set
            {
                phones = value;
                OnPropertyChanged("Phones");
            }
        }

        public ObservableCollection<Phone> CopyPhones
        {
            get { return copyPhones; }
            set
            {
                copyPhones = value;
                OnPropertyChanged("Phones");
            }
        }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        public User ConnectUser
        {
            get { return connectUser; }
            set {
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
                OnPropertyChanged("ConnectUser");
            }
        }

        public ApplicationViewModel()
        {
            db = new ApplicationContext();

            db.Phones.Load();
            db.Phones.Local.ToBindingList();
            Phones = db.Phones.Local;

            db.Users.Load();
            db.Users.Local.ToBindingList();
            Users = db.Users.Local;

            for (int i = 0; i < isCheck.Count; i++)
            {
                NamesToRemove[i] = new ObservableCollection<Phone>();
                NamesToRemove2[i] = new ObservableCollection<Phone>();
            }

            OpenLoginWindow();
        }

        public void OpenLoginWindow()
        {
            LoginWindow loginWindow = new LoginWindow(users);
            close = false;
            if (loginWindow.ShowDialog() == false)
            {
                if (loginWindow.openRegistrationWindow)
                {
                    OpenRegistrationWindow();
                    return;
                }

                if (loginWindow.connectUser == null)
                {
                    close = true;
                }
                else
                {
                    ConnectUser = loginWindow.connectUser;
                }
            }
        }

        public void OpenRegistrationWindow()
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            if(registrationWindow.ShowDialog() == false)
            {
                if (registrationWindow.openLoginWindow)
                {
                    OpenLoginWindow();
                    return;
                }

                if(registrationWindow.regUser == null)
                {
                    close = true;
                }
                else
                {    
                    ConnectUser = registrationWindow.regUser;
                    db.Users.Add(registrationWindow.regUser);
                    db.SaveChanges();
                }
            }
        }

        public void OpenDetailsWindow(object sender)
        {
            selectedPhone = sender as Phone;
            User SellerUser = new User();
            foreach (var u in Users)
            {
                if(u.Id == selectedPhone.Seller)
                {
                    SellerUser = u;
                }
            }

            DetailsWindow detailsWindow = new DetailsWindow(selectedPhone, SellerUser);
            if(detailsWindow.ShowDialog() == false)
            {

            }

        }

        public void OpenAddWindow()
        {
            AddWindow addWindow = new AddWindow();
            if(addWindow.ShowDialog() == false)
            {
                if(addWindow.addNewPhone == null)
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

        public RelayCommand Command
        {
            get
            {
                return checkBoxSortCommand ?? (checkBoxSortCommand = new RelayCommand((obj) =>
                {
                    AnyDo();

                    int index = 0;
                    switch (obj.ToString())
                    {
                        case "Apple": index = 0; break;
                        case "Asus": index = 1; break;
                        case "Blackview": index = 2; break;
                        case "Doogee": index = 3; break;
                        case "Elephone": index = 4; break;
                        case "HTC": index = 5; break;
                        case "Honor": index = 6; break;
                        case "Huawei": index = 7; break;
                        case "LG": index = 8; break;
                        case "Leagoo": index = 9; break;
                        case "Lenovo": index = 10; break;
                        case "Meizu": index = 11; break;
                        case "Motorola": index = 12; break;
                        case "Nokia": index = 13; break;
                        case "OnePlus": index = 14; break;
                        case "Philips": index = 15; break;
                        case "Prestigio": index = 16; break;
                        case "Samsung": index = 17; break;
                        case "Sony": index = 18; break;
                        case "TP-Link": index = 19; break;
                        case "Xiaomi": index = 20; break;
                        case "ZTE": index = 21; break;
                    }

                    for (int i = 0; i < isCheck.Count; i++)
                    {
                        foreach (var n in NamesToRemove[i])
                        {
                            if (n != null)
                            {
                                Phones.Add(n);
                            }
                        }

                        foreach (var n in NamesToRemove2[i])
                        {
                            if (n != null)
                            {
                                Phones.Add(n);
                            }
                        }
                    }


                    if (!isCheck[obj.ToString()])
                    {
                        foreach (var p in Phones)
                        {
                            if (p.Company != obj.ToString())
                            {
                                if (!isCheck[p.Company])
                                {
                                    NamesToRemove[index].Add(p);
                                }
                            }
                        }

                        foreach(var n in NamesToRemove[index])
                        {
                            Phones.Remove(n);
                        }

                        isCheck[obj.ToString()] = true;
                    }
                    else
                    {
                        isCheck[obj.ToString()] = false;
                        int number = 0;

                        foreach(var v in isCheck.Values)
                        {
                            if (v)
                            {
                                foreach (var p in Phones)
                                {
                                    foreach (var k in isCheck.Keys)
                                    {
                                        if (p.Company == k)
                                        {
                                            if (!isCheck[k])
                                            {
                                                NamesToRemove2[index].Add(p);
                                            }
                                        }
                                    }
                                }

                                foreach (var n in NamesToRemove2[index])
                                {
                                    Phones.Remove(n);
                                }
                            }
                            if (!v)
                            {
                                number++;
                            }
                        }

                        if (number == isCheck.Count)
                        {
                            for (int i = 0; i < isCheck.Count; i++)
                            {
                                foreach (var n in NamesToRemove[i])
                                {
                                    if (n != null)
                                    {
                                        Phones.Add(n);
                                    }
                                }

                                foreach (var n in NamesToRemove2[i])
                                {
                                    if (n != null)
                                    {
                                        Phones.Add(n);
                                    }
                                }
                            }
                        }

                        NamesToRemove2[index].Clear();
                        NamesToRemove[index].Clear();

                    }

                }));
            }
        }

        public RelayCommand CommandSortSlider
        {
            get
            {
                return sliderSortCommand ?? (sliderSortCommand = new RelayCommand((value) =>
                {
                    UIElementCollection prices = (value as UIElementCollection);

                    AnyDo();
                    RemoveSlider = new List<Phone>();
                    foreach (Phone p in phones)
                    {
                        if(Convert.ToInt32(prices[0].ToString().Remove(0, 33)) > p.Price)
                        {
                            RemoveSlider.Add(p);
                        }
                        else if(Convert.ToInt32(prices[2].ToString().Remove(0, 33)) < p.Price)
                        {
                            RemoveSlider.Add(p);
                        }
                    }

                    foreach (Phone p in RemoveSlider)
                    {
                        db.Phones.Local.Remove(p);
                    }
                }));
            }
        }

        public RelayCommand CommandSearchButtom
        {
            get
            {
                return commandSearchButtom ?? (commandSearchButtom = new RelayCommand((value) =>
                {
                    foreach (var n in RemoveSerch)
                    {
                        if(n != null)
                        {
                            Phones.Add(n);
                        }
                    }

                    foreach (var p in Phones)
                    {
                        if(p.Model != value.ToString())
                        {
                            RemoveSerch.Add(p);
                        }
                    }

                    foreach(var n in RemoveSerch)
                    {
                        Phones.Remove(n);
                    }
                }));
            }
        }

        public void AnyDo()
        {
            if (RemoveSlider != null)
            {
                foreach (var n in RemoveSlider)
                {
                    Phones.Add(n);
                }
                RemoveSlider.Clear();
            }

            if (RemoveSerch != null)
            {
                foreach (var n in RemoveSerch)
                {
                    Phones.Add(n);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}