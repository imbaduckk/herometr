using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taxi
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        Game game;
        Thread gameThread;
        private void GameForm_Load(object sender, EventArgs e)
        {
            game = new Taxi.Game(this,
                new Taxi.GameSettings() { RoadColor = Color.Red, RoadWidth = 2f,
                ScreenWidth=this.Width, ScreenHeight=this.Height});
            game.AddGameObject(new StaticObjects.Road(game, new Point(10, 20), new Point(200, 100)));
            game.AddGameObject(new StaticObjects.Road(game, new Point(150, 20), new Point(10,50)));
            gameThread = new Thread(game.StartGame);
            gameThread.Start();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gameThread.Abort();
        }
    }
}
