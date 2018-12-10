using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuesBox
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectColorPage : ContentPage

    {   
        //For slider numerical value
        public double ColorRed { get; set; } = 0;
        public double ColorGreen { get; set; } = 0;
        public double ColorBlue { get; set; } = 0;

        //For converted Hex Value
        public string HexValueRed { get; set; } = "00";
        public string HexValueGreen { get; set; } = "00";
        public string HexValueBlue { get; set; } = "00";

        //Users entered value
        public string ColorUserInput { get; set; } = "000000";

        public SelectColorPage (Double CameraRed, Double CameraGreen, Double CameraBlue, Boolean IsUsingCameraColor)
		{
			InitializeComponent ();

            if (IsUsingCameraColor == false)
            { }

            else 
            {

                ColorRed = CameraRed;
                ColorGreen = CameraGreen;
                ColorBlue = CameraBlue;

                HexValueRed = Convert.ToInt32(ColorRed).ToString("X2");
                HexValueGreen = Convert.ToInt32(ColorGreen).ToString("X2");
                HexValueBlue = Convert.ToInt32(ColorBlue).ToString("X2");

                ColorEntry.Text = "#" + HexValueRed + HexValueGreen + HexValueBlue;
                ColorPreview.Color = Color.FromHex(HexValueRed + HexValueGreen + HexValueBlue);
            }
              
                
                

		}

        private void Slider_ValueRed(object sender, ValueChangedEventArgs e)
        {
            ColorRed = e.NewValue;

            //Round the numerical slider value then convert to double digit hex value
            HexValueRed = Convert.ToInt32(ColorRed).ToString("X2");

            //Put hex values together and output as color and label
            ColorEntry.Text = "#" + HexValueRed + HexValueGreen + HexValueBlue;
            ColorPreview.Color = Color.FromHex(HexValueRed + HexValueGreen + HexValueBlue);


        }

        private void Slider_ValueGreen(object sender, ValueChangedEventArgs e)
        {
            ColorGreen = e.NewValue;

            HexValueGreen = Convert.ToInt32(ColorGreen).ToString("X2");

            ColorEntry.Text = "#" + HexValueRed + HexValueGreen + HexValueBlue;
            ColorPreview.Color = Color.FromHex(HexValueRed + HexValueGreen + HexValueBlue);


        }

        private void Slider_ValueBlue(object sender, ValueChangedEventArgs e)
        {
            ColorBlue = e.NewValue;     

            HexValueBlue = Convert.ToInt32(ColorBlue).ToString("X2");

            ColorEntry.Text = "#" + HexValueRed + HexValueGreen + HexValueBlue;
            ColorPreview.Color = Color.FromHex(HexValueRed + HexValueGreen + HexValueBlue);

        }
         
        //Grab the users color entry input, validate it as a hex code with or without the #, and change the color preview
        private void ColorEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            ColorUserInput = e.NewTextValue;
            ColorUserInput.Trim();

            int res = 0;
            if ((ColorUserInput.Length == 6) && int.TryParse(ColorUserInput,
            System.Globalization.NumberStyles.HexNumber,
            System.Globalization.CultureInfo.InvariantCulture, out res))
            {
                ColorPreview.Color = Color.FromHex(ColorUserInput);
            }
            else
            {  
                if (ColorUserInput.Length > 1)
                ColorUserInput = ColorUserInput.Substring(1);

                if ((ColorUserInput.Length == 6) && int.TryParse(ColorUserInput,
                    System.Globalization.NumberStyles.HexNumber,
                    System.Globalization.CultureInfo.InvariantCulture, out res))
                {
                    ColorPreview.Color = Color.FromHex(ColorUserInput);
                }
            }
        }

        private void SubmitButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResultsPage(ColorUserInput, HexValueRed, HexValueBlue, HexValueGreen, ColorRed, ColorBlue, ColorGreen));
        }


        private void CameraButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CameraPage());
        }
    }
}