using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto
{
    abstract internal class Figura : Punto
    {
        public Figura() : base()
        {

        }
        public Figura(int x, int y) : base(x, y)
        {

        }
        abstract public int Base
        {
            get;
            set;
        }
        abstract public int Altezza 
        {
            get;
            set;
        }
        abstract public int Area();
        abstract public int Perimetro();
    }
}
