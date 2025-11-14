using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal abstract class Course
    {
        protected List<int> _students_id = new List<int> { };
        protected string _name;
        protected string _author;
        protected int _teacher_id;

        protected Course(string name, string author, int teacher_id) {
            Name = name;
            Author = author;
            Teacher = teacher_id;
        }

        internal string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Поле \"название\" не может быть пустым!");
                    if (string.IsNullOrWhiteSpace(_name))
                        _name = "Undefinded";
                }
                else
                    _name = value;
            }
        }

        internal int Teacher { 
            get { return _teacher_id;  }
            set 
            {
                if (value > 0)
                {
                    _teacher_id = value;
                                   
                }
                else
                    Console.WriteLine("ID не может быть отрицательным");
            }
        }

        internal string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Поле \"автор\" не может быть пустым!");
                    if (string.IsNullOrWhiteSpace(_author))
                        _author = "Undefinded";

                }
                else
                    _author = value;
                
            }
        }

        internal void EnrollStudentOnCourse(int student_id) { 
            _students_id.Add(student_id);
            Console.WriteLine("The student was successfully enrolled");
        }

        internal void GetStudentsList() {
            for (int i = 0; i < _students_id.Count; i++) {
                Console.WriteLine(_students_id[i]);
            }
        }

        
    }
}
