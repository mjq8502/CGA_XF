using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GolfApp2
{
    public class App : Application
    {
        public static string perm;
        public static Database database;

        public App()
        {
            perm = "Permanent";
            database = new Database("People"); // Creates (if does not exist) a database named People
            database.CreateTable<Person>(); // Creates (if does not exist) a table of type Tees
            database.CreateTable<GolfApp2.Models.Tees>();
            GolfApp2.Models.Tees ts = new Models.Tees();
            ts.TeeName = "Orange";
            //MainPage = new Main();
            var MyAppsFirstPage = new Main();
            Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
        }


        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
