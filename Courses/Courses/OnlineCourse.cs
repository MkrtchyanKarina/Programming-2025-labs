using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal class OnlineCourse : Course
    {
        protected string _link;
        internal OnlineCourse(string name, string author, string link) : base(name, author) { 
            Link = link;
        }

        internal string Link
        {
            get { return _link; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Поле \"ссылка\" не может быть пустым!");
                    if (string.IsNullOrWhiteSpace(_link))
                        _link = "Undefinded";
                }
                else
                    _link = value;
            }
        }
    }
}
