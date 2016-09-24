using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    class GameObject
    {
        public Game Game { get; }
        public GameSettings Settings { get; }
        public Graphics Graphics { get; }
        public Point Position { get; set; }

        public GameObject(Game game)
        {
            this.Game = game;
            this.Graphics = game.Graphics;
            this.Settings = game.Settings;
        }
    }
}
