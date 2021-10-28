using Boost_Engine.Engine.UI.HUD.UIFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boost_Engine.Engine.UI.HUD
{
    public partial class Boost : UserControl
    {
        public Boost()
        {
            InitializeComponent();
            progressBar1.Value = BoostHUD.boostVal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BoostHUD.Str != "default")
            {
                if (BoostHUD.boostVal > 0)
                {
                    BoostHUD.boostVal = BoostHUD.boostVal - 1;
                    progressBar1.Value = BoostHUD.boostVal;
                }
                else
                {

                }
                
            }
            else
            {

            }
        }
    }
}
