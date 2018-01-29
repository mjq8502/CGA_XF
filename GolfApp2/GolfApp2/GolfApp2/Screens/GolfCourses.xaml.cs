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
    public partial class GolfCourses : ContentPage
    {

        public GolfCourses()
        {
            try
            {


                InitializeComponent();

                this.BindingContext = new GolfApp2.GolfCoursesViewModel();

                this.BackgroundImage = "screenshot_20170225_142535.png";

                this.buttonAddCourse.Clicked += async (sender, args) =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new CourseEntryy(null));
                };

                this.listViewCourses.ItemSelected += async (sender2, args) =>
                {
                    GolfApp2.Models.Course selectedItem = (GolfApp2.Models.Course)listViewCourses.SelectedItem;
                    await Application.Current.MainPage.Navigation.PushAsync(new CourseEntryy(selectedItem.ID));
                };


            }
            catch (Exception ex)
            {
                var d = ex;
            }
        }


        protected override void OnAppearing()
        {
            try
            {

                var f = 6;
                MessagingCenter.Send<GolfCourses>(this, "GolfCourses_OnAppearing");
            }
            catch(Exception ex)
            {
                var e = 7;
            }
        }

        //private void listViewCourses_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    GolfApp2.Models.Courses selectedItem = (GolfApp2.Models.Courses)listViewCourses.SelectedItem;
        //    //App.database.DeleteItem<GolfApp2.Models.Tees>(selectedItem.ID);
        //    //listViewCourses.ItemsSource = App.database.GetItems<GolfApp2.Models.Courses>();
        //    //await Application.Current.MainPage.Navigation.PushAsync(new CourseEntryy(null));
        //    var x = 7;


        //}


}
}
