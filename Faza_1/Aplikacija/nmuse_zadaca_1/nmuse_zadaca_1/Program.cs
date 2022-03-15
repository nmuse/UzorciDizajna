using nmuse_zadaca_1.FactoryMethod;
using nmuse_zadaca_1.FactoryMethodTablice;
using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Prvenstvo prvenstvo = Prvenstvo.GetInstance();

            List<String> argumenti = args.ToList();

            FactoryMethod.Creator productFactory = new ConcreteCreator();

            String datotekaZaUcitavanje = argumenti.ElementAt(argumenti.IndexOf("-k") + 1);
            IProduct ucitajKlubove = productFactory.odrediVrstuUcitavanja(datotekaZaUcitavanje);
            ucitajKlubove.ucitavanjeDatoteke(datotekaZaUcitavanje);

            datotekaZaUcitavanje = argumenti.ElementAt(argumenti.IndexOf("-i") + 1);
            IProduct ucitajIgrace = productFactory.odrediVrstuUcitavanja(datotekaZaUcitavanje);
            ucitajIgrace.ucitavanjeDatoteke(datotekaZaUcitavanje);

            datotekaZaUcitavanje = argumenti.ElementAt(argumenti.IndexOf("-u") + 1);
            IProduct ucitajUtakmice = productFactory.odrediVrstuUcitavanja(datotekaZaUcitavanje);
            ucitajUtakmice.ucitavanjeDatoteke(datotekaZaUcitavanje);

            datotekaZaUcitavanje = argumenti.ElementAt(argumenti.IndexOf("-s") + 1);
            IProduct ucitajSastave = productFactory.odrediVrstuUcitavanja(datotekaZaUcitavanje);
            ucitajSastave.ucitavanjeDatoteke(datotekaZaUcitavanje);

            datotekaZaUcitavanje = argumenti.ElementAt(argumenti.IndexOf("-d") + 1);
            IProduct ucitajDogadaje = productFactory.odrediVrstuUcitavanja(datotekaZaUcitavanje);
            ucitajDogadaje.ucitavanjeDatoteke(datotekaZaUcitavanje);

            int radPrograma=1;

            FactoryMethodTablice.CreatorIspis tabliceFactory = new ConcreteCreatorIspis();

            while (radPrograma==1) {

                Console.WriteLine("\n\nOdaberite mogućnost ispisa : ");
                Console.WriteLine("T - [kolo]");
                Console.WriteLine("S - [kolo]");
                Console.WriteLine("K - [kolo]");
                Console.WriteLine("R - klub [kolo]");
                Console.WriteLine("E - izlaz iz programa");

                string tipTablice = Console.ReadLine();
                string[] ispisTablice = tipTablice.Split(' ');

                if (ispisTablice[0] == "T")
                {
                    IProductIspis ispisiTablice = tabliceFactory.odrediVrstuTablice("T");
                    ispisiTablice.ispisiTablicu(tipTablice);
                }
                else if (ispisTablice[0] == "S")
                {
                    IProductIspis ispisiTablice = tabliceFactory.odrediVrstuTablice("S");
                    ispisiTablice.ispisiTablicu(tipTablice);
                }
                else if (ispisTablice[0] == "K")
                {
                    IProductIspis ispisiTablice = tabliceFactory.odrediVrstuTablice("K");
                    ispisiTablice.ispisiTablicu(tipTablice);
                }
                else if (ispisTablice[0] == "R")
                {
                    IProductIspis ispisiTablice = tabliceFactory.odrediVrstuTablice("R");
                    ispisiTablice.ispisiTablicu(tipTablice);
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

    }
}
