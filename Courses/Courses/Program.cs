using Courses;
using System.Collections;



OnlineCourse java_course = new ("Java for begginers", "Karina", -1, "https://course/1/java_for_begginers");

//Console.WriteLine(java_course.Name);

java_course.Teacher = 1;
Console.WriteLine(java_course.Teacher);
//java_course.AddStudent("Petya Ivanov");
//java_course.GetStudentsList();
//java_course.Teacher = "";
//Console.WriteLine(java_course.Teacher);
//Console.WriteLine(java_course.Id);

//Student student1 = new("Ivan", "Ivanov", "7-913-514-09-98", "ivanov@mail.ru", courses1);
//student1.AddNewCourse(2);
//student1.GetAllCourses();
List<int> courses1 = new List<int> { 1 };
Teacher teacher1 = new Teacher("Ivan", "Ivanov", "7-913-514-09-98", "ivanov@mail.ru", courses1);
Admin admin = new Admin();
admin.AddCourse(java_course);
admin.AddTeacher(teacher1);
admin.GetAllCourses();