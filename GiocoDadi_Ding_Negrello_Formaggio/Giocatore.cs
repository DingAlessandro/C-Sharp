using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDadi
{
    internal class Giocatore : Dado
    {
        string nome;
        int vincite;
        Dado dado = new Dado();
        public Giocatore(string nome) : base()
        {
            Nome = nome;
        }
        public string Nome 
        { 
            get { return nome; } 
            set { nome = value; }
        }
        public Dado Dado 
        {
            get { return dado; } 
        }
        static public bool operator >(Giocatore d1, Giocatore d2)
        {
            return d1.vincite > d2.vincite;
        }

        static public bool operator <(Giocatore d1, Giocatore d2)
        {
            return !(d1 > d2);
        }

        static public bool operator ==(Giocatore d1, Giocatore d2)
        {
            return d1.vincite == d2.vincite;
        }

        static public bool operator !=(Giocatore d1, Giocatore d2)
        {
            return !(d1 == d2);
        }
    }
}
