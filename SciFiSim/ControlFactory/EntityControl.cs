using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciFiSim;
using SciFiSim.Logic.Models.Entities.Root;
namespace SciFiSim.ControlFactory
{
    public static class EntityControl
    {
        public static System.Windows.Forms.Control GetEntityControl()
        {
            Random rand = new Random();
            {

                Entity entity = new Entity(rand.Next(100));
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
                textBox.Text = "Entity ID is " + entity.entityId;
                return textBox;
            }
        }

    }
}
