using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Assg_4
{
    internal class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Semester { get; set; }
        public string Branch { get; set; }
        private int[] Marks = new int[5];

        public Student(int rollNo, string name, string studentClass, string semester, string branch)
        {
            RollNo = rollNo;
            Name = name;
            Class = studentClass;
            Semester = semester;
            Branch = branch;
        }

        public void GetMarks()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter marks for subject {i + 1}: ");
                Marks[i] = Convert.ToInt32((Console.ReadLine()));
            }
        }

        public void DisplayResult()
        {
            int total = 0;
            bool hasFailed = false;

            foreach (int mark in Marks)
            {
                if (mark < 35)
                {
                    hasFailed = true;
                }
                total += mark;
            }

            double average = total / 5.0;

            if (hasFailed || average < 50)
            {
                Console.WriteLine("Result: Failed");
            }
            else
            {
                Console.WriteLine("Result: Passed");
            }
        }

        public void DisplayData()
        {
            Console.WriteLine($"Roll No: {RollNo}\nName: {Name}\nClass: {Class}\nSemester: {Semester}\nBranch: {Branch}\nMarks:");
            foreach (int mark in Marks)
            {
                Console.WriteLine(mark);
            }
        }
    }
}
