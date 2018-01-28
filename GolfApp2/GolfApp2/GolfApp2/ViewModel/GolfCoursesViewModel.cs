using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using GolfApp2.Screens;
using System.ComponentModel;
using System.Collections.ObjectModel;
using GolfApp2.Models;

namespace GolfApp2
{
    public partial class GolfCoursesViewModel : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Course> _Courses;
        public ObservableCollection<Course> Courses
        {
            get
            {
                return _Courses;
            }
            set
            {
                _Courses = value;

                PropertyChangedEventHandler handler = PropertyChanged;

                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs("Courses"));
                }
            }


        }

        public GolfCoursesViewModel()
        {
            try
            {

                MessagingCenter.Subscribe<GolfCourses>(this, "GolfCourses_OnAppearing", (sender) => {
                    var crs = App.database.GetItems<GolfApp2.Models.Course>();
                    Courses = new ObservableCollection<GolfApp2.Models.Course>(crs);
                });



            }
            catch (Exception ex)
            {
                var d = ex;
            }
        }


        //protected override void OnAppearing()
        //{
        //    try
        //    {
        //        var courses = App.database.GetItems<GolfApp2.Models.Course>();
        //        Courses = new ObservableCollection<GolfApp2.Models.Course>(courses);
        //        var f = 6;
        //    }
        //    catch (Exception ex)
        //    {
        //        var e = 7;
        //    }
        //}



    }
}

