using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Classes;

namespace SIS.Task
{
    internal class Task_4
    {
        Student student1 = new Student(101, "Caitlyn", "Kiraman", new DateTime(2000, 5, 15), "cait@mail.com", "1234567890");
        Student student2 = new Student(102, "David", "Johnson", new DateTime(1999, 8, 22), "dave@mail.com", "9876543210");
        Student student3 = new Student(107, "April", "Smith", new DateTime(2000, 10, 1), "april@mail.com", "9591529583");
        Student student4 = new Student(100, "Beth", "Michel", new DateTime(1999, 5, 12), "beth@mail.com", "9754283655");
        Student dummystud = new Student(190, "dummy", "dummy", new DateTime(1999, 5, 12), "dummy@mail.com", "9754283655");

        Course math = new Course(201, "Algebra", "MATH101", "");
        Course bio = new Course(201, "Biology", "BIO401", "");
        Course history = new Course(201, "History", "HIS74", "");
        Course dummyCourse = new Course(909, "Dummy", "DC90", "");

        Teacher teacher1 = new Teacher(1, "Jayce", "Norten", "jay@mail.com", "Algebra");
        Teacher teacher2 = new Teacher(2, "Haley", "Fields", "haley@mail.com", "History");
        Teacher teacher3 = new Teacher(3, "Roy", "Wells", "roy@mail.com", "Biology");
        Teacher dummyTeacher = new Teacher(4, "dummy", "dummy", "dummy@mail.com", "Biology");
        public void Exception1()
        {
            student1.EnrollInCourse(bio);
            student1.EnrollInCourse(bio);
        }

        public void Exception2()
        {
            Course.AllCourses.Remove(dummyCourse);
            student1.EnrollInCourse(dummyCourse);
            dummyCourse.AssignTeacher(teacher1);
        }

        public void Exception3()
        {
            Student.AllStudents.Remove(dummystud);
            dummystud.EnrollInCourse(bio);
            dummystud.MakePayment(6000, new DateTime(2025, 2, 15));
        }

        public void Exception4()
        {
            Teacher.AllTeachers.Remove(dummyTeacher);
            bio.AssignTeacher(dummyTeacher);
        }

        public void Exception5()
        {
            student2.MakePayment(-20, new DateTime(2027, 3, 3));
        }

        public void Exception6()
        {
            Student student4 = new Student(100, " ", "Michel", new DateTime(1999, 5, 12), "beth@mail.com", "9754283655");
        }

        public void Exception7()
        {
            math.UpdateCourseInfo("", "", "");
        }

        public void Exception8()
        {
            student1.EnrollInCourse(null);
        }

        public void Exception9()
        {
            Teacher teacher3 = new Teacher(3, "", "Wells", "roy@mail.com", "Biology");
        }

        public void Exception10()
        {
            student1.MakePayment(35000, new DateTime(2025, 2, 2));
        }

    }
}
