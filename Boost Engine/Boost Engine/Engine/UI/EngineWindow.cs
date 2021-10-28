using Boost_Engine.Engine.Functions;
using Boost_Engine.Engine.UI.HUD.GoalPost;
using Boost_Engine.Engine.UI.HUD.UIFunctions;
using Boost_Engine.Engine.Variables;
using Boost_Engine.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Boost_Engine
{
    public partial class EngineWindow : Form
    {
        public static Stopwatch sw;
        public EngineWindow()
        {
            InitializeComponent();
            Vars.playerImg = Resources.S_Sonic_Idle;
            PLAYER.Image = Vars.playerImg;
            this.Focus();
            Vars.Loop.Tick += Loop_Tick;
            Vars.Loop.Interval = TimeSpan.FromMilliseconds(20);
            Vars.backgroundImg = BG.Image;
            BG.Image = Vars.backgroundImg;
            rLabel.Text = Convert.ToString(Vars.Rings);
            sLabel.Text = Convert.ToString(Vars.Score);
            sw = new Stopwatch();
            sw.Start();
        }
        public static bool isOnPlatform = false;

        private void Loop_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                Vars.IsMovingRight = true;
            }
            if (e.KeyCode == Keys.A)
            {
                Vars.IsMovingLeft = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                Vars.Jumping = true;
            }
            if (e.KeyCode == Keys.F)
            {
                if (Vars.hasNotEnough == true)
                {

                }
                else
                {
                    Vars.IsBoosting = true;
                    BoostHUD.Str = "notdefault";
                }
            }
            if (e.KeyCode == Keys.Q)
            {
                Vars.IsLightSpeedDashing = true;
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            Focus();
            rLabel.Text = Vars.Rings.ToString();
            sLabel.Text = Vars.Score.ToString();
            progressBar1.Maximum = 1000;
            progressBar1.Minimum = 0;
            progressBar1.Value = BoostHUD.boostVal;
            if (Vars.IsMovingRight == false && Vars.Jumping == false && Vars.IsMovingLeft == false)
            {
                Sprites.IdleSprite(PLAYER);
            }
            if (Vars.IsMovingRight == true)
            {
                await Sprites.RunSpriteRight(PLAYER);
            }
            if (Vars.IsMovingLeft == true)
            {
                Sprites.RunSpriteLeft(PLAYER);
            }
            if (Vars.IsMovingLeft == true && Vars.IsMovingRight == false && Vars.Jumping == false)
            {
                Sprites.RunSpriteLeft(PLAYER);
            }
            if (Vars.Jumping == true)
            {
                new SoundPlayer(Environment.CurrentDirectory + "\\Assets\\jump.wav").Play();
                await Sprites.JumpBallSprite(PLAYER, FLOOR, pictureBox3);
                Vars.Jumping = false;
            }

            if (Vars.IsBoosting == true)
            {
                Sprites.BoostSprite(PLAYER);
            }
            foreach (Control x in Controls)
            {
                if (x is PictureBox)
                { 
                if ((string)x.Tag == "ring" && x.Visible == true)
                {
                    if (PLAYER.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (BoostHUD.boostVal == 1000)
                        {
                            x.Visible = false;
                            new SoundPlayer(Environment.CurrentDirectory + "\\Assets\\SFX_Ring1.wav").Play();
                        }
                        else
                        {
                            x.Visible = false;
                            Vars.Rings = Vars.Rings + 1;
                            Vars.Score = Vars.Score + 1000;
                            BoostHUD.boostVal = BoostHUD.boostVal + 30;
                            new SoundPlayer(Environment.CurrentDirectory + "\\Assets\\SFX_Ring1.wav").Play();
                        }
                    }
                }

                    if ((string)x.Tag == "platform" && x.Visible == true)
                    {
                        if (PLAYER.Bounds.IntersectsWith(x.Bounds))
                        {
                            PLAYER.Top = x.Top - PLAYER.Height;
                            isOnPlatform = true;
                            if (isOnPlatform)
                            {
                                if (PLAYER.Bounds.IntersectsWith(FreeFall.Bounds))
                                {
                                    PLAYER.Top = FLOOR.Top - PLAYER.Height;
                                }
                            }
                        }
                    }

                   
                }

                if ((string)x.Tag == "badnic" && x.Visible == true)
                {
                    if (PLAYER.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (Vars.IsBoosting == true)
                        {
                            x.Visible = false;
                            Vars.Score = Vars.Score + 2000;
                        }
                        else
                        {
                            if (Vars.Rings > 0)
                            {
                                Vars.Rings = 0;
                                PLAYER.Image = Resources.S_Sonic_Hurt;

                            }
                            else
                            {

                            }
                        }
                    }

                }

                if ((string)x.Tag == "goal")
                {
                    if (PLAYER.Bounds.IntersectsWith(pictureBox8.Bounds))
                    {
                        sw.Stop();
                        Vars.Time = (int)sw.ElapsedTicks;
                        this.Hide();
                        new GoalPostWindow().Show();
                    }
                }

                if ((string)x.Tag == "RingSpline" && x.Visible == true)
                {
                    if (PLAYER.Bounds.IntersectsWith(x.Bounds))
                    {


                        if (Vars.IsLightSpeedDashing == true)
                        {
                            PLAYER.Image = Resources.lightdashF;
                            Vars.IsLightSpeedDashing = false;
                            PLAYER.Left += 10;
                            Vars.Rings += 9;
                            x.Visible = false;
                            await Task.Delay(1800);
                            PLAYER.Image = Resources.S_Sonic_Idle;
                        }
                    }
                }
                if (BoostHUD.Str != "default")
                {
                    if (BoostHUD.boostVal > 0)
                    {
                        BoostHUD.boostVal = BoostHUD.boostVal - 1;
                        progressBar1.Value = BoostHUD.boostVal;
                    }
                    else
                    {
                        if (Vars.IsBoosting == true)
                        {
                            Vars.IsBoosting = false;
                            Vars.Speed = 15;
                            PLAYER.Left += Vars.Speed;
                            PLAYER.Image = Resources.S_Sonic_Idle;
                            BoostHUD.Str = "default";
                        }
                        Vars.hasNotEnough = true;
                    }

                }
                else
                {

                }
            }
        }

        private void EngineWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                Vars.IsMovingRight = false;
                PLAYER.Tag = "";
            }
            if (e.KeyCode == Keys.A)
            {
                Vars.IsMovingLeft = false;
            }
            if (e.KeyCode == Keys.F)
            {
                if (Vars.hasNotEnough == true)
                {
                    if (Vars.IsBoosting == true)
                    {
                        Vars.IsBoosting = false;
                        Vars.Speed = 15;
                        PLAYER.Left += Vars.Speed;
                        PLAYER.Image = Resources.S_Sonic_Idle;
                        BoostHUD.Str = "default";
                    }
                }
                else
                {
                    Vars.IsBoosting = false;
                    Vars.Speed = 15;
                    PLAYER.Left += Vars.Speed;
                    PLAYER.Image = Resources.S_Sonic_Idle;
                    BoostHUD.Str = "default";
                }
            }

            if (e.KeyCode == Keys.Q)
            {
                Vars.IsLightSpeedDashing = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void EngineWindow_Load(object sender, EventArgs e)
        {

        }

        private void PLAYER_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
