
using System;
using Crawl.Services;
using Crawl.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Crawl.ViewModels;
using Crawl.Models;
using System.Collections.Generic;

namespace Crawl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            // Example of how to add an view to an existing set of XAML. 
            // Give the Xaml layout you want to add the data to a good x:Name, so you can access it.  Here "DateRoot" is what I am using.
            var dateLabel = new Label
            {
                Text = DateTime.Now.ToShortDateString(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontFamily = "Helvetica Neue",
                FontAttributes = FontAttributes.Bold,
                FontSize = 12,
                TextColor = Color.Black,
            };

            DateRoot.Children.Add(dateLabel);
        }
    }
}