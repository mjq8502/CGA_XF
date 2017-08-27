using System;
using System.Collections.Generic;

namespace DataObjects
{
    /// <summary>
    /// Manager classes are an abstraction on the data access layers
    /// </summary>
    public static class CourseManager
    {

        static CourseManager()
        {
        }

        public static Course GetCourse(int id)
        {
            return CompleteGolfAppRepositoryADO.GetCourse(id);
        }

        public static Course GetCourse(string newCourseName)
        {
            return CompleteGolfAppRepositoryADO.GetCourse(newCourseName);
        }

        public static IList<Course> GetCourses()
        {
            return new List<Course>(CompleteGolfAppRepositoryADO.GetCourses());
        }

        public static int SaveCourse(Course item)
        {
            return CompleteGolfAppRepositoryADO.SaveCourse(item);
        }

        public static int DeleteCourse(int id)
        {
            return CompleteGolfAppRepositoryADO.DeleteCourse(id);
        }
    }
}