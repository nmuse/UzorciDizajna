using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethodTablice
{
    class IspisStrijelaca : IProductIspis
    {
        public void ispisiTablicu(string argumenti)
        {
            string[] ispisTablice = argumenti.Split(' ');
            int brojKola = Int32.MaxValue;
            int result;

            if (ispisTablice.Length != 1)
            {
                bool uspjehKonverzije = Int32.TryParse(ispisTablice[1],out result);
                brojKola = result;

                if (!uspjehKonverzije)
                {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return;
                }
                if (ispisTablice.Length > 2)
                {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return;
                }
            }

            Prvenstvo p1 = Prvenstvo.GetInstance();

            List<TablicaStrijelaca> listaTabliceStrijelaca = new List<TablicaStrijelaca>();

            int brojGolova = 0;

            foreach (Igrac igrac in p1.ListaIgraca)
            {
                foreach (Dogadaj dogadaj in p1.ListaDogadaja)
                {
                    foreach (Utakmica utakmica in p1.ListaUtakmica)
                    {
                        brojGolova = provjeriBrojUtakmiceIDogadaja(brojKola, brojGolova, igrac, dogadaj, utakmica);
                    }
                }
                if (brojGolova != 0)
                {
                    TablicaStrijelaca strijelac = new TablicaStrijelaca(igrac, brojGolova, igrac.Klub);
                    listaTabliceStrijelaca.Add(strijelac);
                    brojGolova = 0;
                }
            }
            List<TablicaStrijelaca> listaTabliceStrijelacaSortirano = listaTabliceStrijelaca.OrderByDescending(x => x.BrojGolova).ToList();
            Console.WriteLine("Tablica strijelaca");
            Console.WriteLine("{0,-30} {1,-15} {2,-20}", "Igrač", "|Broj golova", "|Klub");
            foreach (TablicaStrijelaca strijelac in listaTabliceStrijelacaSortirano)
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("{0,-30} {1,-15} {2,-20}", strijelac.Igrac.ImePrezime, "|" + strijelac.BrojGolova, "|" + strijelac.Klub.Naziv);
            }


        }

        private static int provjeriBrojUtakmiceIDogadaja(int brojKola, int brojGolova, Igrac igrac, Dogadaj dogadaj, Utakmica utakmica)
        {
            if (dogadaj.Broj == utakmica.Broj)
            {
                brojGolova = provjeriBrojKola(brojKola, brojGolova, igrac, dogadaj, utakmica);
            }

            return brojGolova;
        }

        private static int provjeriBrojKola(int brojKola, int brojGolova, Igrac igrac, Dogadaj dogadaj, Utakmica utakmica)
        {
            if (utakmica.Kolo <= brojKola)
            {
                brojGolova = provjeriIgracaIDogadaj(brojGolova, igrac, dogadaj);
            }

            return brojGolova;
        }

        private static int provjeriIgracaIDogadaj(int brojGolova, Igrac igrac, Dogadaj dogadaj)
        {
            if (igrac == dogadaj.Igrac)
            {
                brojGolova = provjeriVrstuDogadajaZaGol(brojGolova, dogadaj);
            }

            return brojGolova;
        }

        private static int provjeriVrstuDogadajaZaGol(int brojGolova, Dogadaj dogadaj)
        {
            if (dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2)
            {
                brojGolova++;
            }

            return brojGolova;
        }
    }
}
