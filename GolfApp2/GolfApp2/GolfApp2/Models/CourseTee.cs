using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GolfApp2.Models
{
    class CourseTee : BaseItem
    {
        public int CourseID { get; set; }

        public int TeeID { get; set; }

        public override string ToString() { return CourseID.ToString() + " " + TeeID.ToString(); }
    }
}
