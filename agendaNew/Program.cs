using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaNew
{
    // verifica che archivio non sia pieno e che la persona non sia gia presente (verifica codicefiscale) utilizare il menu per la selezione del sesso e dello stato civile
    class Program
    {
        const int nPersona = 3, xx = 10, yy = 0;
        enum Sesso
        {
            Maschio, Femmina,
        }
        enum StatoCivile
        {
            Celibe, Nubile, Coniugato, Divorziato, Separato
        }
        struct Persona
        {
            public string nome;
            public string cognome;
            public DateTime dataNascita;
            public Sesso sesso;
            public StatoCivile statocivile;
            public string cittadinanza;
            public string codiceFiscale;//QIUXNG05T26Z210S
            public override string ToString()
            {
                return string.Format($"{nome}\n{cognome}\n{dataNascita.ToShortDateString()}\n{sesso.ToString()}\n{statocivile.ToString()}\n{cittadinanza}\n{codiceFiscale}");
            }
        }
        static void Set(ref int x, ref int y)
        {
            y++;
            Console.SetCursorPosition(x, y);
        }
        static void Set2(ref int x, ref int y)
        {
            y = y + 2;
            Console.SetCursorPosition(x, y);
        }
        static int Menu(string[] opzioni, string titolo, int x, int y, ConsoleColor Ctitolo, ConsoleColor Copzioni, ConsoleColor Cscelta)
        {
            Console.Clear();
            int scelta;
            bool valid;
            string errore = "Attenzione la tua opzione non è valida riprova premendo un tasto qualsiasi";
            do
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = Ctitolo;
                Console.WriteLine("====={0}=====", titolo);
                Console.ForegroundColor = Copzioni;
                for (int i = 0; i < opzioni.Length; i++)
                {
                    Set2(ref x, ref y);
                    Console.WriteLine($"[{i + 1}] {opzioni[i]}");
                }
                Set2(ref x, ref y);
                Console.ForegroundColor = Ctitolo;
                Console.Write("==========");
                for (int i = 0; i < titolo.Length; i++)
                {
                    Console.Write("=");
                }
                Console.ForegroundColor = Cscelta;
                Set2(ref x, ref y);
                Console.WriteLine("Inserisci l'opzione (1-{0})", opzioni.Length);
                Set(ref x, ref y);
                if (!(valid = int.TryParse(Console.ReadLine(), out scelta)) || scelta < 1 || scelta > opzioni.Length)
                {
                    Set(ref x, ref y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errore);
                    Set(ref x, ref y);
                    Console.ReadKey(true);
                    Console.Clear();
                    y = yy;
                }
            } while (!valid || scelta < 1 || scelta > opzioni.Length);
            return scelta;
        }
        static void Inserimento(Persona[] cittadino, int indice)
        {
            int x = xx, y = yy;
            Console.Clear();
            string[] opzioniS = new string[] {Sesso.Maschio.ToString(), Sesso.Femmina.ToString()};
            string[] opzioniSC = new string[] {StatoCivile.Celibe.ToString(), StatoCivile.Coniugato.ToString(), StatoCivile.Divorziato.ToString(), StatoCivile.Nubile.ToString(), StatoCivile.Separato.ToString() };
            bool valid;
            Console.WriteLine("inserisci il cognome");
            cittadino[indice].cognome = Console.ReadLine();
            Console.WriteLine("inserisci il nome");
            cittadino[indice].nome = Console.ReadLine();
            Console.WriteLine("inserisci la data di nascita (formato xx/xx/xxxx)");
            while (!(valid = DateTime.TryParse(Console.ReadLine(), out cittadino[indice].dataNascita)))
            {
                Console.WriteLine("Valore non valido riprova");
            }
            cittadino[indice].sesso = (Sesso)(Menu(Enum.GetNames(typeof(Sesso)), "Sesso", xx, yy, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray) - 1) ;
            cittadino[indice].statocivile = (StatoCivile)(Menu(Enum.GetNames(typeof(StatoCivile)), "Stato Civile", xx, yy, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray)-1);
            Console.Clear();
            Console.WriteLine("inserisci la cittadinanza");
            cittadino[indice].cittadinanza = Console.ReadLine();
            do
            {
                if (!valid)
                {
                    Console.WriteLine("Codice fiscale erratto");
                }
                Console.WriteLine("inserisci il codice fiscale");
                cittadino[indice].cittadinanza = Console.ReadLine();
                if (indice != 0)
                {
                    for (int i = 0; i < indice + 1; i++)
                    {
                        for (int t = 0; t < indice + 1; t++)
                        {
                            if (cittadino[i].codiceFiscale == cittadino[t].codiceFiscale && t != i)
                            {
                                valid = false;
                            }
                        }
                    }
                }
            } while (!valid);
        }
        static void Visualizzazione(Persona[] persona, int indice)
        {
            for (int i = 0; i < indice; i++)
            {
                Console.WriteLine("Cittadino [{0}]:", i + 1);
                Console.WriteLine(persona[i].ToString());
            }
        }
        static void Modifica(Persona[] persona, int indice)
        {
            string[] criteri = new string[] {"Nome", "Cognome", "Cittadinanza", "Codice Fiscale", "Stato civile"};
            int opzione;
            Console.WriteLine("inserisci in quale modo vuoi cercare la persona (posizione[1]) (nome/congnome/cittadinanza/codiceFiscale)");
            while(!(int.TryParse(Console.ReadLine(), out opzione)) || opzione < 1 || opzione > 2)
            {
                Console.WriteLine("opzione non valida");
            }
            if(opzione == 1)
            {
                Console.WriteLine("List:");
                Visualizzazione(persona, indice);
                Console.WriteLine("inserisci la posizione della persona su cui vuoi effetuare la modifica");
                while (!(int.TryParse(Console.ReadLine(), out opzione)) || opzione < 0 || opzione > indice)
                {
                    Console.WriteLine("posizione non valida");
                }
            }
            else
            {

            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Persona[] cittadino = new Persona[nPersona];
            const string titolo = "Agenda Anagrafe";
            int indice = 0;
            string[] opzioniMenu = new string[] {"Inserimento", "Visualizzaizone", "Modifica", "EXIT"};
            int scelta;
            do
            {
                scelta = Menu(opzioniMenu, titolo, xx, yy, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray);
                switch (scelta)
                {
                    case 1:
                        if (indice < nPersona)
                        {
                            Console.WriteLine(opzioniMenu[0]);
                            Inserimento(cittadino, indice);
                            indice++;
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Array pieno");
                        }
                        break;
                    case 2:
                        Console.WriteLine(opzioniMenu[1]);
                        if (indice != 0)
                        {
                            Visualizzazione(cittadino, indice);
                        }
                        else
                        {
                            Console.WriteLine("non è stato ancora effetuato l'inserimento");
                        }
                        break;
                    case 3:
                        Console.WriteLine(opzioniMenu[2]);
                        if (indice != 0)
                        {

                        }
                        break;
                    case 4:
                        Console.WriteLine(opzioniMenu[3]);
                        break;
                }
                Console.WriteLine("premi un tasto qualsiasi per procedere");
                Console.ReadKey(true);
            } while (scelta != opzioniMenu.Length);
        }
    }
}
