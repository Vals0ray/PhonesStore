using System.ComponentModel;
using System.Runtime.CompilerServices;
 
namespace SQLiteApp
{
    public class Phone : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string model;
        private string company;
        private int price;
        private string image;
        private double screen;
        private int battery;
        private int operativeMemory;
        private int builtInMemory;
        private int mainCamera;
        private int frontCamera;
        private string description;
        private int seller;

        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }
        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public double Screen
        {
            get { return screen; }
            set
            {
                screen = value;
                OnPropertyChanged("Screen");
            }
        }

        public int Battery
        {
            get { return battery; }
            set
            {
                battery = value;
                OnPropertyChanged("Battery");
            }
        }

        public int OperativeMemory
        {
            get { return operativeMemory; }
            set
            {
                operativeMemory = value;
                OnPropertyChanged("OperativeMemory");
            }
        }

        public int BuiltInMemory
        {
            get { return builtInMemory; }
            set
            {
                builtInMemory = value;
                OnPropertyChanged("BuiltInMemory");
            }
        }

        public int MainCamera
        {
            get { return mainCamera; }
            set
            {
                mainCamera = value;
                OnPropertyChanged("MainCamera");
            }
        }

        public int FrontCamera
        {
            get { return frontCamera; }
            set
            {
                frontCamera = value;
                OnPropertyChanged("FrontCamera");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public int Seller
        {
            get { return seller; }
            set
            {
                seller = value;
                OnPropertyChanged("Seller");
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