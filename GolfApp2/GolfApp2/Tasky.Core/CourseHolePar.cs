using System;
using System.Collections.Generic;
using System.Linq;
using Android.Runtime;
using Java.IO;

namespace DataObjects
{
    /// <summary>
    /// CourseHole object
    /// </summary>
    public class CourseHolePar
    {
        public int _id { get; set; }
        public int CourseID { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }

        public CourseHolePar()
        {
        }
    }

    public class CourseHoleParData
    {
        public CourseHoleParData()
        {

        }

        public int _id { get; set; }
        public int CourseID { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }

    }

    public class CourseHoleParDataList
    {
        public CourseHoleParDataList()
        {

        }
        public int CourseID { get; set; }
        public List<CourseHolePar> CourseHolePars { get; set; }


    }

    public class CourseHoleParDataListList
    {
        public CourseHoleParDataListList()
        {

        }
        public List<CourseHoleParDataList> CourseHoleParDataLists { get; set; }

    }


}