using System;

using Crawl.Models;
using Crawl.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crawl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterEditPage : ContentPage
	{
	    // ReSharper disable once NotAccessedField.Local
	    private CharacterDetailViewModel _viewModel;

        public Character Data { get; set; }

        public CharacterEditPage(CharacterDetailViewModel viewModel)
        {
            // Save off the item
            Data = viewModel.Data;
            viewModel.Title = "Edit " + viewModel.Title;

            InitializeComponent();
            

            // Set the data binding for the page
            BindingContext = _viewModel = viewModel;

            ////Need to make the SelectedItem a string, so it can select the correct item.
            //AttributePicker.SelectedItem = Data.Attribute.ToString();
        }

	    public async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EditData", Data);

            // removing the old CharacterDetails page, 2 up counting this page
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);

            // Add a new characters details page, with the new Character data on it
            await Navigation.PushAsync(new CharacterDetailPage(new CharacterDetailViewModel(Data)));

            // Last, remove this page
            Navigation.RemovePage(this);
        }

	    private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // The stepper function for Age
        void Age_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            AgeValue.Text = String.Format("{0}", e.NewValue);
        }
    }
}