using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GolfApp2.Models
{
    public class Tees : BaseItem
    {
        //[PrimaryKey, AutoIncrement]
        //public int _id { get; set; }
        public string TeeName { get; set; }
    }



}
