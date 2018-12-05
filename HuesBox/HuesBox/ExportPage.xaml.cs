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
		public ExportPage ()
		{
			InitializeComponent ();
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
            



            await SendEmail("HuesBox Export",  "From: " + UserName.Text + "\r\n\r\n" + "List of Colors", recipients);
        }
    }
}