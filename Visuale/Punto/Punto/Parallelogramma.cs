using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Punto
{
    internal class Parallelogramma : Rettangolo
    {
        //parallelepipedo
        int profondita;
        int lato;
        public override string ToString()
        {
            return string.Format($"Base: {Base}, Altezza: {Altezza}, Profondità: {Profondita}, Punto: ( x: {X}, y: {Y}), Perimetro: {Perimetro()}, Area: {Area()}, Volume: {Volume()}");
        }
        public Parallelogramma() : base()
        {
            profondita = 21;
        }
        public Parallelogramma(int bas, int altezza, int profondita, int x, int y) : base(bas, altezza, x, y)
        {
            Profondita = profondita;
        }
        public int Profondita 
        {
            get { return profondita; }
            set { profondita = value; }
        }
        new public int Perimetro() 
        {
            return (bas + lato) * 2;
        }
        public int Volume() 
        {
            return Area() * profondita;
        }
    }
}
