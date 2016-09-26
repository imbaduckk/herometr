using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    class GameSettings
    {
        public Point ScreenPoint { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }

        private Rectangle screenRectangle;
        public Rectangle ScreenRectangle {
            get
            {
                if (screenRectangle.IsEmpty)
                {
                    screenRectangle.Location = ScreenPoint;
                    screenRectangle.Size= new Size(ScreenWidth, ScreenHeight);
                }
                return screenRectangle;
            }
        }

        public float RoadWidth { get; set; }
        public Color RoadColor { get; set; }
        private Pen roadPen = null;
        public Pen RoadPen
        {
            get
            {
                if (roadPen == null)
                    roadPen = new Pen(RoadColor, RoadWidth);
                return roadPen;
            }
        }

        public float CarDefaultSpeed { get; set; }
        public Size CarDefaultSize { get; set; }
        public Color CarDefaultColor { get; set; }
        private SolidBrush carDefaultBrush = null;
        public SolidBrush CarDefaultBrush
        {
            get
            {
                if (carDefaultBrush == null)
                    carDefaultBrush = new SolidBrush(CarDefaultColor);
                return carDefaultBrush;
            }
        }
    }
}

