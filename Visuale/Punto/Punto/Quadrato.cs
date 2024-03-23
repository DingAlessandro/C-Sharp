using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto
{
    internal class Quadrato : Rettangolo
    {
        public override string ToString()
        {
            return string.Format($"Lato: {Base}, Punto: ( x: {X}, y: {Y}), Perimetro: {Perimetro()}, Area: {Area()}");
        }
        public Quadrato()
        {
            bas = 10;
            altezza = 10;
        }
        public Quadrato(int lato, int x, int y) : base( lato, lato, x, y)
        {
        }
    }
}
