using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlightControll
{
    public partial class Form1 : Form
    {
        List<Plane> planes = new List<Plane>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            pictureBox1.Image = new Bitmap("C:\\Documents and Settings\\Administrator\\My Documents\\FlightControll\\bg.bmp");
            //pictureBox1.Size = this.Size;
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            planes.Add(new Plane(pictureBox1.Width, pictureBox1.Height));

            Timer timer = new Timer();
            timer.Tick += new EventHandler(Tick);
            timer.Interval = 100;
            timer.Start();
        }

        void Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int idx = 0; idx < planes.Count; idx++)
            {
                planes[idx].Draw(g);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }


    }
}
