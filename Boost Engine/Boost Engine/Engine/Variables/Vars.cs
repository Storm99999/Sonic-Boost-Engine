using System;
using System.Drawing;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Boost_Engine.Engine.Variables
{
    class Vars
    {
        public static DispatcherTimer Loop = new DispatcherTimer();
        public static bool Jumping;
        public static bool GameOver;
        public static bool IsMovingLeft;
        public static bool IsMovingRight;
        public static bool IsBoosting;
        public static bool hasNotEnough;
        public static bool IsLightSpeedDashing;
        public static int Force = 20;
        public static int Speed = 15;
        public static int Rings;
        public static int Score;
        public static int Time;
        public static Random random;
        public static SoundPlayer player;
        public static Image playerImg;
        public static Image backgroundImg;
        public static Image motoBugImg;
    }
}
