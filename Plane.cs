using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FlightControll
{
    public class Plane
    {
        private Bitmap _planeBitmap = new Bitmap("../../plane_picture.png");
        private Bitmap _planeOriginal = new Bitmap("../../plane_picture.png");
        private float _xSpeed, _ySpeed, _xPos, _yPos, _radius = 20, _angle;

        public float YSpeed
        {
            get { return _ySpeed; }
            set { _ySpeed = value; }
        }

        public float XSpeed
        {
            get { return _xSpeed; }
            set { _xSpeed = value; }
        }
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

            int option = rnd.Next(0, 4);
            //int option = 3;
            switch (option)
            {
                case 0://up
                    this._angle = 0f;
                    this._xPos = (float)rnd.Next(0, (int)this._maxX - _planeBitmap.Width);
                    this._yPos = this._maxY;
                    this._xSpeed = 0f;
                    this._ySpeed = rnd.Next(-2,-1);
                    break;
                case 1://right
                    this._angle = 90f;
                    this._xPos = 0 - _planeBitmap.Width;
                    this._yPos = (float)rnd.Next(0, (int)this._maxY-_planeBitmap.Height);
                    this._xSpeed = rnd.Next(1,2);
                    this._ySpeed = 0f;
                    break;
                case 2://down
                    this._angle = 180f;
                    this._xPos = (float)rnd.Next(0, (int)this._maxX - _planeBitmap.Width);
                    this._yPos = 0 - _planeBitmap.Height;
                    this._xSpeed = 0f;
                    this._ySpeed = rnd.Next(1,2);
                    break;
                case 3://left
                    this._angle = 270f;
                    this._xPos = this._maxX;
                    this._yPos = (float)rnd.Next(0, (int)this._maxY - _planeBitmap.Height);
                    this._xSpeed = rnd.Next(-2,-1);
                    this._ySpeed = 0f;
                    break;

                    


                default:
                    break;
            }
        }

        private Bitmap rotatePlane(float angle)
        {
            Bitmap returnBitmap = new Bitmap(_planeOriginal.Width, _planeOriginal.Height);
            Graphics graphics = Graphics.FromImage(returnBitmap);
            graphics.TranslateTransform((float)_planeOriginal.Width / 2, (float)_planeOriginal.Height / 2);
            graphics.RotateTransform(angle);
            graphics.TranslateTransform(-(float)_planeOriginal.Width / 2, -(float)_planeOriginal.Height / 2);
            graphics.DrawImage(_planeOriginal, new Point(0, 0));
            

            return returnBitmap;
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
            _planeBitmap = rotatePlane(this._angle);
            
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
