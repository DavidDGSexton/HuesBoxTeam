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

        public CameraPage()
        {
            InitializeComponent ();

          
        }

        private async void TakePhotoButton_Tapped(object sender, EventArgs e)
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

           
        }

    }
}