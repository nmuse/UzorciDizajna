using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethod
{
    class UcitajUtakmice : IProduct
    {
        public void ucitavanjeDatoteke(string datotekaZaUcitavanje)
        {
            string path = datotekaZaUcitavanje;
            Helper helper = new Helper();
            string[] linije = System.IO.File.ReadAllLines(path);
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
                if (provjeriFormatUnosa(linija, podaci)) continue;
                if (provjeriBrojAtributa(linija, brojAtributa, podaci)) continue;
                DateTime dt = Convert.ToDateTime(podaci[4]);
                if (postojiDomaciKlub(p1, linija, podaci)) continue;
                if (postojiGostujuciKlub(p1, linija, podaci)) continue;
                if(istaEkipaDomacinIGost(linija, podaci)) continue;
                Utakmica novaUtakmica = new Utakmica(Int32.Parse(podaci[0]),
                    Int32.Parse(podaci[1]),
                    p1.ListaKlubova.Find(x => x.Kratica.Equals(podaci[2])),
                    p1.ListaKlubova.Find(x => x.Kratica.Equals(podaci[3])),
                    dt);

                p1.ListaUtakmica.Add(novaUtakmica);

            }

        }

        private static bool istaEkipaDomacinIGost(string linija, string[] podaci)
        {
            if (podaci[2] == podaci[3])
            {
                Console.WriteLine("Domaćin i gost su ista ekipa u navedenoj utakmici : " + linija);
                return true;
            }
            return false;
        }

        private static bool postojiGostujuciKlub(Prvenstvo p1, string linija, string[] podaci)
        {
            if (p1.ListaKlubova.Any(x => x.Kratica.Equals(podaci[3])) == false)
            {
                Console.WriteLine("Ne postoji gostujući klub za navedenu utakmicu : " + linija);
                return true;
            }
            return false;
        }

        private static bool postojiDomaciKlub(Prvenstvo p1, string linija, string[] podaci)
        {
            if (p1.ListaKlubova.Any(x => x.Kratica.Equals(podaci[2])) == false)
            {
                Console.WriteLine("Ne postoji domaći klub za navedenu utakmicu : " + linija);
                return true;
            }
            return false;
        }

        private static bool provjeriBrojAtributa(string linija, int brojAtributa, string[] podaci)
        {
            if (brojAtributa != 5)
            {

                Console.Write("Pogrešan broj atributa, nedostaju : ");
                if (podaci[0] == "")
                {
                    Console.Write("broj ");
                }
                if (podaci[1] == "")
                {
                    Console.Write("kolo ");
                }
                if (podaci[2] == "")
                {
                    Console.Write("domaćin ");
                }
                if (podaci[3] == "")
                {
                    Console.Write("gost ");
                }
                if (podaci[4] == "")
                {
                    Console.Write("početak ");
                }
                Console.Write(", u liniji " + linija);
                Console.WriteLine();
                return true;
            }
            return false;
        }

        private static bool provjeriFormatUnosa(string linija, string[] podaci)
        {
            if (podaci.Length != 5)
            {
                Console.WriteLine("Pogrešan unos kod utakmice, krivi format u liniji : " + linija);
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
