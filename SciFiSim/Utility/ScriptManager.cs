using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Utility
{
    public class ScriptManager
    {
        private WebBrowser webBrowser;
        private TextBox textBox;
        public ScriptManager(WebBrowser webBrowser, TextBox textBox)
        {
            this.webBrowser = webBrowser;
            this.textBox = textBox;
        }

        public void OnSvgClick(double x, double y)
        {
            MessageBox.Show($"SVG clicked at: ({x}, {y})");
            this.textBox.Text = $"SVG clicked at: ({x}, {y})";
            // Add logic here to modify the SVG based on the click coordinates
            // You can use webBrowser.Document.InvokeScript to run JavaScript
            // from C# to modify the SVG as needed
        }
    }
}
