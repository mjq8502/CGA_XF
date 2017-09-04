using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                this.buttonDone.Clicked += (sender, args) =>
                {
                  //  var zz = Navigation.NavigationStack.SelectMany<Page>();
                  // this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 1]);
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