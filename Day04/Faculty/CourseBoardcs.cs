using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty
{
    internal static class CourseBoard
    {
        private static List<Course> _listOpenWritingCourses = new List<Course>();
        private static List<Course> _listCurrentCourses = new List<Course>();
        static CourseBoard() { }

        internal static bool AddCourse(int code, string name)
        {
            Course course = new Course(code, name);
            _listOpenWritingCourses.Add(course);
            return true;
        }

        internal static bool AddStudentInOpenCourse(Student student, int code)
        {
            foreach (var currentCourse in _listOpenWritingCourses)
            {
                if (currentCourse.CourseCode == code)
                {
                    currentCourse.AddStudent(student);
                    return true;
                }
            }
            // не найден курс
            return false;
        }
        
        internal static bool StartClasses(int courseCode)
        {
            var currentCourse = new Course();
            foreach (var variable in _listOpenWritingCourses)
            {
                if (variable.CourseCode == courseCode)
                {
                    currentCourse = variable;
                    break;
                }
            }
            if (currentCourse.CourseCode == 0) return false; // курс не найден
            _listOpenWritingCourses.Remove(currentCourse);
            _listCurrentCourses.Add(currentCourse);
            return true;
        }

        private class Course
        {
            private int _courseCode;
            private string _courseName;
            private static List<Student> _students = new List<Student>();
            internal int CourseCode { get; }
            internal Course()
            {
                _courseCode = 0;
                _courseName = null;
            }
            internal Course(int code, string name)
            {
                _courseCode = code;
                _courseName = name;
            }
            internal bool AddStudent(Student student)
            {
                _students.Add(student);
                return true;
            }
        }
    }
}
