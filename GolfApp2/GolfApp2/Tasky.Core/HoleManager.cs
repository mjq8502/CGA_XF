using System;
using System.Collections.Generic;
using System.Linq;

namespace DataObjects
{
    /// <summary>
    /// Manager classes are an abstraction on the data access layers
    /// </summary>
    public static class HoleManager
    {

        static HoleManager()
        {
        }


        public static IList<CourseTeeHoleData> GetCourseHoleData(int courseID)
        {
            return new List<CourseTeeHoleData>(CompleteGolfAppRepositoryADO.GetCourseHoleData(courseID));
        }

        public static CourseHoleByNumberListList GetCourseHolesByHole(int courseID)
        {
            IEnumerable<CourseTeeHoleData> chd = HoleManager.GetCourseHoleData(courseID);

            #region courseHolesByHole
            var courseHolesByHole = new CourseHoleByNumberListList
            {
                CourseHoleDataLists = chd.GroupBy(g => new
                {
                    g.HoleNumber
                })
                .Select(ch => new CourseHoleByNumberList
                {
                    HoleNumber = ch.Key.HoleNumber,
                    CourseHoles = ch.GroupBy(g => new
                    {
                        g.CourseTeeID,
                        g.HoleNumber,
                        g.ActualYardage,
                        g.CourseReportedYardage,
                        //g.Par,
                        g.TeeName

                    }).Select(ch2 => new CourseTeeHole
                    {
                        CourseTeeID = ch2.Key.CourseTeeID,
                        HoleNumber = ch2.Key.HoleNumber,
                        //Par = ch2.Key.Par,
                        CourseReportedYardage = ch2.Key.CourseReportedYardage,
                        ActualYardage = ch2.Key.ActualYardage,
                        TeeName = ch2.Key.TeeName
                    }).ToList()
                }).ToList()
            };
            #endregion

            return courseHolesByHole;


        }

        public static int CreateCourseHolesForTee(int courseTeeID, int numberOfHoles)
        {
            return CompleteGolfAppRepositoryADO.CreateCourseHolesForTee(courseTeeID, numberOfHoles);
        }

        public static int UpdateCourseTeeHole(int courseTeeID, int holeNumber, int yards)
        {
            return CompleteGolfAppRepositoryADO.UpdateCourseTeeHole(courseTeeID, holeNumber, yards);
        }


        //public static int DeleteCourse(int id)
        //{
        //    return CompleteGolfAppRepositoryADO.DeleteCourse(id);
        //}

        #region courseHolesByTee
        //var courseHolesByTee = new CourseHoleDataListList
        //{
        //    CourseHoleDataLists = chd.GroupBy(g => new
        //    {
        //        g.CourseTeeID,
        //        g.TeeName
        //    })
        //    .Select(ch => new CourseHoleDataList
        //    {
        //        CourseTeeID = ch.Key.CourseTeeID,
        //        TeeName= ch.Key.TeeName,
        //        CourseHoles = ch.GroupBy(g => new
        //        {
        //            g.CourseTeeID,
        //            g.TeeName,
        //            g.HoleNumber,
        //            g.ActualYardage,
        //            g.CourseReportedYardage,
        //            g.Par

        //        }).Select(ch2 => new CourseHole
        //        {
        //            CourseTeeID = ch2.Key.CourseTeeID,
        //            HoleNumber = ch2.Key.HoleNumber,
        //            Par = ch2.Key.Par,
        //            CourseReportedYardage = ch2.Key.CourseReportedYardage,
        //            ActualYardage = ch2.Key.ActualYardage,
        //            TeeName = ch2.Key.TeeName
        //        }).ToList()
        //    }).ToList()
        //};

        #endregion
    }
}