using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GolfApp2.Models;
using System.Collections.ObjectModel;

namespace GolfApp2.Screens
{
    public class DemoHole
    {
        public int HoleNumber { get; set; }
        public int HolePar { get; set; }
        public string HoleTee { get; set; }
        public int HoleYards { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseEntryy : ContentPage
    {
        SelectMultipleBasePage<CheckItem> multiPage;
        private int currentCourseID;

        public ObservableCollection<DemoHole> demoHoles { get; set; }

        public CourseEntryy(int? courseID)
        {
            InitializeComponent();

            this.BackgroundImage = "colberthills.png";

            if (courseID != null)
            {
                var course = App.database.GetItems<GolfApp2.Models.Courses>().Where(c => c.ID == courseID).FirstOrDefault();
                buttonAddTee.IsEnabled = true;
                entryName.Text = course.Name;
                entryCity.Text = course.City;
                entryState.Text = course.StateCode;
                entryHoles.Text = course.NumberOfHoles.ToString();
                entryPar.Text = course.Par.ToString();
                currentCourseID = (int)courseID;
            }

            try
            {
                this.buttonSave.Clicked += (sender, args) =>
                {
                    if (courseID == null)
                    {
                        App.database.SaveItem<GolfApp2.Models.Courses>(new GolfApp2.Models.Courses
                        {
                            Name = entryName.Text,
                            City = entryCity.Text,
                            StateCode = entryState.Text,
                            NumberOfHoles = Int32.Parse(entryHoles.Text),
                            Par = Int32.Parse(entryPar.Text)
                        });
                        // Get the newly added course
                        var newCourse = App.database.GetItems<GolfApp2.Models.Courses>().Where(t => t.Name == entryName.Text).FirstOrDefault();
                        currentCourseID = newCourse.ID;
                        buttonAddTee.IsEnabled = true;
                    }
                    else
                    {
                        // Do an update here.
                        //App.database.SaveItem<GolfApp2.Models.Courses>(new GolfApp2.Models.Courses
                        //{
                        //    Name = entryName.Text,
                        //    City = entryCity.Text,
                        //    StateCode = entryState.Text,
                        //    NumberOfHoles = Int32.Parse(entryHoles.Text),
                        //    Par = Int32.Parse(entryPar.Text)
                        //});
                    }
                    //MessagingCenter.Send< CourseEntryy, string >(this, "CourseEntryPopped", null);
                    //Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
                };

                demoHoles = new ObservableCollection<DemoHole>
                {
                    new DemoHole
                    {
                        HoleNumber = 1,
                        HolePar = 4,
                        HoleTee = "Red",
                        HoleYards = 303
                    },
                        new DemoHole
                    {
                        HoleNumber = 2,
                        HolePar = 3,
                        HoleTee = "Red",
                        HoleYards = 113
                    },
                    new DemoHole
                    {
                        HoleNumber = 3,
                        HolePar = 3,
                        HoleTee = "Red",
                        HoleYards = 120
                    }
                };

                this.CarouselHoles.ItemsSource = demoHoles;
            }




            catch(Exception ex)
            {
                var x = ex;
            }

            this.buttonAddTee.Clicked += async (sender, args) =>
            {
                List<GolfApp2.Models.Tees> tees = App.database.GetItems<GolfApp2.Models.Tees>().ToList<GolfApp2.Models.Tees>();
                List<CheckItem> items = new List<CheckItem>();
                foreach(GolfApp2.Models.Tees itm in tees)
                {
                    //items.Add(new CheckItem { Name = "At work" });
                    items.Add(new Screens.CheckItem { Name = itm.TeeName });
                }

                multiPage = new SelectMultipleBasePage<CheckItem>(items) { Title = "Check all that apply" };
                await Navigation.PushAsync(multiPage);

            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (multiPage != null)
            {

                var answers = multiPage.GetSelection();
                foreach (var a in answers)
                {
                    var tee = App.database.GetItems<GolfApp2.Models.Tees>().Where(t => t.TeeName == a.Name).FirstOrDefault();
                    App.database.SaveItem<GolfApp2.Models.CourseTee>(new GolfApp2.Models.CourseTee
                    {
                        CourseID = currentCourseID, TeeID = tee.ID
                    });
                }
            }
            else
            {
                var t = 6;
            }

            listViewCourseTees.ItemsSource = App.database.GetItems<CourseTee>().Where(c => c.CourseID == currentCourseID);
        }

        private void listViewCourseTees_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}