using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Shark
{
    internal class Program
    {
        public static void Main(string[] args)
        {
          
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
        public Discipline[] Disciplines;
        public List<string> StDisciplines;

        public Student(string firstName, string lastName, Course course, Discipline[] disciplines)
            : base(firstName, lastName)
        {
            Course = course;

            for (int i = 0; i < disciplines.Length; i++) 
            {
                if (Disciplines[i].NumberOfCourse == course.NumberOfCourse)
                {
                    StDisciplines.Add(Disciplines[i].Name);
                }
            }
        }

        public void GetInfo()
        {
            Console.WriteLine($"\nФамилия: {FirstName}\nИмя: {LastName}\nКурс: {Course}\nДисциплины: {Disciplines}");
        }
    }

    public class Teacher : User
    {
        public Discipline Discipline;

        public Teacher(string firstName, string lastName, Discipline discipline) : base(firstName, lastName)
        {
            Discipline = discipline;
        }
        
        public void GetInfo()
        {
            Console.WriteLine($"Фамилия: {FirstName}\nИмя: {LastName}\nДисциплина: {Discipline}");
        }
    }

    public class Discipline : Course
    {
        public string Name;
        public Teacher Teacher;
        public Student[] Students;
        public int AllStudents = 0;

        public Discipline(string name, Teacher teacher, int allStudents,Student[] students,int numberOfCourse) : base(numberOfCourse)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Course.NumberOfCourse == numberOfCourse)
                {
                    AllStudents++;
                }
            }
        }
        
        public void GetInfo()
        {
            Console.WriteLine($"Преподаватель: {Teacher}\nКол-во студентов{AllStudents}");

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