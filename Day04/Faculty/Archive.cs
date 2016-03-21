using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty
{
    internal static class Archive
    {
        private static List<Rating> _listRatings = new List<Rating>();
        static Archive() { }

        internal static bool SetRating(int courseCode, Teacher teacher, Student student, int rating)
        {
            Rating currentRating = new Rating(courseCode,teacher,student,rating);
            _listRatings.Add(currentRating);
            return true;
        }

        private class Rating
        {
            private int _courseCode;
            private Teacher _teacher;
            private Student _student;
            private int _rating;
            internal int CourseCode { get; }
            internal Rating()
            {
                _courseCode = 0;
                _teacher = null;
                _student = null;
                _rating = 0;
            }
            internal Rating(int courseCode, Teacher teacher, Student student, int rating)
            {
                _courseCode = courseCode;
                _teacher = teacher;
                _student = student;
                _rating = rating;
            }
        }
    }
}
