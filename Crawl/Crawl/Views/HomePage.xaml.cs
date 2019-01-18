using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crawl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        private async void CharactersButton_Command(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharactersPage());
        }

        private async void MonstersButton_Command(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MonstersPage());
        }

        private async void ItemsButton_Command(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());
        }
    }
}