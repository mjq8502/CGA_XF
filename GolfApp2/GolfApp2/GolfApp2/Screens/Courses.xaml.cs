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
               // this.BackgroundImage = "screenshot_20170225_142830.png";

                var tees = App.database.GetItems<GolfApp2.Models.Tees>();
                //listViewCourses.ItemsSource = tees; //.Select(x => x.TeeName);


                this.buttonAddCourse.Clicked += async (sender, args) =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new TeesEntry());
                };

                // Subscribe to "InformationReady" message.         
                MessagingCenter.Subscribe<TeesEntry, string>(this, "TeesEntryPopped", (sender, info) =>
                {

                    //tees = App.database.GetItems<GolfApp2.Models.Tees>();
                    listViewCourses.ItemsSource = App.database.GetItems<GolfApp2.Models.Tees>();

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
            GolfApp2.Models.Tees selectedItem = (GolfApp2.Models.Tees)listViewCourses.SelectedItem;
            //App.database.DeleteItem<GolfApp2.Models.Tees>(selectedItem.ID);
            listViewCourses.ItemsSource = App.database.GetItems<GolfApp2.Models.Tees>();
        }
    }
}
