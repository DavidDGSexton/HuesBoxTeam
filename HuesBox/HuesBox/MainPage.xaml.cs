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
        public MainPage()
        {
            InitializeComponent();


        }


        private void paintBrushIconGestureRecognizer_OnTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SelectColorPage());
        }


        private void selectColorButtonGestureRecognizer_OnTapped(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SelectColorPage());
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