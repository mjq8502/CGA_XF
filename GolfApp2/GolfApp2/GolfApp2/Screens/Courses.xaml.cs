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
                    await Application.Current.MainPage.Navigation.PushAsync(new CourseEntry());
                };

                // Subscribe to "InformationReady" message.         
                MessagingCenter.Subscribe<CourseEntry, string>(this, "CourseEntryPopped", (sender, info) =>
                {

                    listViewCourses.ItemsSource = App.database.GetItems<GolfApp2.Models.Courses>();

                });
            }
            catch (Exception ex)
            {
                var d = ex;
            }
        }


        async void OnAppearing(object sender, EventArgs args)
        {
            try
            {
                //var tees = App.database.GetItems<GolfApp2.Models.Tees>();
                //listViewTees.ItemsSource = tees.Select(x => x.TeeName);
            }
            catch(Exception ex)
            {
                var e = 7;
            }
        }

        private void listViewCourses_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            GolfApp2.Models.Courses selectedItem = (GolfApp2.Models.Courses)listViewCourses.SelectedItem;
            //App.database.DeleteItem<GolfApp2.Models.Tees>(selectedItem.ID);
            //listViewCourses.ItemsSource = App.database.GetItems<GolfApp2.Models.Courses>();
        }
    }
}
