using Boost_Engine.Engine.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boost_Engine.Engine.Functions
{
    class GameFunctions
    {
        public static void Start(PictureBox player)
        {
            Sprites.IdleSprite(player);
            Vars.Rings = 0;
            Vars.Score = 0;
            Vars.Time = 0;
            Vars.Loop.Start();
            
        }
    }
}
