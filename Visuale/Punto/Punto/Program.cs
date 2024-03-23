using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto
{
    internal class Program
    {
        static public int Ins(string tipo)
        {
            int var;
            Console.WriteLine($"inserisci il {tipo}");
            while (!int.TryParse(Console.ReadLine(), out var) || var < 1)
            {
                Console.WriteLine("valore non valido");
            }
            return var;
        }
        static void Main(string[] args)
        {
            List<Figura> figura = new List<Figura>();
            Rettangolo rettangolo;
            Quadrato quadrato;
            Parallelogramma parallelepipedo;
            rettangolo = new Rettangolo(Ins("BASE"), Ins("ALTEZZA"), Ins("PUNTO X"), Ins("PUNTO Y"));
            quadrato = new Quadrato(Ins("LATO"), Ins("PUNTO X"), Ins("PUNTO Y"));
            parallelepipedo = new Parallelogramma(Ins("BASE"), Ins("ALTEZZA"), Ins("PROFONDITÀ"), Ins("PUNTO X"), Ins("PUNTO Y"));
            figura.Add(rettangolo);
            figura.Add(quadrato);
            figura.Add(parallelepipedo);
            figura.ForEach(e => Console.WriteLine(e.ToString()));
            Console.ReadLine();
        }
    }
}
