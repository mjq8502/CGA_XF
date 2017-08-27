using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Tasky
{
    //public class DialogEvent
    //{
    //    public delegate void DialogEventDelegate();

    //    public event DialogEventDelegate dialogEventDelegate;

    //    public void Notify()
    //    {
    //        if (this.dialogEventDelegate != null)
    //        {
    //            this.dialogEventDelegate();
    //        }

    //    }
    //}

    public delegate void DialogEventHandler(object sender, DialogEventArgs args);

    public class DialogEventArgs : EventArgs
    {
        public string Text { get; set; }
    }
}