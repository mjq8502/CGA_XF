using System;
using System.Collections.Generic;
using System.Linq;

namespace DataObjects
{
    /// <summary>
    /// Manager classes are an abstraction on the data access layers
    /// </summary>
    public static class CourseHoleParManager
    {

        static CourseHoleParManager()
        {
        }

        public static IList<CourseHoleParData> GetCourseHoleParData(int courseID)
        {
            return new List<CourseHoleParData>(CompleteGolfAppRepositoryADO.GetCourseHoleParData(courseID));
        }

        public static CourseHoleParByNumberListList GetCourseHoleParsByHole(int courseID)
        {
            IEnumerable<CourseHoleParData> chd = CourseHoleParManager.GetCourseHoleParData(courseID);

            #region courseHoleParsByHole
            var courseHoleParsByHole = new CourseHoleParByNumberListList
            {
                CourseHoleParDataLists = chd.GroupBy(g => new
                {
                    g.HoleNumber
                })
                .Select(ch => new CourseHoleParByNumberList
                {
                    HoleNumber = ch.Key.HoleNumber,
                    CourseHolePars = ch.GroupBy(g => new
                    {
                        g._id,
                        g.CourseID,                  
                        g.HoleNumber,
                        g.Par

                    }).Select(ch2 => new CourseHolePar
                    {
                        _id = ch2.Key._id,
                        CourseID = ch2.Key.CourseID,
                        HoleNumber = ch2.Key.HoleNumber,
                        Par = ch2.Key.Par
                    }).ToList()
                }).ToList()
            };
            #endregion

            return courseHoleParsByHole;


        }


        public static int SaveCourseHole(int courseID, int holeNumber, int par)
        {
            return CompleteGolfAppRepositoryADO.SaveCourseHolePar(courseID, holeNumber, par);
        }


    }
}