using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class CustomArray:IEnumerable
    {
        List<string> _list;
        public CustomArray()
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
