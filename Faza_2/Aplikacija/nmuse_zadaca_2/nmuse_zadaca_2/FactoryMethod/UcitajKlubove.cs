using nmuse_zadaca_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.FactoryMethod
{
    class UcitajKlubove : IProduct
    {
        public void ucitavanjeDatoteke(string datotekaZaUcitavanje)
        {
            Helper helper = new Helper();
            //string[] linije = System.IO.File.ReadAllLines(datotekaZaUcitavanje);
            string[] linije = { };
            try
            {
                linije = System.IO.File.ReadAllLines(datotekaZaUcitavanje);
            }
            catch
            {
                Console.WriteLine("Neispravna datoteka klubova");
                Environment.Exit(0);
            }
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
                string[] podaci = vratiPodatkeIzLinije(linija);
                if (provjeriFormatLinije(linija, podaci)) continue;
                if (provjeriBrojAtributa(linija, brojAtributa, podaci)) continue;

                Trener noviTrener = new Trener(podaci[0],podaci[2]);

                Klub noviKlub = new Klub(podaci[0], podaci[1], noviTrener);
                p1.ListaKlubova.Add(noviKlub);
            }

        }

        private static bool provjeriBrojAtributa(string linija, int brojAtributa, string[] podaci)
        {
            if (brojAtributa != 3)
            {
                Console.Write("Pogrešan broj atributa kod kluba, nedostaju : ");
                if (podaci[0] == "")
                {
                    Console.Write("klub ");
                }
                if (podaci[1] == "")
                {
                    Console.Write("naziv ");
                }
                if (podaci[2] == "")
                {
                    Console.Write("trener ");
                }
                Console.Write(", u liniji " + linija);
                Console.WriteLine();
                return true;
            }
            return false;
        }

        private static bool provjeriFormatLinije(string linija, string[] podaci)
        {
            if (podaci.Length != 3)
            {
                Console.WriteLine("Pogrešan unos kod kluba, krivi format u liniji : " + linija);
                return true;
            }
            return false;
        }

        private static string[] vratiPodatkeIzLinije(string linija)
        {
            string[] podaci = linija.Split(';');

            for (int i = 0; i < podaci.Length; i++)
            {
                podaci[i] = podaci[i].Replace("\"", "");
                podaci[i] = podaci[i].Trim();
            }

            return podaci;
        }
    }
}
