using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace GolfApp2
{
    public class Zoo
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }

    public partial class Main : ContentPage
    {
        public ObservableCollection<Zoo> Zoos { get; set; }

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
                Zoos = new ObservableCollection<Zoo>
        {
            new Zoo
            {
                ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/23c1dd13-333a-459e-9e23-c3784e7cb434/2016-06-02_1049.png",
                Name = "Woodland Park Zoo"
            },
                new Zoo
            {
                ImageUrl =    "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/6b60d27e-c1ec-4fe6-bebe-7386d545bb62/2016-06-02_1051.png",
                Name = "Cleveland Zoo"
                },
            new Zoo
            {
                ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png",
                Name = "Phoenix Zoo"
            }
        };

                this.CarouselZoos.ItemsSource = Zoos;
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
