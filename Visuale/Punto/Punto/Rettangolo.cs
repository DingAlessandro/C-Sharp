using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto
{
    internal class Rettangolo : Figura
    {
        protected int bas;
        protected int altezza;
        public override string ToString()
        {
            return string.Format($"Base: {Base}, Altezza: {Altezza}, Punto: ( x: {X}, y: {Y}), Perimetro: {Perimetro()}, Area: {Area()}");
        }
        public Rettangolo() : base()
        {
            Base = 10;
            Altezza = 11;
        }
        public Rettangolo(int bas, int altezza, int x, int y) : base(x, y)
        {
            Base = bas;
            Altezza = altezza;
        }
        override public int Base
        {
            get { return bas; }
            set { bas = value; }
        }
        override public int Altezza
        {
            get { return altezza; }
            set { altezza = value; }
        }
        override public int Area() 
        {
            return bas * altezza;
        }
        override public int Perimetro() 
        {
            return (bas + altezza) * 2;
        }
    }
}
