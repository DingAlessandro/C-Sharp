using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDadi
{
    internal class Dado
    {
        string path;
        Random random;
        int value;
        public Dado()
        {
            path = Environment.CurrentDirectory;
            random = new Random();
        }

        public string tiraDado() 
        {
            value = random.Next(1, 7);
            path = Environment.CurrentDirectory;
            path = path + "\\" + value + ".jpg";
            return path;
        }

        static public bool operator > (Dado d1, Dado d2) 
        {
            return d1.value > d2.value;
        }

        static public bool operator <(Dado d1, Dado d2)
        {
            return !(d1 > d2);
        }

        static public bool operator ==(Dado d1, Dado d2)
        {
            return d1.value == d2.value;
        }

        static public bool operator !=(Dado d1, Dado d2)
        {
            return !(d1 == d2);
        }

    }
}
