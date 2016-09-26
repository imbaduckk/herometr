using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi.StaticObjects
{
    class Road : GameObject, IDrawable
    {
        private Point startP, endP;
        public Point startPoint { get { return startP; } }
        public Point endPoint { get { return endP; } }

        public Road(Game game, Point startP, Point endP):base(game)
        {
            if (!(Settings.ScreenRectangle.Contains(startP) && Settings.ScreenRectangle.Contains(endP)))
                throw new Exceptions.OutOfScreenException();
                
            this.startP = startP;
            this.endP = endP;
        }

        public void Draw()
        {
            Graphics.DrawLine(Settings.RoadPen, startP, endP);
        }
    }
}
