using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Shark
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Course[] courses = { new Course(1), new Course(2), new Course(3), new Course(4) };
            List<Student> students = new List<Student>();


        }
    }

    public class User
    {
        public string FirstName;
        public string LastName;

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public class Student : User
    {
        public Course Course;

        public Student(string firstName, string lastName, Course course)
            : base(firstName, lastName)
        {
            Course = course;
        }

        public void GetInfo()
        {
            Console.WriteLine($"\nФамилия: {FirstName}\nИмя: {LastName}\nКурс: {Course.NumberOfCourse}");
        }
    }

    public class Teacher : User
    {
        public Teacher(string firstName, string lastName) : base(firstName, lastName) { }
        public void GetInfo()
        {
            Console.WriteLine($"Фамилия: {FirstName}\nИмя: {LastName}");
        }
    }

    public class Discipline : Course
    {
        public string Name;
        public Teacher Teacher;
        public int AllStudents = 0;

        public Discipline(string name, Teacher teacher, List<Student> students, int numberOfCourse) : base(numberOfCourse)
        {
            Name = name;
            Teacher = teacher;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Course.NumberOfCourse == numberOfCourse)
                {
                    AllStudents++;
                }
            }
        }
        
        public void GetInfo()
        {
            Console.WriteLine($"Название дисциплины: {Name}\nПреподаватель: {Teacher.FirstName} {Teacher.LastName}\nКол-во студентов: {AllStudents}");
        }
    }

    public class Course
    {
        public int NumberOfCourse;

        public Course(int numberOfCourse)
        {
            NumberOfCourse = numberOfCourse;
        }
    }
    
}