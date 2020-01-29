
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1 
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]


    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void GenerateQRCode (string dataString)
        {
            using (var client = new HttpClient())
            {
                String url = $"https://api.qrserver.com/v1/create-qr-code/?size=500x500&data={dataString}";
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    var inputStream = response.Content.ReadAsStreamAsync().Result;
                    QRCodeImg.Source = ImageSource.FromStream(() => inputStream);



                    //Console.WriteLine(responseString);
                    //Label1.Text = responseString;

                }
            }
        }

        public void GenerateQRCodeButton(object sender, System.EventArgs e)
        {
            GenerateQRCode("Chingus' Dingus");
        }
    }
}
