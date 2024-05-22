using SciFiSim.Logic.Models.Entities.Overlay.Cuff;
using SciFiSim.Logic.Models.System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SciFiSim.Utility
{
    public class SVGClickHandler
    {
        private WebBrowser webBrowser;
        private TextBox textBox;
        private Simulation simulation;
        private int SVGSize;

        public SVGClickHandler(WebBrowser webBrowser, TextBox textBox, int sVGSize, Simulation simulation)
        {
            this.webBrowser = webBrowser;
            this.textBox = textBox;
            SVGSize = sVGSize;
            this.simulation = simulation;
        }

        public void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Ensure the document is fully loaded
            if (webBrowser != null && webBrowser.Document != null)
            {
                // Attach the click event handler to the document
                webBrowser.Document.Body.MouseDown += new HtmlElementEventHandler(Document_MouseDown);
            }
        }

        private void Document_MouseDown(object sender, HtmlElementEventArgs e)
        {
            // Check if the clicked element is an SVG or a child of an SVG
            HtmlElement clickedElement = webBrowser.Document.GetElementFromPoint(e.ClientMousePosition);
            while (clickedElement != null && clickedElement.TagName != "svg")
            {
                clickedElement = clickedElement.Parent;
            }

            // If the clicked element is an SVG, handle the click
            if (clickedElement != null && clickedElement.TagName == "svg")
            {
                // Calculate the click coordinates within the SVG
                var svgRect = clickedElement.OffsetRectangle;
                var x = e.ClientMousePosition.X - svgRect.Left;
                var y = e.ClientMousePosition.Y - svgRect.Top;
                decimal xMultiplier = (decimal)x / (decimal)this.SVGSize;
                decimal yMultiplier = (decimal)y / (decimal)this.SVGSize;
                int xCoOrd = (int)(xMultiplier * simulation.simulation.town.townCells.GetLength(0));
                int yCoOrd = (int)(yMultiplier * simulation.simulation.town.townCells.GetLength(0));
                // Display the click coordinates
               // MessageBox.Show($"SVG clicked at: ({x}, {y})");
                this.textBox.Text = $"SVG clicked at: ({x}, {y})";
                this.simulation.simulation.overlays.Add(
                    new Logic.Models.Entities.Root.OverlayEntity()
                    {
                        overlayItem = new Cuff(),
                        positionx = xCoOrd,
                        positiony = yCoOrd,

                    }
                    );
                if(
                    this.simulation.simulation.terrorist.movements.currentCell.y == yCoOrd &&
                    this.simulation.simulation.terrorist.movements.currentCell.x == xCoOrd
                    )
                {
                    this.simulation.simulation.terrorist.movements.canMove = false;
                }
                else
                {
                    this.simulation.simulation.overlays.Last().overlayItem.endAnimationOnEnd = true;
                }
                // Logic to modify the SVG based on click coordinates can be added here
            }
        }
    }
}
