using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
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
        struct Anagrafica
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
        static void Inserimento(Anagrafica[] cittadino, int indice)
        {
            int x = xx, y = yy;
            Console.Clear();
            string[] opzioniS = new string[] { Sesso.Maschio.ToString(), Sesso.Femmina.ToString() };
            string[] opzioniSC = new string[] { StatoCivile.Celibe.ToString(), StatoCivile.Coniugato.ToString(), StatoCivile.Divorziato.ToString(), StatoCivile.Nubile.ToString(), StatoCivile.Separato.ToString() };
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
            cittadino[indice].sesso = (Sesso)(Menu(Enum.GetNames(typeof(Sesso)), "Sesso", xx, yy, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray) - 1);
            cittadino[indice].statocivile = (StatoCivile)(Menu(Enum.GetNames(typeof(StatoCivile)), "Stato Civile", xx, yy, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray) - 1);
            Console.Clear();
            Console.WriteLine("inserisci la cittadinanza");
            cittadino[indice].cittadinanza = Console.ReadLine();
            cittadino[indice].codiceFiscale = CalcolaCF(cittadino[indice], "H620");
            Console.WriteLine($"Codice fiscale :{cittadino[indice].codiceFiscale}");
            Console.ReadKey(true);
        }
        static string CalcolaCF(Anagrafica persona, string codiceCatastale)
        {
            // https://it.wikipedia.org/wiki/Codice_fiscale#Generazione_del_codice_fiscale
            string CF = "";
            string vocali, consonanti;
            char[] nascita = { 'A', 'B', 'C', 'D', 'E', 'H', 'L', 'M', 'P', 'R', 'S', 'T' };
            // Aggiungo il cognome
            VocaliConsonanti(persona.cognome, out vocali, out consonanti);
            CF += (consonanti + vocali + "XX").Substring(0, 3);
            // Aggiungo il nome
            VocaliConsonanti(persona.nome, out vocali, out consonanti);
            if (consonanti.Length > 3)
            {
                CF += consonanti[0];
                CF += consonanti[2];
                CF += consonanti[3];
            }
            else
            {
                CF += (consonanti + vocali + "XX").Substring(0, 3);
            }
            // Aggiungo l'anno di nascita
            CF += persona.dataNascita.Year.ToString().Substring(2);
            // Aggiungo il mese di nascita
            CF += nascita[persona.dataNascita.Month - 1];
            // Aggiungo il giorno ed il sesso
            if (persona.sesso == Sesso.Femmina)
            {
                CF += (persona.dataNascita.Day + 40);
            }
            else
            {
                CF += persona.dataNascita.Day;
            }
            // Aggiungo il luogo di nascita
            CF += codiceCatastale;
            // Calcolo il carattere di controllo
            CF = CF.ToUpper();
            CF += Checksum(CF);
            return CF;
        }
        static void VocaliConsonanti(string str, out string vocali, out string consonanti)
        {
            vocali = "";
            consonanti = "";
            foreach (char c in str.ToLower())
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    vocali += c;
                }
                else if (c != ' ')
                {
                    consonanti += c;
                }
            }
        }
        static char Checksum(string CF)
        {
            short[] dispari = { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };
            int checksum = 0;
            for (int i = 0; i < CF.Length; i++)
            {
                if (i % 2 == 0)
                {
                    checksum += dispari[ChecksumIndex(CF[i], false)];
                }
                else
                {
                    checksum += ChecksumIndex(CF[i], true);
                }
            }
            checksum %= 26;
            return (char)(checksum + 'A');
        }
        static int ChecksumIndex(char c, bool dispari)
        {
            int i;
            if (char.IsLetter(c))
            {
                i = c - 'A' + 10;
                if (dispari)
                {
                    i -= 10;
                }
            }
            else
            {
                i = c - '0';
            }
            return i;
        }
        static void Visualizzazione(Anagrafica[] persona, int indice)
        {
            for (int i = 0; i < indice; i++)
            {
                Console.WriteLine("Cittadino [{0}]:", i + 1);
                Console.WriteLine(persona[i].ToString());
            }
        }
        static void Modifica(Anagrafica[] persona, int indice)
        {
            string[] criteri = new string[] { "Nome", "Cognome", "Cittadinanza", "Codice Fiscale", "Stato civile", "Sesso" };
            int opzione;
            string cd = "";
            int posizione = 0;
            bool trovato = true;
            for (int i = 0; i < indice; i++)
            {
                Console.WriteLine(persona[i].ToString());
            }
            Console.WriteLine("inserisci il codice fiscale della persona su cui vuoi effetuare la modifica");
            do
            {
                if (cd != "")
                {
                    Console.WriteLine("codice errato o non trovato riprova");
                }
                cd = Console.ReadLine();
                for (int i = 0; i < indice && trovato; i++)
                {
                    if (cd == persona[i].codiceFiscale)
                    {
                        trovato = false;
                        posizione = i;
                    }
                }
            } while (trovato);
            Console.WriteLine("inserisci quale criterio vuoi modificare (nome/congnome/cittadinanza/codiceFiscale/sesso/statocivile)");
            opzione = Menu(criteri, "modifica", xx, yy, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray);
            Console.WriteLine("inserisci la modifica");
            switch (opzione)
            {
                case 1:
                    persona[posizione].nome = Console.ReadLine();
                    break;
                case 2:
                    persona[posizione].cognome = Console.ReadLine();
                    break;
                case 3:
                    persona[posizione].cittadinanza = Console.ReadLine();
                    break;
                case 4:
                    persona[posizione].codiceFiscale = Console.ReadLine();
                    break;
                case 5:
                    persona[posizione].statocivile = (StatoCivile)(Menu(Enum.GetNames(typeof(StatoCivile)), "Stato Civile", xx, yy, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray) - 1);
                    break;
                case 6:
                    persona[posizione].sesso = (Sesso)(Menu(Enum.GetNames(typeof(Sesso)), "Sesso", xx, yy, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray) - 1);
                    break;
            }
            persona[posizione].codiceFiscale = CalcolaCF(persona[posizione], "H620");
            Console.WriteLine($"Codice fiscale :{persona[posizione].codiceFiscale}");
            Console.ReadKey(true);
        }
        static int calcoloEta(DateTime persona)
        {
            DateTime adesso = DateTime.Now;
            int eta = adesso.Year - persona.Year - 1;
            if (adesso.Month >= persona.Month)
            {
                if (adesso.Month == persona.Month)
                {
                    if (adesso.Day > persona.Day)
                    {
                        eta++;
                    }
                }
                else
                {
                    eta++;
                }
            }
            return eta;

        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Anagrafica[] cittadino = new Anagrafica[nPersona];
            const string titolo = "Agenda Anagrafe";
            int indice = 0;
            string[] opzioniMenu = new string[] { "Inserimento", "Visualizzaizone", "Modifica", "Eta", "EXIT" };
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
                            Modifica(cittadino, indice);
                        }
                        else
                        {
                            Console.WriteLine("non è stato ancora effetuato l'inserimento");
                        }
                        break;
                    case 4:
                        if (indice != 0)
                        {
                            Console.WriteLine(opzioniMenu[3]); string cd = "";
                            int posizione = 0;
                            bool trovato = true;
                            for (int i = 0; i < indice; i++)
                            {
                                Console.WriteLine(cittadino[i].ToString());
                            }
                            Console.WriteLine("inserisci il codice fiscale della persona che cerchi l'età");
                            do
                            {
                                if (cd != "")
                                {
                                    Console.WriteLine("codice errato o non trovato riprova");
                                }
                                cd = Console.ReadLine();
                                for (int i = 0; i < indice && trovato; i++)
                                {
                                    if (cd == cittadino[i].codiceFiscale)
                                    {
                                        trovato = false;
                                        posizione = i;
                                    }
                                }
                            } while (trovato);
                            Console.WriteLine($"L'età della persona di {cittadino[posizione].nome} {cittadino[posizione].cognome} è {calcoloEta(cittadino[posizione].dataNascita)}");
                        }
                        else
                        {
                            Console.WriteLine("non è stato ancora effetuato l'inserimento");
                        }
                        break;
                    case 5:
                        Console.WriteLine(opzioniMenu[4]);
                        break;
                }
                Console.WriteLine("premi un tasto qualsiasi per procedere");
                Console.ReadKey(true);
            } while (scelta != opzioniMenu.Length);
        }
    }
}
