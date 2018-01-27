using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GolfApp2.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GolfApp2.Screens;

namespace GolfApp2.ViewModel
{
    public class DemoHole2
    {
        public int HoleNumber { get; set; }
        public int HolePar { get; set; }
        public string HoleTee { get; set; }
        public int HoleYards { get; set; }
    }

    public partial class CourseEntryyViewModel : INotifyPropertyChanged
    {
        SelectMultipleBasePage<CheckItem> multiPage;
        private int currentCourseID;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<GolfApp2.Screens.DemoHole> demoHoles { get; set; }

        public ObservableCollection<CourseTee> courseTees { get; set; }

        private bool _IsLabelMode;
        public bool IsLabelMode
        {
            get
            {
                return _IsLabelMode;
            }

            set
            {
                _IsLabelMode = value;
                // Fire the event. 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsLabelMode"));
            }
        }

        private bool _IsEditMode;
        public bool IsEditMode
        {
            get
            {
                return _IsEditMode;
            }

            set
            {
                _IsEditMode = value;
                // Fire the event. 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEditMode"));
            }
        }

        private bool _IsAddTeeButtonEnabled;
        public bool IsAddTeeButtonEnabled
        {
            get
            {
                return _IsAddTeeButtonEnabled;
            }

            set
            {
                _IsAddTeeButtonEnabled = value;
                // Fire the event. 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsAddTeeButtonEnabled"));
            }
        }

        private double _editOpacity;
        public double EditOpacity
        {
            get
            {
                return _editOpacity;
            }

            set
            {
                _editOpacity = value;
                // Fire the event. 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EditOpacity"));
            }
        }

        private Course _Course;
        public Course Course
        {
            get { return _Course; }
            set
            {
                _Course = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Course"));
            }

        }

        public ICommand ButtonSave_Clicked { private set; get; }
        public ICommand ButtonAdd_Clicked { private set; get; }
        public bool canClick = true;

        public INavigation Navigation { get; set; }

        public CourseEntryyViewModel(int? courseID, INavigation navigation)
        {
            this.Navigation = navigation;
            try
            {
                if (courseID != null)
                {
                    var course = App.database.GetItems<GolfApp2.Models.Course>().Where(c => c.ID == courseID).FirstOrDefault();
                    Course = course;

                    var z = App.database.GetItems<CourseTee>().Where(c => c.CourseID == courseID);
                    courseTees = new ObservableCollection<CourseTee>(App.database.GetItems<CourseTee>().Where(c => c.CourseID == courseID));
                    IsAddTeeButtonEnabled = true; // buttonAddTee.IsEnabled = true;

                    currentCourseID = (int)courseID;
                    IsEditMode = false;
                    EditOpacity = 0;
                    IsLabelMode = true;
                }
                else
                {
                    IsEditMode = true;
                    EditOpacity = 1.0;
                    IsLabelMode = false;
                }

            
                ButtonSave_Clicked = new Command(() =>
                {
                    if (courseID == null)
                    {
                        App.database.SaveItem<GolfApp2.Models.Course>(new GolfApp2.Models.Course
                        {
                            Name = Course.Name,
                            City = Course.City,
                            StateCode = Course.StateCode,
                            NumberOfHoles = Course.NumberOfHoles,
                            Par = Course.NumberOfHoles
                        });
                        // Get the newly added course
                        var newCourse = App.database.GetItems<GolfApp2.Models.Course>().Where(t => t.Name == Course.Name).FirstOrDefault();
                        currentCourseID = newCourse.ID;
                        //buttonAddTee.IsEnabled = true;
                    }
                    else
                    {


                        if (IsEditMode)
                        {
                            IsEditMode = false;
                            IsLabelMode = true;
                        }
                        else
                        {
                            IsEditMode = true;
                            IsLabelMode = false;
                        }
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
                });

                ButtonAdd_Clicked = new Command(async () => await ButtonAdd_ClickAsync(), () => canClick);

                //MessagingCenter.Send< CourseEntryy, string >(this, "CourseEntryPopped", null);
                //Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top. });

                demoHoles = new ObservableCollection<GolfApp2.Screens.DemoHole>
                {
                    new GolfApp2.Screens.DemoHole
                    {
                        HoleNumber = 1,
                        HolePar = 4,
                        HoleTee = "Red",
                        HoleYards = 303
                    },
                        new GolfApp2.Screens.DemoHole
                    {
                        HoleNumber = 2,
                        HolePar = 3,
                        HoleTee = "Red",
                        HoleYards = 113
                    },
                    new GolfApp2.Screens.DemoHole
                    {
                        HoleNumber = 3,
                        HolePar = 3,
                        HoleTee = "Red",
                        HoleYards = 120
                    }
                };

            }

            catch (Exception ex)
            {
                var x = ex;
            }



        }

        public async Task ButtonAdd_ClickAsync()
        {
            List<GolfApp2.Models.Tees> tees = App.database.GetItems<GolfApp2.Models.Tees>().ToList<GolfApp2.Models.Tees>();
            List<GolfApp2.Screens.CheckItem> items = new List<GolfApp2.Screens.CheckItem>();
            foreach (GolfApp2.Models.Tees itm in tees)
            {
                items.Add(new Screens.CheckItem { Name = itm.TeeName });
            }

            multiPage = new SelectMultipleBasePage<GolfApp2.Screens.CheckItem>(items) { Title = "Check all that apply" };
            await Navigation.PushAsync(multiPage);

        }


    }
}
