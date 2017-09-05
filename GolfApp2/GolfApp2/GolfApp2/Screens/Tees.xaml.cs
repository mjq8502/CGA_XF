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

                var tees = App.database.GetItems<GolfApp2.Models.Tees>();
                listViewTees.ItemsSource = tees.Select(x => x.TeeName);


                this.buttonAddTee.Clicked += async (sender, args) =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new TeesEntry());
                };

                MessagingCenter.Subscribe<Page>(this, "popped", (sender) =>
                {
                    tees = App.database.GetItems<GolfApp2.Models.Tees>();
                    listViewTees.ItemsSource = tees.Select(x => x.TeeName);
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
                var tees = App.database.GetItems<GolfApp2.Models.Tees>();
                listViewTees.ItemsSource = tees.Select(x => x.TeeName);
            }
            catch(Exception ex)
            {
                var e = 7;
            }
        }

    }
}
