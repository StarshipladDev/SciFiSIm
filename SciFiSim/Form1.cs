using SciFiSim.Logic;

namespace SciFiSim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            TextBox textbox = (TextBox)Main.GetEntityControl();
            textbox.Location = new Point(this.Location.X + 50, this.Location.Y + 50);
            Controls.Add(textbox);
            InitializeComponent();

        }
    }
}