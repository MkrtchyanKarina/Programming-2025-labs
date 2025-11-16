using Courses;
using System.Collections;

using System;
using Courses;

namespace CoursesCLI
{
    public class Program
    {
        private static Admin admin = new Admin();

        public static void Main(string[] args)
        {
            Console.WriteLine("=== Система управления курсами ===");
            ShowMenu();

            while (true)
            {
                Console.Write("\nВведите команду: ");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrEmpty(input))
                    continue;

                ProcessCommand(input);
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\nДоступные команды:");
            Console.WriteLine("1. add online <название> <автор> <ссылка> - Добавить онлайн курс");
            Console.WriteLine("2. add offline <название> <автор> <адрес> - Добавить оффлайн курс");
            Console.WriteLine("3. add student <имя> <фамилия> <телефон> <email> - Добавить студента");
            Console.WriteLine("4. add teacher <имя> <фамилия> <телефон> <email> - Добавить преподавателя");
            Console.WriteLine("5. enroll <id_курса> <id_студента> - Записать студента на курс");
            Console.WriteLine("6. assign <id_курса> <id_преподавателя> - Назначить преподавателя на курс");
            Console.WriteLine("7. courses all - Показать все курсы");
            Console.WriteLine("8. courses teacher <id_преподавателя> - Курсы преподавателя");
            Console.WriteLine("9. courses student <id_студента> - Курсы студента");
            Console.WriteLine("10. students all - Все студенты");
            Console.WriteLine("11. students course <id_курса> - Студенты курса");
            Console.WriteLine("12. teachers all - Все преподаватели");
            Console.WriteLine("13. delete course <id_курса> - Удалить курс");
            Console.WriteLine("14. menu - Показать меню");
            Console.WriteLine("15. exit - Выход");
        }

        private static void ProcessCommand(string command)
        {
            string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string action = parts[0].ToLower();

            try
            {
                switch (action)
                {
                    case "add":
                        ProcessAddCommand(parts);
                        break;
                    case "enroll":
                        ProcessEnrollCommand(parts);
                        break;
                    case "assign":
                        ProcessAssignCommand(parts);
                        break;
                    case "courses":
                        ProcessCoursesCommand(parts);
                        break;
                    case "students":
                        ProcessStudentsCommand(parts);
                        break;
                    case "teachers":
                        ProcessTeachersCommand(parts);
                        break;
                    case "delete":
                        ProcessDeleteCommand(parts);
                        break;
                    case "menu":
                        ShowMenu();
                        break;
                    case "exit":
                        Console.WriteLine("Выход из программы...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда. Введите 'menu' для просмотра доступных команд.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void ProcessAddCommand(string[] parts)
        {
            if (parts.Length < 2)
            {
                Console.WriteLine("Недостаточно параметров для команды add");
                return;
            }

            string type = parts[1].ToLower();

            switch (type)
            {
                case "online":
                    if (parts.Length >= 5)
                    {
                        string name = parts[2];
                        string author = parts[3];
                        string link = parts[4];
                        admin.AddOnlineCourse(name, author, link);
                        Console.WriteLine("Онлайн курс успешно добавлен!");
                    }
                    else
                    {
                        Console.WriteLine("Использование: add online <название> <автор> <ссылка>");
                    }
                    break;

                case "offline":
                    if (parts.Length >= 5)
                    {
                        string name = parts[2];
                        string author = parts[3];
                        string address = parts[4];
                        admin.AddOfflineCourse(name, author, address);
                        Console.WriteLine("Оффлайн курс успешно добавлен!");
                    }
                    else
                    {
                        Console.WriteLine("Использование: add offline <название> <автор> <адрес>");
                    }
                    break;

                case "student":
                    if (parts.Length >= 6)
                    {
                        string name = parts[2];
                        string lastname = parts[3];
                        string phone = parts[4];
                        string email = parts[5];
                        admin.AddStudent(name, lastname, phone, email);
                        Console.WriteLine("Студент успешно добавлен!");
                    }
                    else
                    {
                        Console.WriteLine("Использование: add student <имя> <фамилия> <телефон> <email>");
                    }
                    break;

                case "teacher":
                    if (parts.Length >= 6)
                    {
                        string name = parts[2];
                        string lastname = parts[3];
                        string phone = parts[4];
                        string email = parts[5];
                        admin.AddTeacher(name, lastname, phone, email);
                        Console.WriteLine("Преподаватель успешно добавлен!");
                    }
                    else
                    {
                        Console.WriteLine("Использование: add teacher <имя> <фамилия> <телефон> <email>");
                    }
                    break;

                default:
                    Console.WriteLine("Неизвестный тип для добавления. Используйте: online, offline, student, teacher");
                    break;
            }
        }

        private static void ProcessEnrollCommand(string[] parts)
        {
            if (parts.Length >= 3 && int.TryParse(parts[1], out int courseId) && int.TryParse(parts[2], out int studentId))
            {
                admin.AddStudentOnCourse(courseId, studentId);
            }
            else
            {
                Console.WriteLine("Использование: enroll <id_курса> <id_студента>");
            }
        }

        private static void ProcessAssignCommand(string[] parts)
        {
            if (parts.Length >= 3 && int.TryParse(parts[1], out int courseId) && int.TryParse(parts[2], out int teacherId))
            {
                admin.SetTeacherOnCourse(courseId, teacherId);
                Console.WriteLine("Преподаватель успешно назначен на курс!");
            }
            else
            {
                Console.WriteLine("Использование: assign <id_курса> <id_преподавателя>");
            }
        }

        private static void ProcessCoursesCommand(string[] parts)
        {
            if (parts.Length < 2)
            {
                Console.WriteLine("Недостаточно параметров для команды courses");
                return;
            }

            string subcommand = parts[1].ToLower();

            switch (subcommand)
            {
                case "all":
                    admin.GetAllCourses();
                    break;
                case "teacher":
                    if (parts.Length >= 3 && int.TryParse(parts[2], out int teacherId))
                    {
                        admin.GetAllTeachersCourses(teacherId);
                    }
                    else
                    {
                        Console.WriteLine("Использование: courses teacher <id_преподавателя>");
                    }
                    break;
                case "student":
                    if (parts.Length >= 3 && int.TryParse(parts[2], out int studentId))
                    {
                        admin.GetAllStudentCourses(studentId);
                    }
                    else
                    {
                        Console.WriteLine("Использование: courses student <id_студента>");
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестная подкоманда для courses. Используйте: all, teacher, student");
                    break;
            }
        }

        private static void ProcessStudentsCommand(string[] parts)
        {
            if (parts.Length < 2)
            {
                Console.WriteLine("Недостаточно параметров для команды students");
                return;
            }

            string subcommand = parts[1].ToLower();

            switch (subcommand)
            {
                case "all":
                    admin.GetAllStudents();
                    break;
                case "course":
                    if (parts.Length >= 3 && int.TryParse(parts[2], out int courseId))
                    {
                        admin.GetAllStudentsOnCourse(courseId);
                    }
                    else
                    {
                        Console.WriteLine("Использование: students course <id_курса>");
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестная подкоманда для students. Используйте: all, course");
                    break;
            }
        }

        private static void ProcessTeachersCommand(string[] parts)
        {
            if (parts.Length >= 2 && parts[1].ToLower() == "all")
            {
                admin.GetAllTeachers();
            }
            else
            {
                Console.WriteLine("Использование: teachers all");
            }
        }

        private static void ProcessDeleteCommand(string[] parts)
        {
            if (parts.Length >= 3 && parts[1].ToLower() == "course" && int.TryParse(parts[2], out int courseId))
            {
                admin.DeleteCourse(courseId);
                Console.WriteLine("Курс успешно удален!");
            }
            else
            {
                Console.WriteLine("Использование: delete course <id_курса>");
            }
        }
    }
}