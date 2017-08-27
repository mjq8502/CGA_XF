using System;

namespace DataObjects
{
    /// <summary>
    /// Hole business object
    /// </summary>
    public class Hole
    {
        public Hole()
        {
        }

        public int ID { get; set; }
        public int CourseTeeID { get; set; }
        //public int Course_ID { get; set; }
        //public int Tee_ID { get; set; }
        public int HoleNumber { get; set; }
        public int Yards { get; set; }
        public int Par { get; set; }

    }


 
}