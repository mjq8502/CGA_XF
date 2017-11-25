using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using GolfApp2.Screens;

namespace GolfApp2
{
    public partial class Courses : ContentPage
    {

        public Courses()
        {
            try
            {


                InitializeComponent();

                this.BackgroundImage = "screenshot_20170225_142535.png";

                var courses = App.database.GetItems<GolfApp2.Models.Courses>();
                listViewCourses.ItemsSource = courses; //.Select(x => x.TeeName);


                this.buttonAddCourse.Clicked += async (sender, args) =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new CourseEntryy(null));
                };

                this.listViewCourses.ItemSelected += async (sender2, args) =>
                {
                    GolfApp2.Models.Courses selectedItem = (GolfApp2.Models.Courses)listViewCourses.SelectedItem;
                    await Application.Current.MainPage.Navigation.PushAsync(new CourseEntryy(selectedItem.ID));
                };

                // Subscribe to "InformationReady" message.         
                //MessagingCenter.Subscribe<CourseEntryy, string>(this, "CourseEntryPopped", (sender, info) =>
                //{

                //    listViewCourses.ItemsSource = App.database.GetItems<GolfApp2.Models.Courses>();

                //});
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
                listViewCourses.ItemsSource = App.database.GetItems<GolfApp2.Models.Courses>();
                var f = 6;
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
