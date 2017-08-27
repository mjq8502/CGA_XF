using System;

namespace DataObjects
{
    /// <summary>
    /// Tee business object
    /// </summary>
    public class CourseTee
    {
        public CourseTee()
        {
        }

        public int ID { get; set; }
        public int TeeID { get; set; }
        public int CourseID { get; set; }
        public int CourseReportedYardage { get; set; }
        public string TeeName { get; set; }

    }
}