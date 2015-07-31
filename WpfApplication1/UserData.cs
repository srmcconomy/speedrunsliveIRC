using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class UserData : ModelBase
    {
        string username;
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    NotifyPropertyChanged("Username");
                }
            }
        }

        string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    NotifyPropertyChanged("Password");
                }
            }
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var store = IsolatedStorageFile.GetMachineStoreForAssembly())
            {
                using (var stream = store.OpenFile("settings.bin", System.IO.FileMode.OpenOrCreate))
                {
                    formatter.Serialize(stream, this);
                }
            }
        }

        static UserData instance = new UserData();
        public static UserData Instance { get { return instance; } }
    }
}
