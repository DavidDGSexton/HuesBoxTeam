using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuesBox
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultsPage : ContentPage
	{
        public ObservableCollection<ColorOutput> Compliments { get; set; }
        public double NewRed { get; set; } = 0;
        public double NewBlue { get; set; } = 0;
        public double NewGreen { get; set; } = 0;
        public string NewHexRed { get; set; } = "00";
        public string NewHexBlue { get; set; } = "00";
        public string NewHexGreen { get; set; } = "00";

        public ResultsPage(String UserInput, String HexValueRed, String HexValueBlue, String HexValueGreen, Double ColorRed, Double ColorBlue, Double ColorGreen)
   {
            
			InitializeComponent ();
            UserInputBoxView.BackgroundColor = Color.FromHex(UserInput);
            this.Compliments = new ObservableCollection<ColorOutput>();
            NewRed = 255 - ColorRed;
            NewBlue = 255 - ColorBlue;
            NewGreen = 255 - ColorGreen;
            
            NewHexRed = Convert.ToInt32(NewRed).ToString("X2");
            NewHexBlue = Convert.ToInt32(NewBlue).ToString("X2");
            NewHexGreen = Convert.ToInt32(NewGreen).ToString("X2");



            this.Compliments.Add(new ColorOutput { HexColor = Color.FromHex(NewHexRed + NewHexGreen + NewHexBlue), HexValue = "# " + NewHexRed + NewHexGreen + NewHexBlue});

            this.Compliments.Add(new ColorOutput { HexColor = Color.FromHex(RGBtoHSL(ColorRed, ColorBlue, ColorGreen)), HexValue = "# " + RGBtoHSL(ColorRed, ColorBlue, ColorGreen)});

            ResultsListView.ItemsSource = this.Compliments;
		}

        public class ColorOutput
        {
            public Color HexColor { get; set; }
            public String HexValue { get; set; }
        }
        public static String RGBtoHSL(double ColorRed, double ColorBlue, double ColorGreen)
        {
            double Light = 0;
            double Hue = 0;
            double Hue2 = 0;
            double Saturation = 0;
            double NewHSLRed = 0;
            double NewHSLBlue = 0;
            double NewHSLGreen = 0;
            double HSLRed = ColorRed / 255;
            double HSLBlue = ColorBlue / 255;
            double HSLGreen = ColorGreen / 255;
            double Red = 0;
            double Blue = 0;
            double Green = 0;
            double Var1 = 0;
            double Var2 = 0;
            string HexRed = "";
            string HexBlue = "";
            string HexGreen = "";
            double[] HSLArray = { HSLRed, HSLBlue, HSLGreen };

            double ValMin = HSLArray.Min();
            double ValMax = HSLArray.Max();
            double ValRange = ValMax - ValMin;

            Light = (ValMax + ValMin) / 2;
            if(ValRange == 0)
            {
                Hue = 0;
                Saturation = 0;
            }
            else
            {
                if(Light < 0.5)
                {
                    Saturation = ValRange / (ValMax + ValMin);

                }
                else
                {
                    Saturation = ValRange / (2 - ValMax - ValMin);
                }
                NewHSLRed = (((ValMax - HSLRed) / 6) + (ValRange / 2)) / ValRange;
                NewHSLBlue = (((ValMax - HSLBlue) / 6) + (ValRange / 2)) / ValRange;
                NewHSLGreen = (((ValMax - HSLGreen) / 6) + (ValRange / 2)) / ValRange;

                if(HSLRed == ValMax)
                {
                    Hue = NewHSLBlue - NewHSLGreen;
                }
                else if (HSLGreen == ValMax)
                {
                    Hue = (1 / 3) + NewHSLRed - NewHSLBlue;
                }
                else if (HSLBlue == ValMax)
                {
                    Hue = (2 / 3) + NewHSLGreen - NewHSLRed;
                }
                
                if(Hue < 0)
                {
                    Hue += 1;
                }

                if(Hue > 1)
                {
                    Hue -= 1;
                }

                
            }

            Hue2 = Hue + .5;
            if(Hue2 > 1)
            {
                Hue2 -= 1;
            }

            if(Saturation == 0)
            {
                Red = Light * 255;
                Green = Light * 255;
                Blue = Light * 255;
            }
            else
            {
                if(Light < 0.5)
                {
                    Var2 = Light * (1 + Saturation);
                }
                else
                {
                    Var2 = (Light + Saturation) - (Saturation * Light);
                }
                Var1 = 2 * Light - Var2;
                Red = 255 * HuetoRGB(Var1, Var2, Hue+(1/3));
                Green = 255 * HuetoRGB(Var1, Var2, Hue);
                Blue = 255 * HuetoRGB(Var1, Var2, Hue - (1 / 3));

            }
            HexRed = Convert.ToInt32(Red).ToString("X2");
            HexBlue = Convert.ToInt32(Blue).ToString("X2");
            HexGreen = Convert.ToInt32(Green).ToString("X2");

            return (HexRed + HexGreen + HexBlue);
        }

        public static double HuetoRGB (double Var1, double Var2, double Hue)
        {
            if(Hue < 0)
            {
                Hue += 1;
            }

            if(Hue > 1)
            {
                Hue -= 1;
            }

            if ((6 * Hue) < 1)
            {
                return (Var1 + (Var2 - Var1) * 6 * Hue);
            }
            if((2*Hue) < 1)
            {
                return Var2;
            }
            if ((3 * Hue) < 2)
            {
                return (Var1 + (Var2 - Var1) * ((2 / 3 - Hue) * 6));
            }
            return Var1;
        }
	}
}
