using Boost_Engine.Engine.UI.HUD.StartMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boost_Engine.Engine.UI
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
            this.BackColor = Options.bgColor;
            this.label1.ForeColor = Options.foreColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EngineWindow().Show();
        }
    }
}
