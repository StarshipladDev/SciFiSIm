using SciFiSim.Assets;
using SciFiSim.ControlFactory;
using SciFiSim.Logic;

namespace SciFiSim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            TextBox textbox = (TextBox)EntityControl.GetEntityControl();
            textbox.Location = new Point(this.Location.X + 50, this.Location.Y + 50);
            string htmlText = "<html><head> <meta http-equiv=\"x-ua-compatible\" content=\"IE=11\"> <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"> <title>SVG sample</title> <style type=\"text/css\"> </style>\r\n</head>"+
                "<body><div>test!</div><br><svg width='100' height='100' x='0' y='0'>" + SVGs.smileySvg + "</svg></body></html>";
            WebBrowser webBrowser = (WebBrowser)HTMLBox.GetHTMLBox(htmlText);
            webBrowser.Location = new Point(this.Location.X + 150, this.Location.Y + 150);
            webBrowser.Size = new Size(400, 300);
            textbox.Text = webBrowser.DocumentText;
            Controls.Add(textbox);
            Controls.Add(webBrowser);
            InitializeComponent();
            webBrowser.Refresh();

        }
    }
}