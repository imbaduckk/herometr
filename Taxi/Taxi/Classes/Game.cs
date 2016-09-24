using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Taxi
{
    class Game : IDrawable, IUpdatable
    {
        const int TICKS_PER_SECOND = 30;
        const int SKIP_TICKS = 1000 / TICKS_PER_SECOND;
        const int MAX_FRAMESKIP = 10;

        private GameSettings settings;
        public GameSettings Settings { get { return settings; } }

        private Graphics formGraphics;
        private Graphics graphics;
        public Graphics Graphics { get { return graphics; } }

        private Bitmap backBuffer;

        public List<GameObject> gameObjects = new List<GameObject>();
        
        //bool для управления запуском игры, тру = игра идет, фолс = нет
        public bool GameIsRunning { get; set; }
        //класс для подсчета времени(тиков)
        private Stopwatch watch = new Stopwatch();
        //форма игры
        private Form form;

        public Game(Form form, GameSettings settings)
        {
            this.settings = settings;
            this.form = form;
            formGraphics = form.CreateGraphics();
            backBuffer = new Bitmap(settings.ScreenWidth, settings.ScreenHeight);
            graphics = System.Drawing.Graphics.FromImage(backBuffer);
        }
        //внутри алгоритм по которому игра будет обновлять состояние постоянно и потом отрисовывать с фпс 30
        public void StartGame()
        {
            watch.Start();
            long next_game_tick = watch.ElapsedTicks;
            int loops;

            bool game_is_running = true;
            while (game_is_running)
            {

                loops = 0;
                while (watch.ElapsedTicks > next_game_tick && loops < MAX_FRAMESKIP)
                {
                    Update();
                    //рисуем на битмап
                    Draw();
                    next_game_tick += SKIP_TICKS;
                    loops++;
                }
                //рисуем на форму из битмапа чтобы не моргал экран
                formGraphics.DrawImageUnscaled(backBuffer, settings.ScreenPoint);
                
            }
            watch.Stop();
        }

        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
        //обновление состояния игры
        public void Update()
        {
            foreach (var obj in gameObjects)
            {
                if (obj is IUpdatable)
                    ((IUpdatable)obj).Update();
            }
        }

        public void Draw()
        {
            foreach (var obj in gameObjects)
            {
                if (obj is IDrawable)
                    ((IDrawable)obj).Draw();
            }
           // formGraphics.DrawImageUnscaled(backBuffer, settings.ScreenPoint);
                      
        }
    }
}
