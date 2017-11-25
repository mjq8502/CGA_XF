using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GolfApp2.Models;

namespace GolfApp2.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeesEntry : ContentPage
    {
        public TeesEntry()
        {
            InitializeComponent();

            this.BackgroundImage = "colberthills.png";

            try
            {
                this.buttonSave.Clicked += (sender, args) =>
                {
                    App.database.SaveItem<GolfApp2.Models.Tees>(new GolfApp2.Models.Tees { TeeName = entryTeeName.Text });
                    //MessagingCenter.Send< TeesEntry, string >(this, "TeesEntryPopped", null);
                    Application.Current.MainPage.Navigation.PopAsync(); //Remove the page currently on top.
                };
            }
            catch(Exception ex)
            {
                var x = ex;
            }
        }
    }
}