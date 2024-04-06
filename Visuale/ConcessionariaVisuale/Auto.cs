using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Concessionaria
{
    internal class Auto : Veicolo
    {
        int cilindrata;
        int numeroVolumi;
        double kmP;
        public Auto(string marca_, string modello_, int cilindrata_, int numeroV, double kmP_)
        {
            marca = marca_;
            modello = modello_;
            cilindrata = cilindrata_;
            numeroVolumi = numeroV;
            kmP = kmP_;
            costoBase = 25;
            costoKm = 0.4;
        }
        public override string Marca
        {
            get { return marca; }
        }
        public override string Modello
        {
            get { return modello; }
        }
        public int Cilindrta
        {
            get { return cilindrata; }
        }
        public int NumeroVolumi
        { 
            get { return numeroVolumi; } 
        }
        public int KmP
        {
            get { return KmP; }
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
            return string.Format($"Marca:{marca,-10} Modello:{modello,-10} Cilindrata:{cilindrata,-10} Numero Volumi:{numeroVolumi,-10} Km Percorsi:{kmP, -10} Costo Base:{costoBase, -10} Costo Km: {costoKm, -10}");
        }
        public override double CostoN(int km)
        {
            return (costoKm * km) + costoBase;
        }
    }
}
