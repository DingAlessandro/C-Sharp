using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GiocoDadi
{
    internal class Gara
    {
        int round;
        int roundGiocati;
        public Gara(int round, string nome1, string nome2)  //inserisce quanti round da fare
        {
            this.round = round;
            this.roundGiocati = 0;
        }
        public bool FineGara //proprietà utilizzata per determinare il fine della gara
        {
            get { return round == roundGiocati; }
        }
        public string Winner// ritorna il nome del vincitore, lo stato di parità o lo stato
                            // della partita se in corso
        {
            get { return Winner; }
        }
        public void Round()//esegue un round della partita
        {
            roundGiocati++;
            //if (roundGiocati != round)
            //{
            //    roundGiocati++;
            //}
            //else
            //{
            //    FineGara = true;
            //}
        }
        private void GameWin()// se la partita è finita determina il vincitore o la
                              // condizione di parità
        {
            if (FineGara)
            {

            }
        }
        public void ResetGame()// resetta la partita
        {
        }
    }
}
