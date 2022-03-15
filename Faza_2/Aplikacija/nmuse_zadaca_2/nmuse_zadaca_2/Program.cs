using nmuse_zadaca_2.FactoryMethod;
using nmuse_zadaca_2.FactoryMethodTablice;
using nmuse_zadaca_2.ModeliTablice;
using nmuse_zadaca_2.Models;
using nmuse_zadaca_2.ObserverIspisDogadaja;
using nmuse_zadaca_2.VisitorAktivnosti;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!args.Contains("-k") || !args.Contains("-i") || (args.Length < 4))
            {
                Console.WriteLine("Nisu unesene datoteke klubova i igraca - neispravni argumenti");
                Environment.Exit(1);
            }
            
            Prvenstvo prvenstvo = Prvenstvo.GetInstance();

            List<String> argumenti = args.ToList();
            FacadeUcitaj ucitaj = new FacadeUcitaj();

            String datotekaZaUcitavanje = null;
            foreach (string argument in argumenti) {
                switch (argument)
                {
                    case "-k":
                        ucitaj.UcitajKlubove(argumenti);
                        popuniListuKola();
                        break;
                    case "-i":
                        ucitaj.UcitajIgrace(argumenti);
                        break;
                    case "-u":
                        ucitaj.UcitajUtakmice(argumenti);
                        break;
                    case "-s":
                        ucitaj.UcitajSastave(argumenti);
                        break;
                    case "-d":
                        ucitaj.UcitajDogadaje(argumenti);
                        break;
                    default:
                        break;

                }
            }
             

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
            Kolo kolo = p1.ListaKola.Find(x => x.Broj == brKolo);
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
            for(int i=1;i<=brojKola;i++)
            {
                kola.Add(new Kolo(i));
            }
            Prvenstvo p1 = Prvenstvo.GetInstance();
            p1.ListaKola = kola;
        }
    }
}
