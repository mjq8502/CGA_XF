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
                //Application.Current.MainPage = new NavigationPage(this);

                this.mainTeesButton.Clicked += async (sender, args) =>
                {
                //await Navigation.PushModalAsync(new Tees());
                await Application.Current.MainPage.Navigation.PushAsync(new Tees());
                };

                var database = new Database("People"); // Creates (if does not exist) a database named People
                database.CreateTable<Person>(); // Creates (if does not exist) a table of type Person

                // database.SaveItem<Person>(new Person { Age = 12, FirstName = "Bill", LastName = "Haley", Gender = Gender.Male });
                // database.SaveItem<Person>(new Person { Age = 22, FirstName = "Tom", LastName = "Smoith", Gender = Gender.Male });

                var zz = database.GetItems<Person>();

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
