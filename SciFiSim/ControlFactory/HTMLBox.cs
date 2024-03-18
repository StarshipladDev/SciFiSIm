﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SciFiSim.ControlFactory
{
    internal class HTMLBox
    {
        public static Control GetHTMLBox(string htmlContent)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.DocumentText = htmlContent;
            webBrowser.Document.OpenNew(true);
            webBrowser.DocumentText = htmlContent;
            webBrowser.Document.Write(htmlContent);
            return webBrowser;
        }
    }
}
