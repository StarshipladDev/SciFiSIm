using SciFiSim.HTMLTemplates;
using SciFiSim.Utility;
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
        public static Control GetHTMLBox(string htmlContent, ScriptManager? scriptManager = null)
        {
            WebBrowser webBrowser;
            if (scriptManager != null)
            {
                webBrowser = new WebBrowser()
                {
                    Dock = DockStyle.Fill,
                    ObjectForScripting = scriptManager
                };
            }
            else
            {
                webBrowser = new WebBrowser();
            }
            
           //webBrowser.Navigate("www.facebook.com");
            webBrowser.DocumentText = htmlContent;
            webBrowser.Document.OpenNew(true);
            webBrowser.DocumentText = "";
            webBrowser.Document.Write(htmlContent);
            return webBrowser;
        }
    }
}
