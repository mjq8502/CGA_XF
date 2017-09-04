using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using GolfApp2.Screens;

namespace GolfApp2
{
    public partial class Tees : ContentPage
    {
        public Tees()
        {
            try
            {


                InitializeComponent();

                this.BackgroundImage = "screenshot_20170225_142830.png";

                listViewTees.ItemsSource = new List<string> { "Blue", "Black", "Green", "Purple", "Red" };

                this.buttonAddTee.Clicked += async (sender, args) =>
                {
                //await Navigation.PushModalAsync(new TeesEntry());
                await Application.Current.MainPage.Navigation.PushAsync(new TeesEntry());
                };
            }
            catch (Exception ex)
            {
                var d = ex;
            }
        }
    }
}
