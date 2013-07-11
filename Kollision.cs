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
        private List<Point> _pointList;
        float planeRadius =20;
        
        public Kollision()
        {
            _pointList = new List<Point>();
        }






        public bool Deteckt(List<Point> pointlist)
        {
            this._pointList = pointlist;

            for (int idx = 0; idx < _pointList.Count; idx++)
            {
                for (int ofc = _pointList.Count-1; ofc > 0; ofc--)
                {
                    if (_pointList[idx].X + planeRadius  > _pointList[ofc].X - planeRadius && _pointList[idx].X+planeRadius < _pointList[ofc].X + planeRadius
                        && _pointList[idx].Y + planeRadius > _pointList[ofc].Y -planeRadius && _pointList[idx].Y +planeRadius< _pointList[ofc].Y + planeRadius)
                    {

                        //Kollision
                        return true;
                        
                    }
                    
                }
            }






            return false;
            
        }




    }
}
