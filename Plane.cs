using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FlightControll
{
    public class Plane
    {
        private Bitmap _planeBitmap = new Bitmap("C:\\Documents and Settings\\Administrator\\My Documents\\FlightControll\\plane.png");
        private float _xSpeed, _ySpeed, _xPos, _yPos, _radius = 20, _angle;
        private List<Point> _way;
        private float _maxX, _maxY;

        public Plane(float maxX, float maxY)
        {
            this._maxX = maxX;
            this._maxY = maxY;

            PlaneInit();

        }
        private void PlaneInit()
        {
            Random rnd = new Random();

            //int option = rnd.Next(0, 1);
            int option = 0;
            switch (option)
            {
                case 0:
                    this._angle = 0f;
                    this._xPos = (float)rnd.Next(0, (int)this._maxX - _planeBitmap.Width);
                    this._yPos = this._maxY;
                    this._xSpeed = 0f;
                    this._ySpeed = rnd.Next(2, 4);
                    break;


                default:
                    break;
            }
        }

        public void Draw(Graphics g)
        {
            UpdatePos();
            g.DrawImage(_planeBitmap, _xPos, _yPos, 50, 50);
        }

        private void UpdatePos()
        {
            this._xPos += _xSpeed;
            this._yPos += _ySpeed;
        }

        public Point MiddlePoint()
        {
            Point middle = new Point((int)_xPos + (int) _planeBitmap.Width / 2,(int) _yPos + _planeBitmap.Height / 2);
            return(middle);
        }

        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

    }
}
