using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HuesBox
{
    public partial class MainPage : ContentPage
    

    {
        public double ColorRed { get; set; } = 0;
        public double ColorGreen { get; set; } = 0;
        public double ColorBlue { get; set; } = 0;

        public MainPage()
        {
            InitializeComponent();


        }


        private void paintBrushIconGestureRecognizer_OnTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SelectColorPage(ColorRed, ColorGreen, ColorBlue, false));
        }


        private void selectColorButtonGestureRecognizer_OnTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SelectColorPage(ColorRed, ColorGreen, ColorBlue, false));
        }


        private void envelopeIconGestureRecognizer_OnTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ContactPage());
        }


        private void contactUsButtonGestureRecognizer_OnTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ContactPage());
        }
    }


}