using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FlightControll
{
    public class Kollision
    {
        List<Point> pointList;
        float planeRadius;

        public Kollision()
        {
            pointList = new List<Point>();
        }






        public void Deteckt(float radius)
        {
            this.planeRadius = radius;

            for (int idx = 0; idx < pointList.Count; idx++)
            {
                for (int ofc = 0; ofc < pointList.Count; ofc++)
                {
                    //if(pointList[idx].X + planeRadius > pointList[ofc].X - planeRadius)
                    //{

                    //    MessageBox.Show("Lukas");
                    //}
                    
                }
            }



            pointList.Clear(); // Wichtig
        }

        public void GetPlanes(Point point)
        {
            pointList.Add(point);
        }


    }
}
