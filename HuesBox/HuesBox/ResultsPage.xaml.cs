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
        public ObservableCollection<ColorResults> ColorResults { get; set; }
        public ObservableCollection<Color> Compliments { get; set; }
        public ResultsPage(String UserInput, String HexValueRed, String HexValueBlue, String HexValueGreen, Double ColorRed, Double ColorBlue, Double ColorGreen)
		{
            
			InitializeComponent ();
            UserInputBoxView.BackgroundColor = Color.FromHex(UserInput);
            this.ColorResults = new ObservableCollection<ColorResults>();
            this.Compliments = new ObservableCollection<Color>();
            this.Compliments.Add(Color.FromHex(HexValueBlue + HexValueRed + HexValueGreen));
            ResultsListView.ItemsSource = this.Compliments;
		}
	}
    public class ColorResults
    {
        public string Color { get; set; }
        public string HexValue { get; set; }
    }
}
