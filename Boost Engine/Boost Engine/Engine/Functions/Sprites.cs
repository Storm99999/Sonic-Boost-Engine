using Boost_Engine.Engine.Variables;
using Boost_Engine.Properties;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boost_Engine.Engine.Functions
{
    class Sprites
    {
        public static void IdleSprite(PictureBox playerBox)
        {
            playerBox.Image = Resources.S_Sonic_Idle;
        }
        public static void WalkSprite(PictureBox playerBox)
        {
            playerBox.Image = Resources.S_Sonic_Walk;
        }

        public static async Task RunSpriteRight(PictureBox playerBox)
        {
            if (playerBox.Left > 0)
            {
                bool v = (string)playerBox.Tag == "Run";
                if (v)
                {
                    
                }
                else
                {
                    playerBox.Image = Image.FromFile("S_Sonic.Walk3.gif");
                    Vars.Speed = 8;
                    playerBox.Left += Vars.Speed;
                    await Task.Delay(2000);
                    Vars.Speed = 15;
                    playerBox.Left += Vars.Speed;
                    playerBox.Image = Resources.S_Sonic_Run;
                    playerBox.Tag = "Run";
                }
            }
            else
            {
                IdleSprite(playerBox);
            }
        }

        public static void RunSpriteLeft(PictureBox playerBox)
        {
            if (playerBox.Left > 0)
            {
                playerBox.Image = Resources.SM_Sonic_Run;
                playerBox.Left -= Vars.Speed;
            }
            else
            {
                IdleSpriteLeft(playerBox);
            }
        }
        public static void IdleSpriteLeft(PictureBox playerBox)
        {
            playerBox.Image = Resources.SM_Sonic_Idle;
        }

         public static async Task JumpBallSprite(PictureBox playerBox, PictureBox floor, PictureBox allFloors1)
        {
            playerBox.Top += -5;
            playerBox.Image = Resources.S_Sonic_Jump;
            await Task.Delay(1300);
            playerBox.Top -= -5;
            await Task.Delay(1400);

        }

        public static void BoostSprite(PictureBox playerBox)
        {
            playerBox.Image = Resources.S_Sonic_Run;
            Vars.Speed = 35;
            playerBox.Left += Vars.Speed;
        }

    }
}
