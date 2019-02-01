﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Crawl.Models;

namespace Crawl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterNewPage : ContentPage
    {
        public Character Data { get; set; }

        public CharacterNewPage()
        {
            InitializeComponent();

            Data = new Character
            {
                Name = "Character Name",
                Description = "This is a Character description.",
                Age = 20,
                Id = Guid.NewGuid().ToString()
            };

            BindingContext = this;
        }

        public async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddData", Data);
            await Navigation.PopAsync();
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