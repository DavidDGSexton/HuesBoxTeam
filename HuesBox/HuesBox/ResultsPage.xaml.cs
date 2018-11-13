﻿using System;
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
		public ResultsPage (String UserInput)
		{
			InitializeComponent ();

            this.ColorResults = new ObservableCollection<ColorResults>();

		}
	}
    public class ColorResults
    {
        public string Color { get; set; }
        public string HexValue { get; set; }
    }
}
