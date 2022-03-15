﻿using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethod
{
    class UcitajSastave : IProduct
    {
        public void ucitavanjeDatoteke(string datotekaZaUcitavanje)
        {
            Helper helper = new Helper();
            string[] linije = System.IO.File.ReadAllLines(datotekaZaUcitavanje);
            Prvenstvo p1 = Prvenstvo.GetInstance();
            int preksociPrvuLiniju = 0;
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
                if (provjeriFormatULiniji(linija, podaci)) continue;
                if (provjeriBrojAtributa(linija, brojAtributa, podaci)) continue;
                if(provjeriBrojPozicija(linija, podaci)) continue;
                bool postojiIgrac = p1.ListaIgraca.Any(x => x.ImePrezime.Equals(podaci[3]));
                Igrac igrac = p1.ListaIgraca.Find(x => x.ImePrezime.Equals(podaci[3]) && x.Klub.Kratica.Equals(podaci[1]));
                if (postojiIgracIzSastava(linija, postojiIgrac)) continue;
                if (!provjeriIgraLiIgracZaKlub(linija, podaci, igrac)) continue;
                if (provjeraIgracPozicija(linija, podaci, igrac)) continue;
                Sastav noviSastav = new Sastav(Int32.Parse(podaci[0]),
                    p1.ListaKlubova.Find(x => x.Kratica.Equals(podaci[1])),
                    podaci[2], p1.ListaIgraca.Find(x => x.ImePrezime.Equals(podaci[3])),
                    podaci[4]);
                p1.ListaSastava.Add(noviSastav);
            }
        }

        private static bool provjeriBrojPozicija(string linija, string[] podaci)
        {
            if (podaci[4].Contains(","))
            {
                Console.WriteLine("Igrač ima više od jedne pozicije za sastav, u liniji : " + linija);
                return true;
            }
            return false;
        }

        private static bool provjeriFormatULiniji(string linija, string[] podaci)
        {
            if (podaci.Length != 5)
            {
                Console.WriteLine("Pogrešan unos kod sastava, krivi format u liniji  : " + linija);
                return true;
            }
            return false;
        }

        private static bool provjeraIgracPozicija(string linija, string[] podaci, Igrac igrac)
        {
            if (igrac.Pozicije.Any(x => x.Equals(podaci[4])) == false)
            {
                Console.WriteLine("Igrač iz sastava ne igra tu poziciju: " + linija);
                return true;
            }
            return false;
        }

        private static bool provjeriIgraLiIgracZaKlub(string linija, string[] podaci, Igrac igrac)
        {
            if (igrac.Klub.Kratica != podaci[1])
            {
                Console.WriteLine("Igrač ne igra za klub iz sastava utakmice : " + linija);
                return false;
            }
            return true;
        }

        private static bool postojiIgracIzSastava(string linija, bool postojiIgrac)
        {
            if (postojiIgrac == false)
            {
                Console.WriteLine("Igrač za navedeni sastav ne postoji : " + linija);
                return true;
            }
            return false;
        }

        private static bool provjeriBrojAtributa(string linija, int brojAtributa, string[] podaci)
        {
            if (brojAtributa != 5)
            {
                Console.Write("Pogrešan broj atributa kod sastava, nedostaju : ");
                if (podaci[0] == "")
                {
                    Console.Write("broj ");
                }
                if (podaci[1] == "")
                {
                    Console.Write("klub ");
                }
                if (podaci[2] == "")
                {
                    Console.Write("vrsta ");
                }
                if (podaci[3] == "")
                {
                    Console.Write("igrač");
                }
                if (podaci[4] == "")
                {
                    Console.Write("pozicija ");
                }
                Console.Write(", u liniji " + linija);
                Console.WriteLine();
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
