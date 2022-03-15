using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.FactoryMethod
{
    public class ConcreteCreator : Creator
    {
        public override IProduct odrediVrstuUcitavanja(string nazivDatoteke)
        {

            if (nazivDatoteke == "-k")
            {
                return new UcitajKlubove();
            }
            else if (nazivDatoteke == "-i")
            {
                return new UcitajIgrace();
            }
            else if (nazivDatoteke == "-u")
            {
                return new UcitajUtakmice();
            }
            else if (nazivDatoteke == "-s")
            {
                return new UcitajSastave();
            }
            else if (nazivDatoteke == "-d")
            {
                return new UcitajDogadaje();
            }
            else
            {
                throw new ApplicationException();
            }
        }
    }
}
