using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class RegistrationVM : ObservableObject, IDataErrorInfo
    {
        public string Error { get { return null; } }
        private string _username;
        private string _phone;
        private string _surname;

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "Username":
                        if (string.IsNullOrWhiteSpace(Username))
                            result = "Field  cannot be empty";
                        else if (Username.Length < 2)
                            result = "Field  must be a minimum of 2 characters.";
                        else if (Username.Length>50)
                        {
                            result = "Field  must be a maximum of 50 characters.";
                        }
                        break;
                    case "Surname":
                        if (string.IsNullOrWhiteSpace(Username))
                            result = "Field  cannot be empty";
                        else if (Username.Length < 2)
                            result = "Field  must be a minimum of 2 characters.";
                        else if (Username.Length > 50)
                        {
                            result = "Field  must be a maximum of 50 characters.";
                        }
                        break;
                    case "Phone":
                        if (string.IsNullOrWhiteSpace(Phone))
                            result = "Use this format +7-(xxx)-xxx-xx-xx";
                        else if (Username.Length < 18 )
                            result = "Fill all data";

                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                OnPropertyChanged(ref _surname, value);
            }
        }
        public string Phone
        {
            get { return _phone; }
            set { OnPropertyChanged(ref _phone, value); }
        }
    }
}
