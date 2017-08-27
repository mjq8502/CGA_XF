using System;

namespace DataObjects
{
    /// <summary>
    /// Course business object
    /// </summary>
    public class Course
    {
        public Course()
        {
        }

        public int ID { get; set; }
        public string CourseName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Holes { get; set; }
        public int Par { get; set; }
        //public bool Done { get; set; }  // TODO: add this field to the user-interface
    }
}