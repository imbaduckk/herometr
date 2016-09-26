using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.MovingObjects
{
    class Car : GameObject, IUpdatable, IDrawable
    {
        public float Speed { get; }
        public Size Size { get; }
        public SolidBrush Brush { get; }
        private Rectangle carRectangle;
        public Rectangle CarRectangle
        {
            get
            {
                carRectangle.Location = Position;
                carRectangle.Size = Size;
                return carRectangle;
            }
        }

        private StaticObjects.Road CarRoad;

        public Car(Game game, Point pos) : base(game)
        {
            Speed = Settings.CarDefaultSpeed;
            Position = pos;
            Size = Settings.CarDefaultSize;
            Brush = Settings.CarDefaultBrush;
        }             
        //ищем ближайшую дорогу
        private void FindRoad()
        {
            float minDistance = float.MaxValue;
            StaticObjects.Road road;
            foreach(var obj in Game.gameObjects)
            {
                if (obj is StaticObjects.Road)
                {
                   // ((StaticObjects.Road)obj).
                   // тут надо по формулам чураковой найти ближайшую дорогу и доехать до нее
                   //а потом по неё двигаться, я спать
                }
            }
        }   

        public void Draw()
        {
            Graphics.FillRectangle(Brush, CarRectangle);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
