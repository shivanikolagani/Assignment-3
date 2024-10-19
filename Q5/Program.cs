using System;
using System.Collections.Generic;
using System.Linq;

namespace Q5
{
    public class Student
    {
        public int RollNo;
        public string Name;
        public int Marks;
        public char SportsGrade;

        public Student(int RollNo, string Name, int Marks, char sportsGrade)
        {
            this.RollNo = RollNo;
            this.Name = Name;
            this.Marks = Marks;
            SportsGrade = sportsGrade;
        }
    }
    public delegate bool IsEligibleforScholarship(Student std);

    public class Program
    {
        public static bool ScholarshipEligibility(Student std)
        {
            return std.Marks > 80 && std.SportsGrade == 'A';
        }
        public static string GetEligibleStudents(List<Student> studentsList, IsEligibleforScholarship isEligible)
        {
            List<Student> eligibleStudents = studentsList.Where(s => isEligible(s)).ToList();
            return string.Join(",", eligibleStudents.Select(s => s.Name));
        }

        static void Main(string[] args)
        {

            List<Student> students = new List<Student>()
        {
            new Student(1, "Raj", 75, 'A'),
            new Student(2, "Rahul", 82, 'A'),
            new Student(3, "Kiran", 89, 'B'),
            new Student(4, "Sunil", 86, 'A')
        };


            string eligibleStudents = GetEligibleStudents(students, ScholarshipEligibility);

            Console.WriteLine(eligibleStudents);
        }
    }
}