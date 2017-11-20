using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace GolfApp2
{
    public partial class Main : ContentPage
    {

        public Main()
        {
            try
            {
                InitializeComponent();

                this.BackgroundImage = "screenshot_20170212_094404.png";

                this.mainTeesButton.Clicked += async (sender, args) =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new Tees());
                };

                this.mainCoursesButton.Clicked += async (sender, args) =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new Courses());
                };

                var c = App.database.GetItems<Person>();
                var cc = App.database.GetItems<GolfApp2.Models.Tees>();
                var z = 5;
            }
            catch(Exception ex)
            {
                var ss = ex;
            }
        }


        //Hey you there zz bbb

    }
}
