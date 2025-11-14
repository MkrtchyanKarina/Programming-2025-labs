using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal class OfflineCourse : Course
    {
        protected string _address;
        internal OfflineCourse(string name, string author, int teacher_id, string address) : base(name, author, teacher_id) 
        { 
            Address = address;
        }

        internal string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Поле \"адрес\" не может быть пустым!");
                    if (string.IsNullOrWhiteSpace(_address))
                        _address = "Undefinded";
                }
                else
                    _address = value;
            }
        }
    }
}
