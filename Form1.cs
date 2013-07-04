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
        

        public Form1()
        {
            InitializeComponent();
        }

        GameWrapper gw;

        private void Form1_Load(object sender, EventArgs e)
        {
            gw = new GameWrapper(pictureBox1, this.Size);

        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            gw.Paint(e.Graphics);
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
