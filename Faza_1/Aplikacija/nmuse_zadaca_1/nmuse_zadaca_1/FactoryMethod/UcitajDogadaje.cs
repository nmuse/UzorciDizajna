using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethod
{
    class UcitajDogadaje : IProduct
    {
        public void ucitavanjeDatoteke(string datotekaZaUcitavanje)
        {
            Helper helper = new Helper();
            string[] linije = System.IO.File.ReadAllLines(datotekaZaUcitavanje);
            OdredivanjeDogadaja odredivanjeDogadaja = new OdredivanjeDogadaja();
            DogadajBuilder dogadajBuilder = new DogadajBuilder();
            odredivanjeDogadaja.DogadajBuilder = dogadajBuilder;
            Prvenstvo p1 = Prvenstvo.GetInstance();
            bool preskocenaPrvaLinija = false;
            foreach (String linija in linije)
            {
                if (preskocenaPrvaLinija == false)
                {
                    preskocenaPrvaLinija = true;
                    continue;
                }
                int brojAtributa = helper.odrediBrojAtributa(linija);
                odredivanjeDogadaja.odrediDogadaj(brojAtributa, linija);
                Dogadaj noviDogadaj = dogadajBuilder.GetDogadaj();
                if (noviDogadaj.Vrsta == 1 || noviDogadaj.Vrsta == 2 || noviDogadaj.Vrsta == 3 || noviDogadaj.Vrsta == 10 || noviDogadaj.Vrsta == 11)
                {
                    if (postojiIgracUdogadaju(linija, noviDogadaj)) continue;
                    if (postojiKlubZaDogadaj(linija, noviDogadaj)) continue;
                }
                if (noviDogadaj.Vrsta == 20)
                {
                    if (provjeriIgracaUDogadaju(linija, noviDogadaj)) continue;
                    if (provjeriKlubUDogadaju(linija, noviDogadaj)) continue;
                    if (provjeriZamjenuIgracaUDogadaju(linija, noviDogadaj)) continue;
                    if (provjeriIgracaiZamjenu(linija, noviDogadaj)) continue;
                    if (provjeriIgracaIKlubZaZamjenu(linija, noviDogadaj)) continue;
                    if (provjeriZamjenuIKlubZaZamjenu(linija, noviDogadaj)) continue;
                }
                p1.ListaDogadaja.Add(noviDogadaj);
            }
        }



        private static bool postojiKlubZaDogadaj(string linija, Dogadaj noviDogadaj)
        {
            if (noviDogadaj.Klub == null)
            {
                Console.WriteLine("Klub za navedeni događaj nije pronađen : " + linija);
                return true;

            }
            return false;

        }

        private static bool postojiIgracUdogadaju(string linija, Dogadaj noviDogadaj)
        {
            if (noviDogadaj.Igrac == null)
            {
                Console.WriteLine("Igrač za navedeni događaj nije pronađen : " + linija);
                return true;
            }
            return false;
        }

        private static bool provjeriZamjenuIgracaUDogadaju(string linija, Dogadaj noviDogadaj)
        {
            if (noviDogadaj.Zamjena == null)
            {
                Console.WriteLine("Zamjena igrača u navedenom događaju nije pronađena : " + linija);
                return true;
            }
            return false;

        }

        private static bool provjeriZamjenuIKlubZaZamjenu(string linija, Dogadaj noviDogadaj)
        {
            if (noviDogadaj.Zamjena.Klub != noviDogadaj.Klub)
            {
                Console.WriteLine("Zamjena koja ulazi u igru u događaju zamjene ne igra za taj klub" + linija);
                return true;
            }
            return false;

        }

        private static bool provjeriIgracaIKlubZaZamjenu(string linija, Dogadaj noviDogadaj)
        {
            if (noviDogadaj.Igrac.Klub != noviDogadaj.Klub)
            {
                Console.WriteLine("Igrač iz igre u događaju zamjene ne igra za taj klub" + linija);
                return true;
            }
            return false;

        }

        private static bool provjeriIgracaiZamjenu(string linija, Dogadaj noviDogadaj)
        {
            if (noviDogadaj.Igrac.Klub != noviDogadaj.Zamjena.Klub)
            {
                Console.WriteLine("Igrač i zamjena u navedenom događaju ne igraju u istom klubu : " + linija);
                return true;
            }
            return false;

        }

        private static bool provjeriKlubUDogadaju(string linija, Dogadaj noviDogadaj)
        {
            if (noviDogadaj.Klub == null)
            {
                Console.WriteLine("Klub za navedeni događaj nije pronađen : " + linija);
                return true;
            }
            return false;

        }

        private static bool provjeriIgracaUDogadaju(string linija, Dogadaj noviDogadaj)
        {
            if (noviDogadaj.Igrac == null)
            {
                Console.WriteLine("Igrač za navedeni događaj nije pronađen : " + linija);
                return true;
            }
            return false;
        }
    }
}
