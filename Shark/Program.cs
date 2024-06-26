﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Shark
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Course[] courses = { new Course(1), new Course(2), new Course(3), new Course(4) };
            List<Group> groups = new List<Group>();
            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();
            List<Discipline> disciplines = new List<Discipline>();
            
            students.Add(new Student("Рудоков", "Даниил", courses[0], courses[0].NumberOfCourse*100+3));
            students.Add(new Student("Куликова", "Мария", courses[1], courses[1].NumberOfCourse*100+2));
            students.Add(new Student("Архипова", "Ева", courses[2], courses[2].NumberOfCourse*100+3));
            students.Add(new Student("Аксенов", "Роман", courses[3], courses[3].NumberOfCourse*100+4));
            students.Add(new Student("Воробьев", "Эмиль", courses[0], courses[0].NumberOfCourse*100+1));
            
            for (var i = 1; i < 5; i++)
            {
                groups.Add(new Group(i*100+1, courses[i-1], students));
                groups.Add(new Group(i*100+2, courses[i-1], students));
                groups.Add(new Group(i*100+3, courses[i-1], students));
                groups.Add(new Group(i*100+4, courses[i-1], students));
            }
            
            teachers.Add(new Teacher("Волкова", "Анастасия"));
            teachers.Add(new Teacher("Новикова", "Екатерина"));
            teachers.Add(new Teacher("Козлов", "Тимофей"));
            teachers.Add(new Teacher("Копылова", "Мария"));
            teachers.Add(new Teacher("Попов", "Алексей"));
            
            disciplines.Add(new Discipline("Экология", teachers[0], students, 1));
            disciplines.Add(new Discipline("Экономика", teachers[1], students, 1));
            disciplines.Add(new Discipline("Философия", teachers[2], students, 2));
            disciplines.Add(new Discipline("Иностранный язык", teachers[3], students, 3));
            disciplines.Add(new Discipline("Менеджмент", teachers[4], students, 4));

            var working = true;

            while (working)
            {
                Console.Clear();
                Console.WriteLine("Выбирете команду:");
                Console.Write("1 - Студенты\n2 - Преподаватели\n3 - Дисциплина\n4 - Группы\n5 - Получить информацию по ФИ\n0 - Выход из программы\n");
                Console.Write("Команда: ");
                var choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Выбирете команду:");
                        Console.Write("1 - Просмотреть информацию о студентах\n2 - Добавить нового студента\n0 - Вернуться в начальное меню\n");
                        Console.Write("Команда: ");
                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("Список студентов:");
                                foreach (var t in students)
                                {
                                    t.GetInfo();
                                }
                                break;
                            }
                            case 2:
                            {
                                Console.Clear();
                                Console.Write("Введите фамилию: ");
                                var surname = Console.ReadLine();
                                Console.Write("Введите имя: ");
                                var name = Console.ReadLine();
                                Console.Write("Какой курс: ");
                                var whichCourse = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Какая группа: ");
                                var whichGroup = Convert.ToInt32(Console.ReadLine());
                                students.Add(new Student(surname, name, courses[whichCourse - 1], whichGroup));
                                
                                foreach (var t in disciplines)
                                {
                                    if (t.NumberOfCourse == whichCourse)
                                    {
                                        t.AllStudents++;
                                    }
                                }

                                var lastItem = students.LastOrDefault();

                                if (lastItem != null && lastItem.LastName == surname && lastItem.FirstName == name && lastItem.Course.NumberOfCourse == whichCourse && lastItem.NumberOfGroup == whichGroup)
                                {
                                    Console.WriteLine("Успешно добавился!");
                                }
                                else
                                {
                                    Console.WriteLine("Не удалось добавить студента...");
                                }
                                break;
                            }
                            case 0: break;
                            default:
                            {
                                Console.WriteLine("Что-то пошло не так...");
                                break;
                            }
                        }
                        break;
                    }
                    case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Выбирете команду:");
                        Console.Write("1 - Просмотреть информацию о преподавателях\n2 - Добавить нового преподавателя\n0 - Вернуться в начальное меню\n");
                        Console.Write("Команда: ");
                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("Список преподавателей:");
                                foreach (var t in teachers)
                                {
                                    t.GetInfo();
                                }
                                break;
                            }
                            case 2:
                            {
                                Console.Clear();
                                Console.Write("Введите фамилию: ");
                                var surname = Console.ReadLine();
                                Console.Write("Введите имя: ");
                                var name = Console.ReadLine();
                                teachers.Add(new Teacher(surname, name));
                                
                                var lastItem = teachers.LastOrDefault();
                                
                                if (lastItem != null && lastItem.LastName == surname && lastItem.FirstName == name)
                                {
                                    Console.WriteLine("Успешно добавился!");
                                }
                                else
                                {
                                    Console.WriteLine("Не удалось добавить преподавателя...");
                                }
                                break;
                            }
                            case 0: break;
                            default:
                            {
                                Console.WriteLine("Что-то пошло не так...");
                                break;
                            }
                        }
                        break;
                    }
                    case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("Выбирете команду:");
                        Console.Write("1 - Просмотреть информацию о дисциплинах\n2 - Добавить новую дисциплину\n0 - Вернуться в начальное меню\n");
                        Console.Write("Команда: ");
                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("Список дисциплин:");
                                foreach (var t in disciplines)
                                {
                                    t.GetInfo();
                                }
                                break;
                            }
                            case 2:
                            {
                                Console.Clear();
                                Console.Write("Введите название дисциплины: ");
                                var nameDisc = Console.ReadLine();
                                Console.WriteLine("Выберите преподавателя:");
                                for (var i = 0; i < teachers.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} - {teachers[i].LastName} {teachers[i].FirstName}");
                                }
                                Console.Write("Напишите индекс выбранного преподавателя: ");
                                var selectedTeacher = Convert.ToInt32(Console.ReadLine()) - 1;
                                Console.Write("Какой курс: ");
                                var whichCourse = Convert.ToInt32(Console.ReadLine());
                                disciplines.Add(new Discipline(nameDisc, teachers[selectedTeacher], students, whichCourse));
                                var lastItem = disciplines.LastOrDefault();

                                if (lastItem != null && lastItem.Name == nameDisc && lastItem.Teacher == teachers[selectedTeacher] && lastItem.NumberOfCourse == whichCourse)
                                {
                                    Console.WriteLine("Успешно добавился!");
                                }
                                else
                                {
                                    Console.WriteLine("Не удалось добавить дисциплину...");
                                }
                                break;
                            }
                            case 0: break;
                            default:
                            {
                                Console.WriteLine("Что-то пошло не так...");
                                break;
                            }
                        }
                        break;
                    }
                    case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Выбирете команду:");
                        Console.Write("1 - Просмотреть информацию о группах\n0 - Вернуться в начальное меню\n");
                        Console.Write("Команда: ");
                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("1 - первый курс\n2 - второй курс\n3 - третий курс\n4 - четвёртый курс");
                                Console.Write("Выбирете курс: ");
                                var whichCourse = Convert.ToInt32(Console.ReadLine());
                                switch (whichCourse)
                                {
                                    case 1:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1 - 101\n2 - 102\n3 - 103\n4 - 104");
                                        Console.Write("Выбирете группу: ");
                                        var whichGroup = Convert.ToInt32(Console.ReadLine());

                                        switch (whichGroup)
                                        {
                                            case 1:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 101)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                break;
                                            }
                                            case 2:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 102)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                break;
                                            }
                                            case 3:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 103)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                break;
                                            }
                                            case 4:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 104)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            default:
                                            {
                                                Console.WriteLine("Ошибка: неизвестная группа!");
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    case 2:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1 - 201\n2 - 202\n3 - 203\n4 - 204");
                                        Console.Write("Выбирете группу: ");
                                        var whichGroup = Convert.ToInt32(Console.ReadLine());

                                        switch (whichGroup)
                                        {
                                            case 1:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 201)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            case 2:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 202)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            case 3:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 203)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            case 4:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 204)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            default:
                                            {
                                                Console.WriteLine("Ошибка: неизвестная группа!");
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    case 3:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1 - 301\n2 - 302\n3 - 303\n4 - 304");
                                        Console.Write("Выбирете группу: ");
                                        var whichGroup = Convert.ToInt32(Console.ReadLine());

                                        switch (whichGroup)
                                        {
                                            case 1:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 301)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            case 2:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 302)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            case 3:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 303)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            case 4:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 304)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                break;
                                            }
                                            default:
                                            {
                                                Console.WriteLine("Ошибка: неизвестная группа!");
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    case 4:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("1 - 401\n2 - 402\n3 - 403\n4 - 404");
                                        Console.Write("Выбирете группу: ");
                                        var whichGroup = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();

                                        switch (whichGroup)
                                        {
                                            case 1:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 401)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            case 2:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 402)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            case 3:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 403)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            case 4:
                                            {
                                                foreach (var gr in groups)
                                                {
                                                    if (gr.NumberOfGroup == 404)
                                                    {
                                                        gr.GetInfo();
                                                    }
                                                }
                                                
                                                break;
                                            }
                                            default:
                                            {
                                                Console.WriteLine("Ошибка: неизвестная группа!");
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    default:
                                    {
                                        Console.WriteLine("Ошибка: неизветсный курс!");
                                        break;
                                    }
                                }
                                break;
                            }
                            case 0: break;
                            default:
                            {
                                Console.WriteLine("Что-то пошло не так...");
                                break;
                            }
                        }
                        break;
                    }
                    case 5:
                    {
                        Console.Write("Введите фамилию и имя: ");
                        var name = Console.ReadLine();
                        string[] words = name.Split(' ');

                        foreach (var stu in students)
                        {
                            if ((words[0] == stu.LastName && words[1] == stu.FirstName) || (words[0] == stu.FirstName && words[1] == stu.LastName))
                            {
                                stu.GetStatus();
                            }
                        }
                        
                        foreach (var tea in teachers)
                        {
                            if (words[0] == tea.LastName && words[1] == tea.FirstName || words[0] == tea.FirstName && words[1] == tea.LastName)
                            {
                                tea.GetStatus();
                            }
                        }
                        break;
                    }
                    case 0:
                    {
                        working = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Неизвестная команда");
                        break;
                    }
                }

                if (choice != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }

    public abstract class User
    {
        public readonly string LastName;
        public readonly string FirstName;

        protected User(string lastName, string firstName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"\nФамилия: {LastName}\nИмя: {FirstName}");
        }

        public abstract void GetStatus();
    }

    public class Student : User
    {
        public readonly Course Course;
        public readonly int NumberOfGroup;

        public Student(string lastName, string firstName, Course course, int numberOfGroup)
            : base(lastName, firstName)
        {
            Course = course;
            switch (course.NumberOfCourse)
            {
                case 1:
                {
                    switch (numberOfGroup)
                    {
                        case 101:
                        case 102:
                        case 103:
                        case 104:
                            NumberOfGroup = numberOfGroup;
                            break;
                    }

                    break;
                }
                
                case 2:
                {
                    switch (numberOfGroup)
                    {
                        case 201:
                        case 202:
                        case 203:
                        case 204:
                            NumberOfGroup = numberOfGroup;
                            break;
                    }

                    break;
                }
                
                case 3:
                {
                    switch (numberOfGroup)
                    {
                        case 301:
                        case 302:
                        case 303:
                        case 304:
                            NumberOfGroup = numberOfGroup;
                            break;
                    }

                    break;
                }
                
                case 4:
                {
                    switch (numberOfGroup)
                    {
                        case 401:
                        case 402:
                        case 403:
                        case 404:
                            NumberOfGroup = numberOfGroup;
                            break;
                    }

                    break;
                }
            }
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Курс: {Course.NumberOfCourse}\nГруппа: {NumberOfGroup}");
            Console.WriteLine();
        }

        public override void GetStatus()
        {
            Console.WriteLine("Это студент");
        }
    }

    public class Teacher : User
    {
        public Teacher(string lastName, string firstName) : base(lastName, firstName) { }

        public override void GetStatus()
        {
            Console.WriteLine("Это преподаватель");
        }
    }

    public class Discipline : Course
    {
        public readonly string Name;
        public readonly Teacher Teacher;
        public List<Student> Students;
        public int AllStudents;

        public Discipline(string name, Teacher teacher, List<Student> students, int numberOfCourse) : base(numberOfCourse)
        {
            Name = name;
            Teacher = teacher;
            Students = students;
            foreach (var t in students)
            {
                if (t.Course.NumberOfCourse == numberOfCourse)
                {
                    AllStudents++;
                }
            }
        }
        
        public void GetInfo()
        {
            Console.WriteLine($"Название дисциплины: {Name}\nНа какой курсе дисциплина: {NumberOfCourse}\nПреподаватель: {Teacher.LastName} {Teacher.FirstName}\nКол-во студентов: {AllStudents}");
            Console.WriteLine();
        }
    }

    public class Course
    {
        public readonly int NumberOfCourse;

        public Course(int numberOfCourse)
        {
            NumberOfCourse = numberOfCourse;
        }
    }

    public class Group
    {
        public readonly int NumberOfGroup;
        public Course Course;
        private readonly List<Student> _students; 

        public Group(int numberOfGroup, Course course, List<Student> students)
        {
            Course = course;
            _students = students;
            
            switch (course.NumberOfCourse)
            {
                case 1:
                {
                    switch (numberOfGroup)
                    {
                        case 101:
                        case 102:
                        case 103:
                        case 104:
                            NumberOfGroup = numberOfGroup;
                            break;
                        default:
                            Console.WriteLine("Неизвестная группа");
                            break;
                    }

                    break;
                }
                
                case 2:
                {
                    switch (numberOfGroup)
                    {
                        case 201:
                        case 202:
                        case 203:
                        case 204:
                            NumberOfGroup = numberOfGroup;
                            break;
                        default:
                            Console.WriteLine("Неизвестная группа");
                            break;
                    }

                    break;
                }
                
                case 3:
                {
                    switch (numberOfGroup)
                    {
                        case 301:
                        case 302:
                        case 303:
                        case 304:
                            NumberOfGroup = numberOfGroup;
                            break;
                        default:
                            Console.WriteLine("Неизвестная группа");
                            break;
                    }

                    break;
                }
                
                case 4:
                {
                    switch (numberOfGroup)
                    {
                        case 401:
                        case 402:
                        case 403:
                        case 404:
                            NumberOfGroup = numberOfGroup;
                            break;
                        default:
                            Console.WriteLine("Неизвестная группа");
                            break;
                    }

                    break;
                }
            }
        }

        public void GetInfo()
        {
            foreach (var stu in _students)
            {
                if (stu.NumberOfGroup == NumberOfGroup)
                {
                    Console.WriteLine($"Фамилия: {stu.LastName}\nИмя: {stu.FirstName}");
                }
            }
        }
    }
    
}
