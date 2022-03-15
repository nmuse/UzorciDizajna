using nmuse_zadaca_3.FactoryMethod;
using nmuse_zadaca_3.FactoryMethodTablice;
using nmuse_zadaca_3.ModeliTablice;
using nmuse_zadaca_3.Models;
using nmuse_zadaca_3.ObserverIspisDogadaja;
using nmuse_zadaca_3.VisitorAktivnosti;
using nmuse_zadaca_3.StateSastava;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Contains("-k") || !args.Contains("-i") || (args.Length < 4))
            {
                Console.WriteLine("Nisu unesene datoteke klubova i igraca - neispravni argumenti");
                Environment.Exit(1);
            }

            Prvenstvo prvenstvo = Prvenstvo.GetInstance();

            List<String> argumenti = args.ToList();
            FacadeUcitaj ucitaj = new FacadeUcitaj();

            if (argumenti.Contains("-k"))
            {
                ucitaj.UcitajKlubove(argumenti);
                popuniListuKola();
            }
            if (argumenti.Contains("-i"))
            {
                ucitaj.UcitajIgrace(argumenti);
            }
            if (argumenti.Contains("-u"))
            {
                ucitaj.UcitajUtakmice(argumenti);
            }
            if (argumenti.Contains("-s"))
            {
                ucitaj.UcitajSastave(argumenti);
            }
            if (argumenti.Contains("-d"))
            {
                ucitaj.UcitajDogadaje(argumenti);
            }

            String datotekaZaUcitavanje = null;

            int radPrograma = 1;

            FactoryMethodTablice.CreatorIspis tabliceFactory = new ConcreteCreatorIspis();


            while (radPrograma == 1)
            {

                Console.WriteLine("\n\nOdaberite mogućnost ispisa : ");
                Console.WriteLine("T - [kolo]");
                Console.WriteLine("S - [kolo]");
                Console.WriteLine("K - [kolo]");
                Console.WriteLine("R - klub [kolo]");
                Console.WriteLine("NU - datoteka utakmica");
                Console.WriteLine("NS - datoteka sastava");
                Console.WriteLine("ND - datoteka događaja");
                Console.WriteLine("D - kolo klub1 klub2 sekunde");
                Console.WriteLine("SU - kolo klub1 klub2");
                Console.WriteLine("E - izlaz iz programa");

                string tipTablice = Console.ReadLine();
                string[] ispisTablice = tipTablice.Split(' ');
                IVisitorObradaAktivnosti visitor = new VisitorObrada(tipTablice);

                if (ispisTablice[0] == "T")
                {
                    IProductIspis ispisiTablice = tabliceFactory.odrediVrstuTablice("T");
                    ispisiTablice.accept(visitor);
                }
                else if (ispisTablice[0] == "S")
                {
                    IProductIspis ispisiTablice = tabliceFactory.odrediVrstuTablice("S");
                    ispisiTablice.accept(visitor);
                }
                else if (ispisTablice[0] == "K")
                {
                    IProductIspis ispisiTablice = tabliceFactory.odrediVrstuTablice("K");
                    ispisiTablice.accept(visitor);
                }
                else if (ispisTablice[0] == "R")
                {
                    IProductIspis ispisiTablice = tabliceFactory.odrediVrstuTablice("R");
                    ispisiTablice.accept(visitor);
                }
                else if (ispisTablice[0] == "NU")
                {
                    ucitaj.UcitajNoveUtakmice(ispisTablice);
                }
                else if (ispisTablice[0] == "NS")
                {
                    ucitaj.UcitajNoveSastave(ispisTablice);
                }
                else if (ispisTablice[0] == "ND")
                {
                    ucitaj.UcitajNoveDogadaje(ispisTablice);
                }
                else if (ispisTablice[0] == "D")
                {
                    pokreniSemafor(ispisTablice);
                }
                else if (ispisTablice[0] == "SU")
                {
                    ispisiSastave(ispisTablice);
                }
                else if (ispisTablice[0] == "GR")
                {
                    generiranjeAlgoritama(ispisTablice);
                }
                else if (ispisTablice[0] == "VR")
                {
                    promijeniVazeciRaspored(ispisTablice);
                }
                else if (ispisTablice[0] == "IG")
                {
                    ispisRasporeda();
                }
                else if (ispisTablice[0] == "IK")
                {
                    ispisRasporedaKolo(ispisTablice);
                }
                else if (ispisTablice[0] == "IR")
                {
                    ispisRasporedaKlub(ispisTablice);
                }
                else if (ispisTablice[0] == "E")
                {
                    radPrograma = 0;
                }
                else
                {
                    Console.WriteLine("Pogrešan odabir aktivnosti.");
                }
            }

            //ispisiTablice.ispisiTablicu(tipTablice);


            Console.ReadLine();
        }

        private static void ispisiSastave(string[] ispisTablice)
        {
            if (!int.TryParse(ispisTablice[1], out int kolo))
            {
                Console.WriteLine("Kolo nije dobro uneseno");
                return;
            }
            Prvenstvo p1 = Prvenstvo.GetInstance();
            List<Kolo> listaKola = p1.NogometnoPrventsvo.dajKola();
            Kolo koloObjekt = null;
            foreach (Kolo k in listaKola)
            {
                if (k.Broj == kolo)
                {
                    koloObjekt = k;
                }
            }
            if (koloObjekt == null)
            {
                Console.WriteLine("Kolo " + kolo + " ne postoji");
                return;
            }
            List<Utakmica> listaUtakmica = koloObjekt.dajListuUtakmica();
            Utakmica utakmica = null;
            foreach (Utakmica u in listaUtakmica)
            {
                if ((u.Domacin.Kratica == ispisTablice[2] && u.Gost.Kratica == ispisTablice[3]) || (u.Domacin.Kratica == ispisTablice[3]
                        && u.Gost.Kratica == ispisTablice[2]))
                {
                    utakmica = u;
                }
            }
            if (utakmica == null)
            {
                Console.WriteLine("Utakmica nije odigrana");
                return;
            }
            Klub domacin = null;
            foreach (Klub k in p1.ListaKlubova)
            {
                if (k.Kratica.Equals(utakmica.Domacin.Kratica))
                {
                    domacin = k;
                }
            }
            Klub gost = null;
            foreach (Klub k in p1.ListaKlubova)
            {
                if (k.Kratica.Equals(utakmica.Gost.Kratica))
                {
                    gost = k;
                }
            }
            List<Sastav> listaSastavaPocetak = utakmica.dajListuSastava();
            List<string> pozicije = new List<string>() { "G", "B", "DB", "CB", "LB", "V", "LV", "DV", "CV", "LDV",
                        "CDV", "DDV", "LOV", "DOV", "COV", "N", "DN", "LN", "CV", "CN"};

            listaSastavaPocetak = listaSastavaPocetak.OrderBy(x => pozicije.IndexOf(x.Pozicija)).ToList();
            Console.WriteLine("Ispis sastava utakmice - početak");
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,-40}|{1,40}", "Klub domaćin - " + domacin.Naziv, "Klub gost - " + gost.Naziv));
            Console.WriteLine("======================================================================================================");

            List<Sastav> listaSastavaDomacina = new List<Sastav>();
            List<Sastav> listaSastavaGosta = new List<Sastav>();
            foreach (Sastav s in listaSastavaPocetak)
            {
                if (s.Klub.Kratica.Equals(domacin.Kratica) && s.Stanje is StateIgra)
                {
                    listaSastavaDomacina.Add(s);
                }
                else if (s.Klub.Kratica.Equals(gost.Kratica) && s.Stanje is StateIgra)
                {
                    listaSastavaGosta.Add(s);
                }
            }

            var sastaviPocetak = listaSastavaDomacina.Zip(listaSastavaGosta, (s, i) => new { sv = s, iv = i }).ToList();
            foreach (var x in sastaviPocetak)
            {
                Console.WriteLine(String.Format("{0,-40}|{1,40}", x.sv.Igrac.ImePrezime + " (" + x.sv.Pozicija + ")",
                    x.iv.Igrac.ImePrezime + " (" + x.iv.Pozicija + ")"));
            }

            Console.WriteLine();
            Console.WriteLine();
            List<Sastav> listaSastavaKraj = utakmica.dajListuSastavaKraj();
            listaSastavaKraj = listaSastavaKraj.OrderBy(x => pozicije.IndexOf(x.Pozicija)).ToList();
            Console.WriteLine("Ispis sastava utakmice - kraj");
            Console.WriteLine();

            List<Sastav> listaSastavaDomacinaKraj = new List<Sastav>();
            List<Sastav> listaSastavaGostaKraj = new List<Sastav>();
            foreach (Sastav s in listaSastavaKraj)
            {
                if (s.Klub.Kratica.Equals(domacin.Kratica) && s.Stanje is StateIgra)
                {
                    listaSastavaDomacinaKraj.Add(s);
                }
                else if (s.Klub.Kratica.Equals(gost.Kratica) && s.Stanje is StateIgra)
                {
                    listaSastavaGostaKraj.Add(s);
                }
            }

            Console.WriteLine(String.Format("{0,-40}|{1,40}", "Klub domaćin - " + domacin.Naziv, "Klub gost - " + gost.Naziv));
            Console.WriteLine("======================================================================================================");
            var sastaviKraj = listaSastavaDomacinaKraj.Zip(listaSastavaGostaKraj, (s, i) => new { sv = s, iv = i }).ToList();
            foreach (var x in sastaviKraj)
            {
                Console.WriteLine(String.Format("{0,-40}|{1,40}", x.sv.Igrac.ImePrezime + " (" + x.sv.Pozicija + ")",
                    x.iv.Igrac.ImePrezime + " (" + x.iv.Pozicija + ")"));
            }
        }

        private static void pokreniSemafor(string[] ispisTablice)
        {
            IObserverIspis observer = new ObserverDogadaj();
            ISubjectIspis subject = new SubjectDogadaj();
            subject.addObserver(observer);
            Prvenstvo p1 = Prvenstvo.GetInstance();
            int brKolo;
            bool ispravnoKolo = int.TryParse(ispisTablice[1], out brKolo);
            if (!ispravnoKolo)
            {
                Console.WriteLine("Kolo nije dobro uneseno");
                return;
            }
            brKolo = int.Parse(ispisTablice[1]);
            int sekunde;
            bool ispravneSekunde = int.TryParse(ispisTablice[4], out sekunde);
            if (!ispravneSekunde)
            {
                Console.WriteLine("Broj sekundi nije dobro unesen");
                return;
            }
            sekunde = int.Parse(ispisTablice[4]);
            List<Kolo> listaKola = p1.NogometnoPrventsvo.ListaKola;
            Kolo kolo = listaKola.Find(x => x.Broj == brKolo);
            List<Utakmica> ListaUtakmice = kolo.dajListuUtakmica();
            Utakmica utakmica = ListaUtakmice.Find(u => (u.Domacin.Kratica == ispisTablice[2] || u.Gost.Kratica == ispisTablice[2])
            && (u.Domacin.Kratica == ispisTablice[3] || u.Gost.Kratica == ispisTablice[3]));
            if (utakmica != null)
            {
                List<Dogadaj> ListaDogadaji = utakmica.dajListuDogadaja();
                if (ListaDogadaji != null)
                {
                    TablicaDogadaja tablica = new TablicaDogadaja(brKolo, utakmica.Domacin, utakmica.Gost, sekunde, ListaDogadaji);
                    subject.setState(tablica);
                }
            }
        }

        private static int odrediBrojKola()
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            int brojKlubova = p1.ListaKlubova.Count;

            if (brojKlubova >= 10)
            {
                return (brojKlubova - 1) * 2;
            }
            else
            {
                return (brojKlubova - 1) * 4;
            }
        }

        private static void popuniListuKola()
        {
            int brojKola = odrediBrojKola();
            List<Kolo> kola = new List<Kolo>();
            for (int i = 1; i <= brojKola; i++)
            {
                kola.Add(new Kolo(i));
            }
            Prvenstvo p1 = Prvenstvo.GetInstance();
            foreach (Kolo k in kola)
            {
                p1.NogometnoPrventsvo.dodajDijete(k);
            }
        }

        private static void generiranjeAlgoritama(string[] ispisTablice)
        {
            if (int.Parse(ispisTablice[1]) == 1)
            {
                generiranjeSlucajnim();
            }
            if (int.Parse(ispisTablice[1]) == 2)
            {
                generiranjeAbecednim();
            }
            if (int.Parse(ispisTablice[1]) == 3)
            {
                generiranjePoBrojuZnakova();
            }
        }

        private static void generiranjeSlucajnim()
        {
            List<ParoviUtakmica> parovi = new List<ParoviUtakmica>();
            List<Klub> prvaPolovina = new List<Klub>();
            List<Klub> drugaPolovina = new List<Klub>();
            Prvenstvo p = Prvenstvo.GetInstance();
            List<Klub> sviKlubovi = p.ListaKlubova;
            Random random = new Random();
            bool razvrstano = false;
            int velicinaPrvePolovine = 0;
            if (sviKlubovi.Count() % 2 == 0)
            {
                velicinaPrvePolovine = sviKlubovi.Count() / 2;
            }
            else
            {
                velicinaPrvePolovine = sviKlubovi.Count() / 2 + 1;
            }

            while (!razvrstano)
            {
                int broj = random.Next(0, sviKlubovi.Count() - 1);
                if (!prvaPolovina.Contains(sviKlubovi[broj]))
                {

                    prvaPolovina.Add(sviKlubovi[broj]);
                }
                if (prvaPolovina.Count() == velicinaPrvePolovine)
                {
                    razvrstano = true;
                }
            }
            foreach (Klub klub in sviKlubovi)
            {
                if (!prvaPolovina.Contains(klub))
                {
                    drugaPolovina.Add(klub);
                }
            }
            

            if (sviKlubovi.Count() % 2 == 0 && sviKlubovi.Count() >= 10)
            {
                parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                }
                else
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                }
            }
            if (sviKlubovi.Count() % 2 != 0 && sviKlubovi.Count() >= 10)
            {
                parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                }
                else
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, true);
                }
            }
            if (sviKlubovi.Count() % 2 == 0 && sviKlubovi.Count() < 10)
            {
                parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, true);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 1, false);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 1, true);
                }
                else
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 1, true);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 1, false);
                }

            }
            if (sviKlubovi.Count() % 2 != 0 && sviKlubovi.Count() < 10)
            {
                parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 2, true);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 2, false);
                }
                else
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 2, true);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 2, false);
                }

            }

            List<Raspored> rasporedi = p.ListaRasporeda;
            Raspored noviRaspored = new Raspored();

            if (rasporedi.Count==0)
            {
                noviRaspored.broj = 1;
            }
            else
            {
                noviRaspored.broj = rasporedi.Count() + 1;
            }

            noviRaspored.kreiran = DateTime.Now;
            
            foreach (ParoviUtakmica par in parovi)
            {
                noviRaspored.dodajPar(par);
                
            }
            rasporedi.Add(noviRaspored);

        }
        private static void generiranjeAbecednim()
        {
            List<ParoviUtakmica> parovi = new List<ParoviUtakmica>();
            List<Klub> prvaPolovina = new List<Klub>();
            List<Klub> drugaPolovina = new List<Klub>();
            Prvenstvo p = Prvenstvo.GetInstance();
            List<Klub> sviKlubovi = p.ListaKlubova;
            int velicinaPrvePolovine = 0;
            sviKlubovi = sviKlubovi.OrderBy(klub => klub.Naziv).ToList();
            if (sviKlubovi.Count() % 2 == 0)
            {
                velicinaPrvePolovine = sviKlubovi.Count() / 2;
            }
            else
            {
                velicinaPrvePolovine = sviKlubovi.Count() / 2 + 1;
            }

            foreach (Klub klub in sviKlubovi)
            {
                if (prvaPolovina.Count() != velicinaPrvePolovine)
                {
                    prvaPolovina.Add(klub);
                }
                else
                {
                    drugaPolovina.Add(klub);
                }
            }
            
            if (sviKlubovi.Count() % 2 == 0 && sviKlubovi.Count() >= 10)
            {
                parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                }
                else
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                }
            }
            if (sviKlubovi.Count() % 2 != 0 && sviKlubovi.Count() >= 10)
            {
                parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                }
                else
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, true);
                }
            }
            if (sviKlubovi.Count() % 2 == 0 && sviKlubovi.Count() < 10)
            {
                parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, true);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 1, false);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 1, true);
                }
                else
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 1, true);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 1, false);
                }

            }
            if (sviKlubovi.Count() % 2 != 0 && sviKlubovi.Count() < 10)
            {
                parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 2, true);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 2, false);
                }
                else
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 2, true);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 2, false);
                }

            }
            List<Raspored> rasporedi = p.ListaRasporeda;
            Raspored noviRaspored = new Raspored();

            if (rasporedi.Count == 0)
            {
                noviRaspored.broj = 1;
            }
            else
            {
                noviRaspored.broj = rasporedi.Count() + 1;
            }

            noviRaspored.kreiran = DateTime.Now;

            foreach (ParoviUtakmica par in parovi)
            {
                noviRaspored.dodajPar(par);
                
            }
            rasporedi.Add(noviRaspored);

        }
        private static void generiranjePoBrojuZnakova()
        {
            List<ParoviUtakmica> parovi = new List<ParoviUtakmica>();
            List<Klub> prvaPolovina = new List<Klub>();
            List<Klub> drugaPolovina = new List<Klub>();
            Prvenstvo p = Prvenstvo.GetInstance();
            List<Klub> sviKlubovi = p.ListaKlubova;
            int velicinaPrvePolovine = 0;
            sviKlubovi = sviKlubovi.OrderBy(klub => klub.Naziv.Length).
                ThenByDescending(klub => klub.Trener.ImePrezime.Count(s => "AEIOU".Contains(Char.ToUpper(s)))).ToList();

            if (sviKlubovi.Count() % 2 == 0)
            {
                velicinaPrvePolovine = sviKlubovi.Count() / 2;
            }
            else
            {
                velicinaPrvePolovine = sviKlubovi.Count() / 2 + 1;
            }

            foreach (Klub klub in sviKlubovi)
            {
                if (prvaPolovina.Count() != velicinaPrvePolovine)
                {
                    prvaPolovina.Add(klub);
                }
                else
                {
                    drugaPolovina.Add(klub);
                }
            }
            
            if (sviKlubovi.Count() % 2 == 0 && sviKlubovi.Count() >= 10)
            {
                parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                }
                else
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                }
            }
            if (sviKlubovi.Count() % 2 != 0 && sviKlubovi.Count() >= 10)
            {
                parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                }
                else
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, true);
                }
            }
            if (sviKlubovi.Count() % 2 == 0 && sviKlubovi.Count() < 10)
            {
                parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, true);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 1, false);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 1, true);
                }
                else
                {
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 1, true);
                    parovi = generirajParoveParno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 1, false);
                }

            }
            if (sviKlubovi.Count() % 2 != 0 && sviKlubovi.Count() < 10)
            {
                parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                    1, true);
                if (prvaPolovina.Count() % 2 == 0)
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 2, true);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 2, false);
                }
                else
                {
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                        prvaPolovina.Count() + 1, false);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + 2, true);
                    parovi = generirajParoveNeparno(prvaPolovina, drugaPolovina, parovi,
                   sviKlubovi.Count() + prvaPolovina.Count() + 2, false);
                }

            }
            
            List<Raspored> rasporedi = p.ListaRasporeda;
            Raspored noviRaspored = new Raspored();

            if (rasporedi.Count == 0)
            {
                noviRaspored.broj = 1;
            }
            else
            {
                noviRaspored.broj = rasporedi.Count() + 1;
            }

            noviRaspored.kreiran = DateTime.Now;

            foreach (ParoviUtakmica par in parovi)
            {
                noviRaspored.dodajPar(par);
                
            }
            rasporedi.Add(noviRaspored);
        }
        public static List<ParoviUtakmica> generirajParoveParno(List<Klub> prvaPolovina
            , List<Klub> drugaPolovina, List<ParoviUtakmica> parovi, int kolo, bool pom)
        {
            int brojilo = 0;
            int j = 0;
            while (brojilo != drugaPolovina.Count())
            {
                foreach (Klub k in prvaPolovina)
                {
                    if (pom == true)
                    {
                        ParoviUtakmica par = new ParoviUtakmica(kolo, k, drugaPolovina[j]);
                        parovi.Add(par);
                    }
                    else
                    {
                        ParoviUtakmica par = new ParoviUtakmica(kolo, drugaPolovina[j], k);
                        parovi.Add(par);
                    }
                    j++;
                    if (j == drugaPolovina.Count())
                    {
                        j = 0;
                    }
                }
                j++;
                if (pom == true)
                {
                    pom = false;
                }
                else
                {
                    pom = true;
                }
                kolo++;
                brojilo++;
            }

            return parovi;
        }
        public static List<ParoviUtakmica> generirajParoveNeparno(List<Klub> prvaPolovina
            , List<Klub> drugaPolovina, List<ParoviUtakmica> parovi, int kolo, bool pom)
        {
            
            int brojilo = prvaPolovina.Count() - 1;
            int j = 0;
            while (true)
            {
                foreach (Klub k in prvaPolovina)
                {
                    if (brojilo != prvaPolovina.IndexOf(k))
                    {
                        if (pom == true)
                        {
                            ParoviUtakmica par = new ParoviUtakmica(kolo, k, drugaPolovina[j]);
                            parovi.Add(par);
                        }
                        else
                        {
                            ParoviUtakmica par = new ParoviUtakmica(kolo, drugaPolovina[j], k);
                            parovi.Add(par);
                        }
                        j++;
                        if (j == drugaPolovina.Count())
                        {
                            j = 0;
                        }
                    }
                }
                if (pom == true)
                {
                    pom = false;
                }
                else
                {
                    pom = true;
                }
                if (j != drugaPolovina.Count() - 1)
                {
                    j++;
                }
                else
                {
                    j = 0;
                }
                kolo++;
                if (brojilo == 0)
                {
                    break;
                }
                brojilo--;

            }

            return parovi;
        }
        public static void promijeniVazeciRaspored(string[] ispisTablice)
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            List<Raspored> rasporedi = p1.ListaRasporeda;
            foreach (Raspored r in rasporedi)
            {
                if (r.broj == Int32.Parse(ispisTablice[1]))
                {
                    p1.vazeciRaspored = r;
                }
            }
        }
        public static void ispisRasporeda()
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            List<Raspored> rasporedi = p1.ListaRasporeda;
            
            Console.WriteLine(String.Format("|{0,20}|{1,-20}", "Broj", "Vrijeme kreiranja"));

            foreach (Raspored r in rasporedi)
            {
                Console.WriteLine(String.Format("|{0,20}|{1,-20}", r.broj, r.kreiran));

            }
        }
        public static void ispisRasporedaKlub(string[] ispisTablice)
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            Raspored raspored = p1.vazeciRaspored;
            List<Klub> listaKlubova = p1.ListaKlubova;

            List<ParoviUtakmica> parovi = raspored.paroviUtakmica;
            Console.WriteLine(String.Format("|{0,20}|{1,-20}|{2,-20}", "Kolo", "Domacin", "Gost"));


            foreach (ParoviUtakmica p in parovi)
            {
                if (ispisTablice[1] == p.klubDomacin.Kratica || ispisTablice[1] == p.klubGost.Kratica)
                {
                    Console.WriteLine(String.Format("|{0,20}|{1,-20}|{2,-20}", p.kolo, p.klubDomacin.Naziv, p.klubGost.Naziv));
                }
            }


        }
        public static void ispisRasporedaKolo(string[] ispisTablice)
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            Raspored raspored = p1.vazeciRaspored;
            List<Klub> listaKlubova = p1.ListaKlubova;

            List<ParoviUtakmica> parovi = raspored.paroviUtakmica;

            Console.WriteLine(String.Format("|{0,20}|{1,-20}|{2,-20}", "Kolo", "Domacin", "Gost"));

            foreach (ParoviUtakmica p in parovi)
            {
                if (Int32.Parse(ispisTablice[1]) == p.kolo)
                {
                    

                    Console.WriteLine(String.Format("|{0,20}|{1,-20}|{2,-20}", p.kolo, p.klubDomacin.Naziv, p.klubGost.Naziv));

                }
            }


        }
    }
}
