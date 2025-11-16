using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    public class Admin
    {
        private int students_last_id = 1;
        private int teachers_last_id = 1;
        private int courses_last_id = 1;

        private Dictionary<int, Student> _students = new Dictionary<int, Student>();
        private Dictionary<int, Teacher> _teachers = new Dictionary<int, Teacher>();
        private Dictionary<int, Course> _courses = new Dictionary<int, Course>();

        public Admin() { }

        public void AddOnlineCourse(string name, string author, string link)
        {
            _courses[courses_last_id] = new OnlineCourse(name, author, link);
            courses_last_id++;
        }

        public void AddOfflineCourse(string name, string author, string address)
        {
            _courses[courses_last_id] = new OfflineCourse(name, author, address);
            courses_last_id++;
        }

        public void AddStudent(string name, string lastname, string phone, string email)
        {
            _students[students_last_id] = new Student(name, lastname, phone, email);
            students_last_id++;
        }


        public void AddTeacher(string name, string lastname, string phone, string email)
        {
            _teachers[teachers_last_id] = new Teacher(name, lastname, phone, email);
            teachers_last_id++;
        }


        public void DeleteCourse(int course_id) 
        {
            _courses.Remove(course_id);
        }


        public void AddStudentOnCourse(int course_id, int student_id) 
        {
            Student student = _students[student_id];
            student.AddNewCourse(course_id);

            Course course = _courses[course_id];
            course.EnrollStudentOnCourse(student_id);

            Console.WriteLine($"Студент {student.Name} записан на курс {course.Name}");
        }


        public void SetTeacherOnCourse(int course_id, int teacher_id) 
        {
            _teachers[teacher_id].AddNewCourse(course_id);
            _courses[course_id].Teacher = teacher_id;
        }


        public void GetAllTeachersCourses(int teacher_id) 
        {
            Teacher teacher = _teachers[teacher_id];
            Console.WriteLine($"Список курсов преподавателя {teacher.Name}");
            foreach (int course_id in _teachers[teacher_id].GetAllTeacherCourses())
            {
                Course course = _courses[course_id];
                Console.WriteLine($"Ключ: {course_id}, Название: {course.Name}, Автор: {course.Author}");
            }
        }


        public void GetAllStudentCourses(int student_id) 
        {
            Student student = _students[student_id];
            Console.WriteLine($"Список курсов студента {student.Name}");
            foreach (int course_id in student.GetAllStudentCourses())
            { 
                Course course = _courses[course_id];
                string teachers_name = "";
                if (_teachers.ContainsKey(course.Teacher))
                    teachers_name = _teachers[course.Teacher].Name;
                else
                    teachers_name = "Undefinded";
                Console.WriteLine($"Ключ: {course_id}, Название: {course.Name}, Автор: {course.Author}, Преподаватель: {teachers_name}");
            }
        }


        public void GetAllStudentsOnCourse(int course_id) 
        {
            Course course = _courses[course_id];
            Console.WriteLine($"Список студентов на курсе {course.Name}");
            foreach (int student_id in course.GetStudentsList())
            {
                Student student = _students[student_id];
                Console.WriteLine($"ID: {student_id}, Имя: {student.Name}, Фамилия: {student.Lastname}, Почта: {student.Email}, Телефон: {student.Phone}");
            }
        }


        public void GetAllCourses() 
        {
            Console.WriteLine("Все курсы в системе");
            foreach (KeyValuePair<int, Course> entry in _courses)
            {
                Course course = entry.Value;
                string teachers_name = "";
                if (_teachers.ContainsKey(course.Teacher))
                    teachers_name = _teachers[course.Teacher].Name;
                else
                    teachers_name = "Undefinded";

                Console.WriteLine($"Ключ: {entry.Key}, Название: {course.Name}, Автор: {course.Author}, Преподаватель: {teachers_name}");
            }
        }

        public void GetAllStudents()
        {
            Console.WriteLine("Все студенты в системе");
            foreach (KeyValuePair<int, Student> entry in _students)
            {
                Student student = entry.Value;
                Console.WriteLine($"ID: {entry.Key}, Имя: {student.Name}, Фамилия: {student.Lastname}, Почта: {student.Email}, Телефон: {student.Phone}");
            }
        }

        public void GetAllTeachers()
        {
            Console.WriteLine("Все преподаватели в системе");
            foreach (KeyValuePair<int, Teacher> entry in _teachers)
            {
                Teacher teacher = entry.Value;
                Console.WriteLine($"ID: {entry.Key}, Имя: {teacher.Name}, Фамилия: {teacher.Lastname}, Почта: {teacher.Email}, Телефон: {teacher.Phone}");
            }
        }
    }
}
