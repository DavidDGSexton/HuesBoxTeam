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

            //Round the numerical slider value then convert to double digit hex value
            NewHexRed = Convert.ToInt32(NewRed).ToString("X2");
            NewHexBlue = Convert.ToInt32(NewBlue).ToString("X2");
            NewHexGreen = Convert.ToInt32(NewGreen).ToString("X2");

            this.Compliments.Add(new ColorOutput { HexColor = Color.FromHex(NewHexRed + NewHexGreen + NewHexBlue), HexValue = "# " + NewHexRed + NewHexGreen + NewHexBlue});
            ResultsListView.ItemsSource = this.Compliments;
		}

        public class ColorOutput
        {
            public Color HexColor { get; set; }
            public String HexValue { get; set; }
        }
	}
}
