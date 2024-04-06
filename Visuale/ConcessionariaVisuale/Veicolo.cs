using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria
{
    abstract internal class Veicolo
    {
        protected string marca;
        protected string modello;
        protected int costoBase;
        protected double costoKm;
        public abstract string Marca { get; }
        public abstract string Modello { get; }
        public abstract int CostoBase { get; }
        public abstract double CostoKm { get; }
        public abstract double CostoN(int km);
        public abstract string Write();
    }
}
