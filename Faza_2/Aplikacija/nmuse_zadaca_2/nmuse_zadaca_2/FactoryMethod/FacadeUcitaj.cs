using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.FactoryMethod
{
    class FacadeUcitaj
    {
        FactoryMethod.Creator productFactory;

        public FacadeUcitaj()
        {
            productFactory = new ConcreteCreator();
        }

        public void UcitajKlubove(List<String> argumenti)
        {
            IProduct ucitajKlubove = productFactory.odrediVrstuUcitavanja("-k");
            int indeksDatoteke = argumenti.FindIndex(i => i == "-k")+1;
            string datotekaZaUcitavanje = argumenti.ElementAt(indeksDatoteke);
            ucitajKlubove.ucitavanjeDatoteke(datotekaZaUcitavanje);
        }
        public void UcitajIgrace(List<String> argumenti)
        {
            IProduct ucitajIgrace = productFactory.odrediVrstuUcitavanja("-i");
            int indeksDatoteke = argumenti.FindIndex(i => i == "-i") + 1;
            string datotekaZaUcitavanje = argumenti.ElementAt(indeksDatoteke);
            ucitajIgrace.ucitavanjeDatoteke(datotekaZaUcitavanje);
        }
        public void UcitajUtakmice(List<String> argumenti)
        {
            IProduct ucitajUtakmice = productFactory.odrediVrstuUcitavanja("-u");
            int indeksDatoteke = argumenti.FindIndex(i => i == "-u") + 1;
            string datotekaZaUcitavanje = argumenti.ElementAt(indeksDatoteke);
            ucitajUtakmice.ucitavanjeDatoteke(datotekaZaUcitavanje);
        }

        public void UcitajNoveUtakmice(string[] argumenti)
        {
            IProduct ucitajUtakmice = productFactory.odrediVrstuUcitavanja("-u");
            string datotekaZaUcitavanje = argumenti.ElementAt(1);
            ucitajUtakmice.ucitavanjeDatoteke(datotekaZaUcitavanje);
        }

        public void UcitajSastave(List<String> argumenti)
        {
            IProduct ucitajSastave = productFactory.odrediVrstuUcitavanja("-s");
            int indeksDatoteke = argumenti.FindIndex(i => i == "-s") + 1;
            string datotekaZaUcitavanje = argumenti.ElementAt(indeksDatoteke);
            ucitajSastave.ucitavanjeDatoteke(datotekaZaUcitavanje);
        }

        public void UcitajNoveSastave(string[] argumenti)
        {
            IProduct ucitajSastave = productFactory.odrediVrstuUcitavanja("-s");
            string datotekaZaUcitavanje = argumenti.ElementAt(1);
            ucitajSastave.ucitavanjeDatoteke(datotekaZaUcitavanje);
        }

        public void UcitajDogadaje(List<String> argumenti)
        {
            IProduct ucitajDogadaje = productFactory.odrediVrstuUcitavanja("-d");
            int indeksDatoteke = argumenti.FindIndex(i => i == "-d") + 1;
            string datotekaZaUcitavanje = argumenti.ElementAt(indeksDatoteke);
            ucitajDogadaje.ucitavanjeDatoteke(datotekaZaUcitavanje);
        }

        public void UcitajNoveDogadaje(string[] argumenti)
        {
            IProduct ucitajDogadaje = productFactory.odrediVrstuUcitavanja("-d");
            string datotekaZaUcitavanje = argumenti.ElementAt(1);
            ucitajDogadaje.ucitavanjeDatoteke(datotekaZaUcitavanje);
        }
    }
}
