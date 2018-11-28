using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorThiefDotNet;
using Plugin.Media;
using System.Drawing;

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

        private async void CameraButton_Clicked(object sender, EventArgs e)
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


            // David - see possible colorthief implementation here
            ColorThiefImplementation ct = new ColorThiefImplementation();

            List<QuantizedColor> palette = await ct.GetPalette(pictureFromPage.Source);

            // you can call with custom params to modify the palette you get - default is  int colorCount = 5, int quality = 10, bool ignoreWhite = true
            // e.g.
            // var palette = ct.GetPalette(pictureFromPage.Source, 10, 10, true); would give you 10 colors back

            // alternatively, if you want primary color only:
            // QuantizedColor color = await ct.GetColor(pictureFromPage.Source);


            // sample putting some colors on the page
            // note some error handling might be good here... what if we don't have 3 colors in the palette?
            firstColor.BackgroundColor = Xamarin.Forms.Color.FromHex(palette[0].Color.ToHexString());
            secondColor.BackgroundColor = Xamarin.Forms.Color.FromHex(palette[1].Color.ToHexString());
            thirdColor.BackgroundColor = Xamarin.Forms.Color.FromHex(palette[3].Color.ToHexString());

            colors.IsVisible = true;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

           
        }
    }
}