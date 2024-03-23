using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto
{
    internal class Punto
    {
        int[] xy;
        public Punto()
        {
            xy = new int[] { 1, 1 };
        }
        public Punto(int x, int y)
        {
            xy = new int[] { x, y };
        }
        public int[] XY
        {
            get //return per valore non per riferimento
            {
                int[] _xy = new int[] { xy[0], xy[1] };
                return _xy; 
            }
            set //assegnazione valore, non indirizzo
            {
                int[] _xy = value;
                xy[0] = _xy[0];
                xy[1] = _xy[1];
            }
        }
        public int X
        {
            get { return xy[0]; }
            set { xy[0] = value; }
        }
        public int Y
        {
            get { return xy[1]; }
            set { xy[1] = value; }
        }
    }
}
