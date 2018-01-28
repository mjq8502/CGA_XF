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
using GolfApp2;

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
    public partial class CourseEntryy : ContentPage, INotifyPropertyChanged
    {

        public CourseEntryy(int? courseID)
        {
            try
            {

            InitializeComponent();
            this.BindingContext = new GolfApp2.ViewModel.CourseEntryyViewModel(courseID, Navigation);

            this.BackgroundImage = "colberthills.png";
 
            }
            catch(Exception ex)
            {
                var x = ex;
            }

        }

        protected override void OnAppearing()
        {

            MessagingCenter.Send<CourseEntryy>(this, "CourseEntryy_OnAppearing");

        }

        private void listViewCourseTees_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var x = this.CarouselHoles.Position; 
            
            var z = 7;
        }

        private void buttonCarouselSave_Clicked(object sender, EventArgs e)
        {
            var x = this.CarouselHoles.Position;

            var z = 7;
        }
    }
}