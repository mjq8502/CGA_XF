using System;

namespace DataObjects {
    /// <summary>
    /// Tee business object
    /// </summary>
    public class Tee  {
        public Tee  ()
        {
        }

        public int ID { get; set; }
        public string TeeName { get; set; }
        //public bool Done { get; set; }  // TODO: add this field to the user-interface
    }
}