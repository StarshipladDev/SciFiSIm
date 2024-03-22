using SciFiSim.Assets;
using SciFiSim.ControlFactory;
using SciFiSim.HTMLTemplates;
using SciFiSim.Logic;
using SciFiSim.Logic.OpenAI.Replies;
using System.Net.Http;

namespace SciFiSim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Textbox
            TextBox textbox = (TextBox)EntityControl.GetEntityControl();
            textbox.Location = new Point(this.Location.X + 150, this.Location.Y + 50);
            textbox.Size = new Size(400, 50);


            //Webbrowser
            string htmlText = SVGs.GetSmiley(true);
            WebBrowser webBrowser = (WebBrowser)HTMLBox.GetHTMLBox(htmlText);
            webBrowser.Location = new Point(this.Location.X + 150, this.Location.Y + 150);
            webBrowser.Size = new Size(400, 300);
            textbox.Text = webBrowser.DocumentText;

            //OpenAI Button
            TextBox openAIText = new TextBox();
            openAIText.Multiline = true;
            openAIText.Size = new Size(200, 200);
            openAIText.Location = new Point(this.Location.X + 150, this.Location.Y + 50);
            Button openAIButton = new Button();
            openAIButton.Text = "Get Open AI Puzzle";
            openAIButton.Size = new Size(100, 50);
            openAIButton.Location = new Point(this.Location.X + 350, this.Location.Y + 100);
            openAIButton.Click += async (sender, e) =>
            {
                // Perform actions when the button is clicked
                Reply replyFromOpenAI = await SciFiSim.Logic.Test.OpenAITest.Main([]);
                openAIText.Text = replyFromOpenAI.replyText;
                webBrowser.Document.Write(Grid.GetGrid(replyFromOpenAI.replyText));
                webBrowser.Refresh();
            };

            // Move SMiley Button
            Button moveSmileyButton = new Button();
            moveSmileyButton.Text = "New SMiley";
            moveSmileyButton.Size = new Size(100, 50);
            moveSmileyButton.Location = new Point(this.Location.X + 450, this.Location.Y + 100);
            moveSmileyButton.Click += (sender, e) =>
            {
                string htmlText = SVGs.GetSmiley(false);
                webBrowser.Document.Write(htmlText);
            };

            Controls.Add(textbox);
            Controls.Add(webBrowser);
            Controls.Add(openAIText);
            Controls.Add(moveSmileyButton);
            Controls.Add(openAIButton);
            InitializeComponent();
            webBrowser.Refresh();

        }
    }
}