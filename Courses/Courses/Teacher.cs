using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal class Teacher : User
    {
        protected List<int> _taught_courses_id = new List<int> ();
        internal Teacher(string name, string lastname, string phone, string email) : base(name, lastname, phone, email)  {  }

        internal void AddNewCourse(int new_course_id)
        {
            _taught_courses_id.Add(new_course_id);
        }

        internal List<int> GetAllTeacherCourses()
        {
            return _taught_courses_id;
        }
    }
}
