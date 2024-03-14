using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciFiSim;
using SciFISIm.Logic.Models.Entities.Root;
namespace SciFiSim.Logic
{
    internal static class Main
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
