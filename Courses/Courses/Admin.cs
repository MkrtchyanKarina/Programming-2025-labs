using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal class Admin
    {
        private int students_last_id = 1;
        private int teachers_last_id = 1;
        private int courses_last_id = 1;

        private Dictionary<int, Student> _students = new Dictionary<int, Student>();
        private Dictionary<int, Teacher> _teachers = new Dictionary<int, Teacher>();
        private Dictionary<int, Course> _courses = new Dictionary<int, Course>();

        public Admin() { }
        //public Admin(Dictionary<int, Student> students, Dictionary<int, Teacher> teachers, Dictionary<int, Course> courses) 
        //{
        //    _students = students;
        //    _teachers = teachers;
        //    _courses = courses;
        //}


        public void AddCourse(Course new_course) 
        {
            _courses[courses_last_id] = new_course;
            courses_last_id++;
        }

        public void AddStudent(Student new_student)
        {
            _students[students_last_id] = new_student;
            students_last_id++;
        }

        public void AddTeacher(Teacher new_teacher)
        {
            _teachers[teachers_last_id] = new_teacher;
            teachers_last_id++;
        }


        public void DeleteCourse(int course_id) 
        {
            _courses.Remove(course_id);
        }


        public void AddStudentOnCourse(int course_id, int student_id) 
        {
            _students[student_id].AddNewCourse(course_id);
            _courses[course_id].EnrollStudentOnCourse(student_id);
        }


        public void SetTeacherOnCourse(int course_id, int teacher_id) 
        {
            _teachers[teacher_id].AddNewCourse(course_id);
            _courses[course_id].Teacher = teacher_id;
        }


        public void GetAllTeachersCourses(int teacher_id) 
        {
            _teachers[teacher_id].GetAllCourses();
        }


        public void GetAllStudentCourses(int student_id) 
        {
            _students[student_id].GetAllCourses();
        }


        public void GetAllStudentsOnCourse(int course_id) 
        {
            _courses[course_id].GetStudentsList();
        }


        public void GetAllCourses() 
        {
            foreach (KeyValuePair<int, Course> entry in _courses)
            {
                Course course = entry.Value;
                Console.WriteLine($"Ключ: {entry.Key}, Название: {course.Name} , Автор: {course.Author}, Преподаватель: {_teachers[course.Teacher].Name}");
            }
        }
    }
}
