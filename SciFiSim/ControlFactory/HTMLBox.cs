using SciFiSim.HTMLTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SciFiSim.ControlFactory
{
    public class HTMLBox
    {
        public static Control GetHTMLBox(string htmlContent)
        {
            WebBrowser webBrowser = new WebBrowser();
           //webBrowser.Navigate("www.facebook.com");
            webBrowser.DocumentText = htmlContent;
            webBrowser.Document.OpenNew(true);
            webBrowser.DocumentText = "";
            webBrowser.Document.Write(htmlContent);
            return webBrowser;
        }
    }
}
