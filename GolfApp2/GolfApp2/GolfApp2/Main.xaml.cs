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

               // var database = new Database("GolfApp2"); // Creates (if does not exist) a database named People
             //   database.CreateTable<GolfApp2.Models.Tees>(); // Creates (if does not exist) a table of type Tees
                //var database = new Database("People"); // Creates (if does not exist) a database named People
                //database.CreateTable<Person>(); // Creates (if does not exist) a table of type Tees
                //database.CreateTable<GolfApp2.Models.Tees>();
                //GolfApp2.Models.Tees ts = new Models.Tees();
                //ts.TeeName = "Orange";
                //  database.GetItems<GolfApp2.Models.Tees>();
                //App.database.SaveItem<Person>(new Person { Age = 33, FirstName = "Tommy", LastName = "Smaith", Gender = Gender.Male });
                //App.database.SaveItem<GolfApp2.Models.Tees>(ts);
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
