
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interview
{
    class RegistrationVM : ObservableObject, IDataErrorInfo
    {
        public string Error { get { return null; } }
        private string _username;
        private string _phone;
        private string _surname;
        private string _id;
        private static readonly Regex _regex = new Regex("[^0-9.+]+");

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
                            result = "Field  cannot be empty";

                        else if (_regex.IsMatch(Phone))
                        {
                            result = "You should use numeric numbers";
                        }
                        else if (Phone.Length!=12)
                        {
                            result = "It should conatain 11 numbers";
                        }
                            
                        break;
                    case "ID":
                        if(string.IsNullOrWhiteSpace(ID))
                            result = "Field  cannot be empty";
                        else if (_regex.IsMatch(ID))
                        {
                            result = "It allows only numeric";
                        }
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
        public string ID
        {
            get { return _id ; }
            set
            {
                OnPropertyChanged(ref _id, value);
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
