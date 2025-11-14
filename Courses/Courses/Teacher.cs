using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal class Teacher : User
    {
        protected List<int> _taught_courses_id;
        internal Teacher(string name, string lastname, string phone, string email, List<int> taught_courses_id) : base(name, lastname, phone, email)
        {
            _taught_courses_id = taught_courses_id;
        }

        internal void AddNewCourse(int new_course_id)
        {
            _taught_courses_id.Add(new_course_id);
        }

        internal void GetAllCourses()
        {
            for (int i = 0; i < _taught_courses_id.Count; i++)
            {
                Console.WriteLine(_taught_courses_id[i]);
            }
        }
    }
}
