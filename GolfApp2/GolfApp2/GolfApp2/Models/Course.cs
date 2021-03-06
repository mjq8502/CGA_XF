﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GolfApp2.Models
{
    public class Course : BaseItem
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string StateCode { get; set; }

        public int NumberOfHoles { get; set; }

        public int Par { get; set; }

        public override string ToString() { return Name; }
    }
}
