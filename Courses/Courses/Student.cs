using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal class Student : User
    {
        protected List<int> _attended_courses_id = new List<int> ();
        internal Student(string name, string lastname, string phone, string email) : base(name, lastname, phone, email) {  }

        internal void AddNewCourse(int new_course_id) 
        {
            _attended_courses_id.Add(new_course_id);
        }

        internal List<int> GetAllStudentCourses()
        {
            return _attended_courses_id;
        }
    }
}
