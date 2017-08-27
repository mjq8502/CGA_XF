using System;
using System.Collections.Generic;

namespace DataObjects
{
    /// <summary>
    /// Manager classes are an abstraction on the data access layers
    /// </summary>
    public static class CourseTeeManager
    {

        static CourseTeeManager()
        {
        }

        public static CourseTee GetCourseTee(int id)
        {
            return CompleteGolfAppRepositoryADO.GetCourseTee(id);
        }

        public static IList<CourseTee> GetCourseTees(int courseID)
        {
            return new List<CourseTee>(CompleteGolfAppRepositoryADO.GetCourseTees(courseID));
        }

        public static IList<CourseTee> GetAllCourseTees()
        {
            return new List<CourseTee>(CompleteGolfAppRepositoryADO.GetAllCourseTees());
        }

        public static int SaveCourseTee(CourseTee item)
        {
            return CompleteGolfAppRepositoryADO.SaveCourseTee(item);
        }

        public static int DeleteCourseTee(int id)
        {
            return CompleteGolfAppRepositoryADO.DeleteCourseTee(id);
        }
    }
}