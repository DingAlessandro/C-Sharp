using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conversioneBinEsa
{
    internal class Program
    {
        struct Ip
        {
            public string IPdec;
            public string IPbin;
            public string IPHex;
        }
        static void Main(string[] args)
        {
            Ip indirizzo = new Ip();
            indirizzo.IPdec =  "196.168.1.0";
            long decimale = ConDec(indirizzo);
            Console.WriteLine(decimale);
            ConBin(decimale, ref indirizzo);
            ConHex(decimale, ref indirizzo);
            Console.WriteLine(indirizzo.IPHex);
            Console.WriteLine(indirizzo.IPbin);
            Console.ReadLine();

        }
        static long ConDec(Ip ip) 
        {
            string[] ipdec = ip.IPdec.Split('.');
            const int esponente = 3;
            long decimale = 0;
            for(int i = 0; i < ipdec.Length; i++)
            {
                decimale = decimale + Convert.ToInt64(Convert.ToInt64(ipdec[i]) * Math.Pow(256, esponente - i));
            }
            return decimale;
        }
        static void ConBin(long decimale, ref Ip ip)
        {
            const int esponente = 2;
            while (decimale > 0) 
            {
                ip.IPbin = (decimale % esponente) + ip.IPbin;
                decimale = decimale / esponente;
            }
        }
        static void ConHex(long decimale, ref Ip ip)
        {
            const int esponente = 16;
            while (decimale > 0)
            {
                if (decimale % esponente > 9)
                {
                    ip.IPHex = Convert.ToChar(decimale % esponente + 55) + ip.IPHex;
                }
                else
                {
                    ip.IPHex = (decimale % esponente) + ip.IPHex;
                }
                decimale = decimale / esponente;
            }
        }
    }
}
