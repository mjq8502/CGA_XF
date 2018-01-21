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
            database = new Database("GolfApp2"); // Creates (if does not exist) a database named People
            database.CreateTable<Person>(); // Creates (if does not exist) a table of type Tees
            database.CreateTable<GolfApp2.Models.Tees>();
            database.CreateTable<GolfApp2.Models.Course>();
            database.CreateTable<GolfApp2.Models.CourseTee>();
            //GolfApp2.Models.Tees ts = new Models.Tees();
            //ts.TeeName = "Orange";
            
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
