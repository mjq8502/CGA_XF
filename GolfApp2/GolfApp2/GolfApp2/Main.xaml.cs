using System;
using System.Collections.Generic;
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
            InitializeComponent();

            this.mainTeesButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushModalAsync(new Tees());
            };
        }

        //Hey you there zz aaa

    }
}
