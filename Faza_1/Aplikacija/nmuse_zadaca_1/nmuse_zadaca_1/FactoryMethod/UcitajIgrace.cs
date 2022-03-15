using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethod
{
    class UcitajIgrace : IProduct
    {
        public void ucitavanjeDatoteke(string datotekaZaUcitavanje)
        {
            Helper helper = new Helper();
            string[] linije = System.IO.File.ReadAllLines(datotekaZaUcitavanje);
            List<String> listaMogucihPozicija = new List<string>{ "G", "B", "V", "N", "LB", "DB", "CB", "LDV", "DDV",
                "CDV", "LV", "DV", "CV", "LOV", "DOV", "COV", "LN", "DN", "CN"};
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
                if (provjeriFormatZapisa(linija, podaci)) continue;
                if (provjeriBrojAtributaIgraca(linija, brojAtributa, podaci)) continue;
                if (provjeriKlubZaIgraca(p1, linija, podaci)) continue;
                Klub klub = p1.ListaKlubova.Find(x => x.Kratica.Equals(podaci[0]));
                String imePrezime = podaci[1];
                string[] pozicije = podaci[2].Split(',');
                string[] podaciPozicije = pozicije;
                ocistiPoljePozicija(pozicije, podaciPozicije);
                List<String> listaPozicija = podaciPozicije.ToList();
                bool nePostoji = false;
                nePostoji = provjeriPostojanjePozicije(listaMogucihPozicija, linija, listaPozicija, nePostoji);
                if (nePostoji) continue;
                DateTime dt = new DateTime();
                try
                {
                    dt = Convert.ToDateTime(podaci[3]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Pogrešan datum rođenja kod igrača : " + imePrezime);
                    continue;
                }
                Igrac noviIgrac = new Igrac(klub, imePrezime, listaPozicija, dt);
                p1.ListaIgraca.Add(noviIgrac);
            }
        }

        private static bool provjeriPostojanjePozicije(List<string> listaMogucihPozicija, string linija, List<string> listaPozicija, bool nePostoji)
        {
            foreach (String pozicija in listaPozicija)
            {
                if (listaMogucihPozicija.Any(x => x.Equals(pozicija)) == false)
                {
                    nePostoji = true;
                    Console.WriteLine("Ne postoji navedena pozicija za igrača među mogućim pozicijama, u liniji : " + linija);
                    break;
                }
            }

            return nePostoji;
        }

        private static void ocistiPoljePozicija(string[] pozicije, string[] podaciPozicije)
        {
            for (int i = 0; i < pozicije.Length; i++)
            {
                podaciPozicije[i] = pozicije[i].Replace("\"", "");
                podaciPozicije[i] = pozicije[i].Trim();
            }
        }

        private static bool provjeriKlubZaIgraca(Prvenstvo p1, string linija, string[] podaci)
        {
            if (p1.ListaKlubova.Find(x => x.Kratica.Equals(podaci[0])) == null)
            {
                Console.WriteLine("Klub za navedenog igrača ne postoji : " + linija);
                return true;
            }
            return false;
        }

        private static bool provjeriBrojAtributaIgraca(string linija, int brojAtributa, string[] podaci)
        {
            if (brojAtributa != 4)
            {
                Console.Write("Pogrešan broj atributa kod igrača, nedostaju : ");
                if (podaci[0] == "")
                {
                    Console.Write(" klub");
                }
                if (podaci[1] == "")
                {
                    Console.Write(" igrač");
                }
                if (podaci[2] == "")
                {
                    Console.Write(" pozicije");
                }
                if (podaci[3] == "")
                {
                    Console.Write(" datum rođenja");
                }
                Console.Write(", u liniji " + linija);
                Console.WriteLine();
                return true;
            }
            return false;
        }

        private static bool provjeriFormatZapisa(string linija, string[] podaci)
        {
            if (podaci.Length != 4)
            {
                Console.WriteLine("Pogrešan unos kod linije, krivi format : " + linija);
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
