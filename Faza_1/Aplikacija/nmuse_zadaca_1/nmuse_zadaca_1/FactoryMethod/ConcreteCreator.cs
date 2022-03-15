using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethod
{
    public class ConcreteCreator : Creator
    {
        public override IProduct odrediVrstuUcitavanja(string nazivDatoteke)
        {

            if (nazivDatoteke == "DZ1_klubovi.csv")
            {
                return new UcitajKlubove();
            }
            else if (nazivDatoteke == "DZ1_igraci.csv")
            {
                return new UcitajIgrace();
            }
            else if (nazivDatoteke == "DZ1_utakmice.csv")
            {
                return new UcitajUtakmice();
            }
            else if (nazivDatoteke == "DZ1_sastavi_utakmica.csv")
            {
                return new UcitajSastave();
            }
            else if (nazivDatoteke == "DZ1_dogadaji.csv")
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
