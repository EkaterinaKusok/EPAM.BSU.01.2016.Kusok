using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty
{
    public class Person
    {
        private string _name;
        private Person()
        {
            _name = null;
        }
        protected Person(string name)
        {
            _name = name;
        }
    }

    public class Teacher : Person
    {
        public Teacher(string name) : base(name) { }

        public bool OpenCourse(int courseCode, string courseName)
        {
            return CourseBoard.AddCourse(courseCode, courseName);
        }

        public bool StartCourseClasses(int courseCode)
        {
            return CourseBoard.StartClasses(courseCode);
        }

        public bool SetRating(int courseCode, Student student, int rating)
        {
            return Archive.SetRating(courseCode, this, student, rating);
        }
    }
    public class Student : Person
    {
        public Student(string name) : base(name) { }
        public bool RegistrationOnCourse (int courseCode)
        {
            return CourseBoard.AddStudentInOpenCourse(this, courseCode);
        }
    }

}
