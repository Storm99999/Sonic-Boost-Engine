using Boost_Engine.Engine.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boost_Engine.Engine.UI.HUD.GoalPost
{
    public partial class GoalPostWindow : Form
    {
        public GoalPostWindow()
        {
            InitializeComponent();
            scr.Text = Vars.Score.ToString();
            rings.Text = Vars.Rings.ToString();
            time.Text = Vars.Time.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
