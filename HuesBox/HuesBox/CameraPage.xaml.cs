using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using System.Drawing;
using Plugin.ImageEdit;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuesBox
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPage : ContentPage
    
	{
        public double RedColor { get; set; } = 0;
        public double GreenColor { get; set; } = 120;
        public double BlueColor { get; set; } = 0;

        public CameraPage()
        {
            InitializeComponent ();

          
        }

        private async void CameraButton_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
          

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "CameraImage.jpg"

            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            pictureFromPage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;

            });

            ColorOne.IsVisible = true;
            ColorTwo.IsVisible = true;
            ColorThree.IsVisible = true;
            ColorLabel.IsVisible = true;

        }


        private void ColorOne_Clicked(object sender, EventArgs e)
        {
            RedColor = 0;
            GreenColor = 253;
            BlueColor = 230;
            Navigation.PushAsync(new SelectColorPage(RedColor, GreenColor, BlueColor, true));
        }

        private void ColorTwo_Clicked(object sender, EventArgs e)
        {
            RedColor = 40;
            GreenColor = 42;
            BlueColor = 43;
            Navigation.PushAsync(new SelectColorPage(RedColor, GreenColor, BlueColor, true));
        }

        private void ColorThree_Clicked(object sender, EventArgs e)
        {
            RedColor = 250;
            GreenColor = 253;
            BlueColor = 249;
            Navigation.PushAsync(new SelectColorPage(RedColor, GreenColor, BlueColor, true));
        }


    }
}