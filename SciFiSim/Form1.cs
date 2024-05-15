using SciFiSim.Assets;
using SciFiSim.ControlFactory;
using SciFiSim.HTMLTemplates;
using SciFiSim.Logic;
using SciFiSim.Logic.Models.Entities.Root;
using SciFiSim.Logic.Models.Entities.Town;
using SciFiSim.Logic.Models.System.Logic;
using SciFiSim.Logic.OpenAI.Replies;
using SciFiSim.Renderers;
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
            WebBrowser clueBrowser = (WebBrowser)HTMLBox.GetHTMLBox("div");
            webBrowser.Location = new Point(this.Location.X + 50, this.Location.Y + 150);
            webBrowser.Size = new Size(300, 300);
            clueBrowser.Location = new Point(this.Location.X + 350, this.Location.Y + 150);
            clueBrowser.Size = new Size(300, 300);
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
                clueBrowser.Document.Write(Grid.GetGrid(replyFromOpenAI.replyText));
                clueBrowser.Refresh();
            };

            // Move SMiley Button
            Button moveSmileyButton = new Button();
            moveSmileyButton.Text = "New SMiley";
            moveSmileyButton.Size = new Size(100, 50);
            moveSmileyButton.Location = new Point(this.Location.X + 450, this.Location.Y + 100);
            moveSmileyButton.Click += (sender, e) =>
            {
                string htmlText = SVGs.GetSmiley(false);
                clueBrowser.Document.Write(htmlText);
            };

            Controls.Add(textbox);
            Controls.Add(webBrowser);
            Controls.Add(clueBrowser);
            Controls.Add(openAIText);
            Controls.Add(moveSmileyButton);
            Controls.Add(openAIButton);
            InitializeComponent();
            webBrowser.Refresh();
            clueBrowser.Refresh();



            /* Logic handling */
            RenderTownSimToSvg renderer = new RenderTownSimToSvg();
            List<Time> timeList = new List<Time>();

            // Generate times from 0:00 to 23:00
            for (int hour = 0; hour < 24; hour++)
            {
                string timeString = $"{hour}:00"; // Format the time string
                timeList.Add(new Time(timeString, Guid.NewGuid())); // Add new Time object with a unique Guid
            }
            Town town = new Town();
            string[] listOfNames = {
                "Amir Al-Farsi",
                "Leyla Hassani",
                "Tariq Al-Najjar",
                "Yasmin Shirazi",
                "Farid Mostafa",
                "Nour El-Din",
                "Sanaa Al-Rashid",
                "Malik Al-Khalil",
                "Dalia Al-Saad",
                "Samir Zahedi"
            };
            Random personCellPicker = new Random();
            List<PersonEntity> people = new List<PersonEntity>();
            foreach (string name in listOfNames)
            {
                PersonEntity newPerson = new PersonEntity(Guid.NewGuid(), name);
                people.Add(newPerson);

                newPerson.movements.listOfFutureMovements.Push(
                    town.townCells[
                        personCellPicker.Next(Town.TOWNCELLSIZE),
                        personCellPicker.Next(Town.TOWNCELLSIZE)
                   ]

                );
                newPerson.movements.listOfFutureMovements.Push(
                    town.townCells[
                        personCellPicker.Next(Town.TOWNCELLSIZE),
                        personCellPicker.Next(Town.TOWNCELLSIZE)
                   ]

                );
            }
            List<BuildingEntity> buildings = new List<BuildingEntity>();
            for (int i = 0; i < 10; i++)
            {
                buildings.Add(new BuildingEntity(Guid.NewGuid(), new SciFiSim.Logic.Models.System.Places.BuildingBehaviour(false, 0, 0)));
            }
            Simulation simulation = new Simulation(town, people, buildings);
            simulation.RunSimulation(timeList.ToList(), async (simulation) => { 
                string newHtmlText = renderer.RenderSVGFromTow(simulation,250);
                if (webBrowser.InvokeRequired)
                {
                    webBrowser.Invoke(new Action(() =>
                    {
                        if (webBrowser.Document != null)
                        {
                            webBrowser.Document.Write(newHtmlText);
                            webBrowser.Refresh();
                        }
                    }));
                }
                else
                {
                    if (webBrowser.Document != null)
                    {
                        webBrowser.Document.Write(newHtmlText);
                        webBrowser.Refresh();
                    }
                }
            });


        }
    }
}