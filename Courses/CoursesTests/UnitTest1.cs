using Courses;
using Xunit;
namespace CoursesTests
{
    public class UnitTest1
    {
        [Fact]
        public void GetAllCourses()
        {
            // Arange            
            var stringWriter = new StringWriter();
            var originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            // Act
            Admin admin = new Admin();
            admin.AddOnlineCourse("Java for begginers", "Karina", "https://course/1/java_for_begginers");
            admin.GetAllCourses();
            var result = stringWriter.ToString();

            // Assert
            Assert.Contains("Все курсы в системе\r\nКлюч: 1, Название: Java for begginers, Автор: Karina, Преподаватель: Undefinded", result);
        }

        [Fact]
        public void GetAllTeachers()
        {
            // Arange            
            var stringWriter = new StringWriter();
            var originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            // Act
            Admin admin = new Admin();
            admin.AddTeacher("Ivan", "Ivanov", "7-913-514-09-98", "ivanov@mail.ru");
            admin.GetAllTeachers();
            var result = stringWriter.ToString();

            // Assert
            Assert.Contains("Все преподаватели в системе\r\nID: 1, Имя: Ivan, Фамилия: Ivanov, Почта: ivanov@mail.ru, Телефон: 7-913-514-09-98", result);
        }

        [Fact]
        public void GetAllStudents()
        {
            // Arange            
            var stringWriter = new StringWriter();
            var originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            // Act
            Admin admin = new Admin();
            admin.AddStudent("Ayana", "Danilova", "7-987-98-65-21", "a_danilova.gmail.com");
            admin.GetAllStudents();
            var result = stringWriter.ToString();

            // Assert
            Assert.Contains("Все студенты в системе\r\nID: 1, Имя: Ayana, Фамилия: Danilova, Почта: a_danilova.gmail.com, Телефон: 7-987-98-65-21", result);
        }


        [Fact]
        public void DeleteCourse()
        {
            // Arange            
            var stringWriter = new StringWriter();
            var originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            // Act
            Admin admin = new Admin();
            admin.AddOnlineCourse("Java for begginers", "Karina", "https://course/1/java_for_begginers");
            admin.AddOfflineCourse("C# for begginers", "Sergey", "Saint Petersburg, Lomonosova st., 9");
            admin.DeleteCourse(1);
            admin.GetAllCourses();
            var result = stringWriter.ToString();

            // Assert
            Assert.Contains("Все курсы в системе\r\nКлюч: 2, Название: C# for begginers, Автор: Sergey, Преподаватель: Undefinded", result);
        }

        [Fact]
        public void EnrollStudentsOnCourseAndGetAllStudentsOnCourse()
        {
            // Arange            
            var stringWriter = new StringWriter();
            var originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            // Act
            Admin admin = new Admin();
            admin.AddStudent("Ayana", "Danilova", "7-987-98-65-21", "a_danilova.gmail.com");
            admin.AddStudent("Karina", "Mkrtchyan", "7-989-08-63-11", "karina_m.gmail.com");
            admin.AddOnlineCourse("Java for begginers", "Karina", "https://course/1/java_for_begginers");
            admin.AddOfflineCourse("C# for begginers", "Sergey", "Saint Petersburg, Lomonosova st., 9");
            admin.AddStudentOnCourse(course_id: 2, student_id: 1);
            admin.AddStudentOnCourse(course_id: 1, student_id: 2);
            admin.GetAllStudentsOnCourse(1);
            admin.GetAllStudentsOnCourse(2);
            var result = stringWriter.ToString();

            // Assert
            Assert.Contains("Студент Ayana записан на курс C# for begginers\r\n" +
                "Студент Karina записан на курс Java for begginers\r\n" +
                "Список студентов на курсе Java for begginers\r\n" +
                "ID: 2, Имя: Karina, Фамилия: Mkrtchyan, Почта: karina_m.gmail.com, Телефон: 7-989-08-63-11\r\n" +
                "Список студентов на курсе C# for begginers\r\n" +
                "ID: 1, Имя: Ayana, Фамилия: Danilova, Почта: a_danilova.gmail.com, Телефон: 7-987-98-65-21", result);
        }


        [Fact]
        public void SetTeacherAndGetHisCourses()
        {
            // Arange            
            var stringWriter = new StringWriter();
            var originalOutput = Console.Out;
            Console.SetOut(stringWriter);

            // Act
            Admin admin = new Admin();
            admin.AddOfflineCourse("C# for begginers", "Sergey", "Saint Petersburg, Lomonosova st., 9");
            admin.AddOnlineCourse("Java for begginers", "Karina", "https://course/1/java_for_begginers");
            admin.AddTeacher("Ivan", "Ivanov", "7-913-514-09-98", "ivanov@mail.ru");
            admin.SetTeacherOnCourse(course_id: 1, teacher_id: 1);
            admin.SetTeacherOnCourse(course_id: 2, teacher_id: 1);
            admin.GetAllTeachersCourses(1);
            var result = stringWriter.ToString();

            // Assert
            Assert.Contains("Список курсов преподавателя Ivan\r\n" +
                "Ключ: 1, Название: C# for begginers, Автор: Sergey\r\n" +
                "Ключ: 2, Название: Java for begginers, Автор: Karina", result);
        }
    }
}