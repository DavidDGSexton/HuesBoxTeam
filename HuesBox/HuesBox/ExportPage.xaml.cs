using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HuesBox
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExportPage : ContentPage
	{
        public string ExportColor1 { get; set; } = "#FFFFFF";
        public string ExportColor2 { get; set; } = "#FFFFFF";
        public string ExportColor3 { get; set; } = "#FFFFFF";
        public string ExportColor4 { get; set; } = "#FFFFFF";
        public string ExportColor5 { get; set; } = "#FFFFFF";

        public ExportPage (String Color1, String Color2, String Color3, String Color4, String Color5)
		{
			InitializeComponent ();

            ExportColor1 = Color1;
            ExportColor2 = Color2;
            ExportColor3 = Color3;
            ExportColor4 = Color4;
            ExportColor5 = Color5;
        }


        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }



        private async void ExportToEmailButton_Tapped(object sender, EventArgs e)
        {
            List<string> recipients = new List<string>();

            recipients.Add(RecipientEmail.Text);
            



            await SendEmail("HuesBox Export",  "From: " + UserName.Text + "\r\n\r\n" + ExportColor1 + "\r\n\r\n" + ExportColor2 + "\r\n\r\n" + ExportColor3 + "\r\n\r\n" + ExportColor4 + "\r\n\r\n" + ExportColor5, recipients);
        }
    }
}