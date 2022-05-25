
using System.Collections;
using System.Collections.Generic;


namespace Interview
{
    public class UserModel:IEnumerable
    {
        List<string> _list;
        public UserModel()
        {
            _list = new List<string>() { ID, Name, Surname, Phone };
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
