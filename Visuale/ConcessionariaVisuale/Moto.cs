using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria
{
    internal class Moto : Veicolo
    {
        int numeroTempi;
        bool portaCasco;
        public Moto(string marca_, string modello_, int numeroT, bool PortaC)
        {
            numeroTempi = numeroT;
            portaCasco = PortaC;
            marca = marca_;
            modello = modello_;
            costoBase = 25;
            costoKm = 0.2;
        }
        public override string Marca
        {
            get { return marca; }
        }
        public override string Modello
        {
            get { return modello; }
        }
        public int NumeroTempi 
        {
            get { return numeroTempi; }
        }
        public bool Portacasco 
        {
            get { return portaCasco; }
        }
        public override int CostoBase 
        {
            get { return costoBase; }
        }
        public override double CostoKm
        {
            get { return costoKm; }
        }
        public override string Write()
        {
            return string.Format($"Marca:{marca, -10} Modello:{modello, -10} Numero Tempi:{numeroTempi, -10} Portacasco:{portaCasco, -10}  Costo Base:{costoBase,-10} Costo Km: {costoKm,-10}");
        }
        public override double CostoN(int km)
        {
            return (costoKm * km) + costoBase;
        }
    }
}
