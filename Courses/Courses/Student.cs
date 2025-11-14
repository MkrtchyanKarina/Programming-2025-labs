using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal class Student : User
    {
        protected List<int> _attended_courses_id;
        internal Student(string name, string lastname, string phone, string email, List<int> attended_courses_id) : base(name, lastname, phone, email)
        {
            _attended_courses_id = attended_courses_id;
        }

        internal void AddNewCourse(int new_course_id) {
            _attended_courses_id.Add(new_course_id);
        }

        internal void GetAllCourses()
        {
            for (int i = 0; i < _attended_courses_id.Count; i++)
            {
                Console.WriteLine(_attended_courses_id[i]);
            }
        }
    }
}
