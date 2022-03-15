using nmuse_zadaca_1.ModeliTablice;
using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethodTablice
{
    class IspisRezultataUtakmica : IProductIspis
    {
        public void ispisiTablicu(string argumenti)
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();

            string[] ispisTablice = argumenti.Split(' ');
            for (int i = 0; i < ispisTablice.Length; i++)
            {
                ispisTablice[i] = ispisTablice[i].Trim();
            }
            int brojKola = p1.ListaUtakmica.Max(x=>x.Kolo);
            int result;
            if (ispisTablice.Length != 2)
            {
                if (provjeraJedanArgument(ispisTablice)) return;
                else
                {
                    if (!Int32.TryParse(ispisTablice[2], out result))
                    {
                        if (provjeraPreviseArgumenata(ispisTablice)) return;
                        Console.WriteLine("Pogreška kod unosa mogućnosti, treći argument mora biti broj.");
                        return;
                    }
                    else
                    {
                        if(Int32.Parse(ispisTablice[2])> brojKola)
                        {
                            Console.WriteLine("Pogreška kod unosa broja kola, kolo nije odigrano.");
                            return;
                        }
                        Int32.TryParse(ispisTablice[2], out result);
                        brojKola = result;
                    }
                    if (provjeraPreviseArgumenata(ispisTablice)) return;
                }
            }
            if (ispisTablice.Length == 2 && Int32.TryParse(ispisTablice[1], out result))
            {
                Console.WriteLine("Pogreška kod unosa mogućnosti, drugi argument mora biti oznaka kluba.");
                return;
            }
            if (p1.ListaKlubova.Any(x => x.Kratica.Equals(ispisTablice[1])) == false)
            {
                Console.WriteLine("Pogreška kod unosa kluba u mogućnost, ne postoji taj klub.");
                return;
            }
            Klub trazeniKlub = p1.ListaKlubova.Find(x => x.Kratica.Equals(ispisTablice[1]));
            List<TablicaRezultataUtakmica> listaTablicaRezultataUtakmica =
                new List<TablicaRezultataUtakmica>();
            int kolo;
            DateTime datum = new DateTime();
            Klub domacin;
            Klub gost;
            String rezultat = "";
            int brojDanihGolova = 0;
            int brojPrimljenihGolova = 0;
            bool odigran = false;
            foreach (Utakmica utakmica in p1.ListaUtakmica)
            {
                if (utakmica.Domacin == trazeniKlub || utakmica.Gost == trazeniKlub)
                {
                    if (utakmica.Kolo <= brojKola)
                    {
                        foreach (Dogadaj dogadaj in p1.ListaDogadaja)
                        {
                            odrediDaneIPrimljeneGolove(trazeniKlub, ref brojDanihGolova, ref brojPrimljenihGolova, ref odigran, utakmica, dogadaj);
                        }
                    }
                }
                kolo = utakmica.Kolo;
                datum = utakmica.Pocetak;
                domacin = utakmica.Domacin;
                gost = utakmica.Gost;
                rezultat = odrediDomaciIliGostujuciRezultat(trazeniKlub, rezultat, brojDanihGolova, brojPrimljenihGolova, utakmica);
                if (odigran)
                {
                    TablicaRezultataUtakmica rezultatUtakmice =
                        new TablicaRezultataUtakmica(kolo, datum, domacin, gost, rezultat);
                    listaTablicaRezultataUtakmica.Add(rezultatUtakmice);
                }
                brojDanihGolova = 0;
                brojPrimljenihGolova = 0;
                odigran = false;
            }
            List<TablicaRezultataUtakmica> listaTablicaRezultataUtakmicaSortirano =
                listaTablicaRezultataUtakmica.OrderBy(x => x.Kolo).ToList();
            Console.WriteLine("Tablica rezultata utakmica");
            Console.WriteLine("{0,-20} {1,-25} {2,-22} {3,-22} {4,-20}", "Kolo",
                "|Datum i vrijeme", "|Domaćin", "|Gost", "|Rezultat");
            foreach (TablicaRezultataUtakmica rezultatUtakmice in listaTablicaRezultataUtakmicaSortirano)
            {
                if (rezultatUtakmice.Domacin == trazeniKlub || rezultatUtakmice.Gost == trazeniKlub)
                {
                    if (rezultatUtakmice.Kolo <= brojKola)
                    {
                        Console.WriteLine("---------------------------------" +
                            "---------------------------------------------------------------------");
                        Console.WriteLine("{0,-20} {1,-25} {2,-22} {3,-22} {4,-20}", rezultatUtakmice.Kolo,
                            "|" + rezultatUtakmice.Datum, "|" + rezultatUtakmice.Domacin.Naziv,
                            "|" + rezultatUtakmice.Gost.Naziv, "|" + rezultatUtakmice.Rezultat);
                    }
                }
            }
        }

        private static bool provjeraJedanArgument(string[] ispisTablice)
        {
            if (ispisTablice.Length == 1)
            {
                Console.WriteLine("Pogreška kod unosa mogućnosti, premalo argumenata.");
                return true;

            }
            return false;
        }

        private static bool provjeraPreviseArgumenata(string[] ispisTablice)
        {
            if (ispisTablice.Length > 3)
            {
                Console.WriteLine("Pogreška kod unosa mogućnosti, previše argumenata.");
                return true;
            }
            return false;
        }

        private static string odrediDomaciIliGostujuciRezultat(Klub trazeniKlub, string rezultat, int brojDanihGolova, int brojPrimljenihGolova, Utakmica utakmica)
        {
            if (trazeniKlub == utakmica.Domacin)
            {
                rezultat = brojDanihGolova + " : " + brojPrimljenihGolova;
            }
            else if (trazeniKlub == utakmica.Gost)
            {
                rezultat = brojPrimljenihGolova + " : " + brojDanihGolova;
            }

            return rezultat;
        }

        private static void odrediDaneIPrimljeneGolove(Klub trazeniKlub, ref int brojDanihGolova, ref int brojPrimljenihGolova, ref bool odigran, Utakmica utakmica, Dogadaj dogadaj)
        {
            if (dogadaj.Broj == utakmica.Broj)
            {
                odigran = true;
                if (dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2)
                {
                    if (dogadaj.Klub == trazeniKlub)
                    {
                        brojDanihGolova++;
                    }
                    else
                    {
                        brojPrimljenihGolova++;
                    }
                }
                else if (dogadaj.Vrsta == 3)
                {
                    if (dogadaj.Klub == trazeniKlub)
                    {
                        brojPrimljenihGolova++;
                    }
                    else
                    {
                        brojDanihGolova++;
                    }
                }
            }
        }
    }
}
