using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlightControll
{
    public class GameWrapper
    {
        PictureBox picturebox;
        Timer spawnPlane;
        Timer reDraw;
        Timer detectTimer;
        Kollision kollision;
        List<Point> pointlist;
        
        
        

        List<Plane> planes = new List<Plane>();

        public GameWrapper(PictureBox picturebox, Size formSize)
        {
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.ShowInTaskbar = false;
            picturebox.Image = new Bitmap("../../runway.png");
            picturebox.Size = formSize;
            picturebox.SizeMode = PictureBoxSizeMode.Zoom;

            //planes.Add(new Plane(picturebox.Width, picturebox.Height));

            this.picturebox = picturebox;
            TimerInit();
            kollision = new Kollision();
            pointlist = new List<Point>();
        }

        private void TimerInit()
        {
            reDraw = new Timer();
            reDraw.Interval = 20;
            reDraw.Tick += reDraw_Tick;
            reDraw.Start();

            spawnPlane = new Timer();
            spawnPlane.Interval = 1000 * 2;
            spawnPlane.Tick += spawnPlane_Tick;
            spawnPlane.Start();

            detectTimer = new Timer();
            detectTimer.Interval = 100;
            detectTimer.Tick += detectTimer_Tick;
            detectTimer.Start();


            
        }

        void detectTimer_Tick(object sender, EventArgs e)
        {
            pointlist.Clear();
            getPoints();
            kollision.Deteckt(pointlist);
        }

        private void getPoints()
        {
            for (int i = 0; i < planes.Count; i++)
            {
                pointlist.Add(planes[i].MiddlePoint());
            }
        }

        void spawnPlane_Tick(object sender, EventArgs e)
        {
            

            if(spawnPlane.Interval > 40000)
            {
                spawnPlane.Interval -= 100;
            }
            planes.Add(new Plane(picturebox.Width, picturebox.Height));
            
        }

        void reDraw_Tick(object sender, EventArgs e)
        {
            picturebox.Invalidate();

            

        }


        public void Paint(Graphics g) 
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int idx = 0; idx < planes.Count; idx++)
            {
                planes[idx].Draw(g);
                
            }

        }

        public void WrapperStop()
        {
            reDraw.Stop();
            spawnPlane.Stop();
            detectTimer.Stop();
        }



    }
}
