using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml.Linq;

namespace WelcomeRESTXMLClient
{
    public partial class WelcomeRESTXML : Form
    {
        private HttpClient client = new HttpClient();
        private XNamespace xmlXNamespace = XNamespace.Get("http://schemas.microsoft.com/2003/10/Serialization/");
        public WelcomeRESTXML()
        {
            InitializeComponent();
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            string result =
                await
                    client.GetStringAsync(
                        new Uri("http://localhost:49701/WelcomeRESTXMLService.svc/welcome/" + textBox1.Text));

            XDocument xmlResponse = XDocument.Parse(result);
            MessageBox.Show(xmlResponse.Element(xmlXNamespace + "string").Value, "Welcome");
        }
    }
}
