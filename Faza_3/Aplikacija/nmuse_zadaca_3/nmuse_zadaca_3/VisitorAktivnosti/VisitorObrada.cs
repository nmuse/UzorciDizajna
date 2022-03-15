using nmuse_zadaca_3.FactoryMethodTablice;
using nmuse_zadaca_3.ModeliTablice;
using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.VisitorAktivnosti
{
    class VisitorObrada : IVisitorObradaAktivnosti
    {
        string argumenti;

        public VisitorObrada(string argumenti)
        {
            this.argumenti = argumenti;
        }

        List<Utakmica> getUtakmice()
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            List<Utakmica> listaUtakmica = new List<Utakmica>();
            List<Kolo> kola = p1.NogometnoPrventsvo.ListaKola;

            foreach (Kolo k in kola)
            {
                foreach (Utakmica u in k.dajListuUtakmica())
                {
                    listaUtakmica.Add(u);
                }
            }
            return listaUtakmica;
        }

        List<Sastav> getSastavi()
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            List<Sastav> listaSastava = new List<Sastav>();

            foreach (Utakmica u in getUtakmice())
            {
                foreach (Sastav s in u.dajListuSastava())
                {
                    listaSastava.Add(s);
                }
            }
            return listaSastava;
        }

        List<Dogadaj> getDogadaji()
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            List<Dogadaj> listaDogadaja = new List<Dogadaj>();

            foreach (Utakmica u in getUtakmice())
            {
                foreach (Dogadaj d in u.dajListuDogadaja())
                {
                    listaDogadaja.Add(d);
                }
            }
            return listaDogadaja;
        }

        public void visitKartoni(IspisKartona ispisKartona)
        {
            if (getUtakmice().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka utakmica");
                return;
            }
            if (getSastavi().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka sastava");
                return;
            }
            if (getDogadaji().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka dogadaja");
                return;
            }
            List<ITablica> listaTablice = obradeniPodaciKartoni(argumenti);
            if (listaTablice.Count != 0)
            {
                ispisKartona.ispisiTablicu(listaTablice);
            }
        }

        private List<ITablica> obradeniPodaciKartoni(string argumenti)
        {
            string[] ispisTablice = argumenti.Split(' ');

            int brojKola = Int32.MaxValue;
            int result;

            if (ispisTablice.Length != 1)
            {
                bool uspjehKonverzije = Int32.TryParse(ispisTablice[1], out result);
                brojKola = result;
                if (!uspjehKonverzije)
                {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return null;
                }
                if (ispisTablice.Length > 2)
                {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return null;
                }
            }


            int brojZutihKartona = 0;
            int brojDrugihZutihKartona = 0;
            int brojCrvenihKartona = 0;
            int ukupanBrojKartona = 0;

            List<Igrac> imajuZute = new List<Igrac>();

            Prvenstvo p1 = Prvenstvo.GetInstance();

            List<TablicaKartona> listaTabliceKartona = new List<TablicaKartona>();

            List<Utakmica> listaUtakmica = getUtakmice();
            List<Dogadaj> listaDogadaja = getDogadaji();

            foreach (Klub klub in p1.ListaKlubova)
            {
                foreach (Utakmica utakmica in listaUtakmica)
                {
                    if (utakmica.Kolo <= brojKola)
                    {
                        foreach (Dogadaj dogadaj in listaDogadaja)
                        {
                            if (dogadaj.Broj == utakmica.Broj)
                            {
                                if (dogadaj.Klub == klub)
                                {
                                    if (dogadaj.Vrsta == 10)
                                    {
                                        if (imajuZute.Find(x => x == dogadaj.Igrac) != null)
                                        {
                                            brojDrugihZutihKartona++;
                                        }
                                        brojZutihKartona++;
                                        imajuZute.Add(dogadaj.Igrac);
                                    }
                                    else if (dogadaj.Vrsta == 11)
                                    {
                                        brojCrvenihKartona++;
                                    }
                                }
                            }
                        }

                    }
                    imajuZute.Clear();
                }
                ukupanBrojKartona = brojZutihKartona + brojCrvenihKartona;
                TablicaKartona karton = new TablicaKartona(klub, brojZutihKartona, brojDrugihZutihKartona, brojCrvenihKartona, ukupanBrojKartona);
                listaTabliceKartona.Add(karton);
                brojZutihKartona = 0;
                brojDrugihZutihKartona = 0;
                brojCrvenihKartona = 0;
                ukupanBrojKartona = 0;
            }

            List<TablicaKartona> listaTabliceKartonaSortirano = listaTabliceKartona.OrderByDescending(x => x.UkupanBrojKartona)
                .ThenByDescending(x => x.BrojCrvenihKartona)
                .ThenByDescending(x => x.BrojDrugihZutihKartona)
                .ToList();

            List<ITablica> konacnaTablicaKartona = new List<ITablica>();
            foreach (TablicaKartona tk in listaTabliceKartonaSortirano)
            {
                konacnaTablicaKartona.Add(tk);
            }
            return konacnaTablicaKartona;
        }

        public void visitKlubovi(IspisKlubova ispisKlubovi)
        {
            if (getUtakmice().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka utakmica");
                return;
            }
            if (getSastavi().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka sastava");
                return;
            }
            if (getDogadaji().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka dogadaja");
                return;
            }
            List<ITablica> listaTablice = obradeniPodaciKlubovi(argumenti);
            if (listaTablice.Count != 0)
            {
                ispisKlubovi.ispisiTablicu(listaTablice);
            }
        }

        private List<ITablica> obradeniPodaciKlubovi(string argumenti)
        {
            string[] ispisTablice = argumenti.Split(' ');
            int brojKola = Int32.MaxValue;
            int result;
            List<Utakmica> listaUtakmica = getUtakmice();
            List<Dogadaj> listaDogadaja = getDogadaji();

            if (ispisTablice.Length != 1)
            {
                bool uspjehKonverzije = Int32.TryParse(ispisTablice[1], out result);
                brojKola = result;
                if (!uspjehKonverzije)
                {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return null;
                }
                if (ispisTablice.Length > 2)
                {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return null;
                }
            }
            Prvenstvo p1 = Prvenstvo.GetInstance();
            List<TablicaKlubova> listaTabliceKlubova = new List<TablicaKlubova>();
            int brojDanihGolova = 0;
            int brojPrimljenihGolova = 0;
            int brojDanihGolovaNaUtakmici = 0;
            int brojPrimljenihGolovaNaUtakmici = 0;
            int brojPobjeda = 0;
            int brojPoraza = 0;
            int brojNerjesenih = 0;
            int brojOdigranihKola = 0;
            bool jeLiOdigrana = false;
            foreach (Klub klub in p1.ListaKlubova)
            {
                foreach (Utakmica utakmica in listaUtakmica)
                {
                    if (utakmica.Domacin == klub || utakmica.Gost == klub)
                    {
                        if (utakmica.Kolo <= brojKola)
                        {
                            foreach (Dogadaj dogadaj in listaDogadaja)
                            {
                                if (utakmica.Broj == dogadaj.Broj)
                                {
                                    jeLiOdigrana = true;
                                    if (dogadaj.Vrsta == 1 || dogadaj.Vrsta == 2)
                                    {
                                        if (dogadaj.Klub == klub)
                                        {
                                            brojDanihGolovaNaUtakmici++;
                                        }
                                        else
                                        {
                                            brojPrimljenihGolovaNaUtakmici++;
                                        }
                                    }
                                    if (dogadaj.Vrsta == 3)
                                    {
                                        if (dogadaj.Klub == klub)
                                        {
                                            brojPrimljenihGolovaNaUtakmici++;
                                        }
                                        else
                                        {
                                            brojDanihGolovaNaUtakmici++;
                                        }
                                    }



                                }
                            }
                        }
                    }
                    if (jeLiOdigrana)
                    {
                        if (brojDanihGolovaNaUtakmici > brojPrimljenihGolovaNaUtakmici)
                        {
                            brojPobjeda++;
                        }
                        else if (brojDanihGolovaNaUtakmici < brojPrimljenihGolovaNaUtakmici)
                        {
                            brojPoraza++;
                        }
                        else if (brojDanihGolovaNaUtakmici == brojPrimljenihGolovaNaUtakmici)
                        {
                            brojNerjesenih++;
                        }
                        brojDanihGolova += brojDanihGolovaNaUtakmici;
                        brojPrimljenihGolova += brojPrimljenihGolovaNaUtakmici;
                        brojDanihGolovaNaUtakmici = 0;
                        brojPrimljenihGolovaNaUtakmici = 0;
                        brojOdigranihKola++;
                        jeLiOdigrana = false;

                    }
                }
                int brojBodova = (brojPobjeda * 3) + (brojNerjesenih);
                int razlikagolova = brojDanihGolova - brojPrimljenihGolova;
                TablicaKlubova klubZaDodati = new TablicaKlubova(klub, brojOdigranihKola, brojPobjeda, brojNerjesenih, brojPoraza, brojDanihGolova, brojPrimljenihGolova,
                    razlikagolova, brojBodova, klub.Trener);
                listaTabliceKlubova.Add(klubZaDodati);
                brojOdigranihKola = 0;
                brojPobjeda = 0;
                brojNerjesenih = 0;
                brojPoraza = 0;
                brojDanihGolova = 0;
                brojPrimljenihGolova = 0;
                brojBodova = 0;
                razlikagolova = 0;

            }
            List<TablicaKlubova> listaTabliceKlubovaSortirana = listaTabliceKlubova.OrderByDescending(x => x.BrojBodova)
                .ThenByDescending(x => x.RazlikaGolova)
                .ThenByDescending(x => x.BrojDanihGolova)
                .ThenByDescending(x => x.BrojPobjeda)
                .ToList();
            List<ITablica> konacnaTablicaKlubova = new List<ITablica>();
            foreach (TablicaKlubova tk in listaTabliceKlubovaSortirana)
            {
                konacnaTablicaKlubova.Add(tk);
            }
            return konacnaTablicaKlubova;
        }

        public void visitRezultatiUtakmica(IspisRezultataUtakmica ispisRezultataUtakmica)
        {
            if (getUtakmice().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka utakmica");
                return;
            }
            if (getSastavi().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka sastava");
                return;
            }
            if (getDogadaji().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka dogadaja");
                return;
            }
            obradiPodatkeRezultata(argumenti);
        }

        private void obradiPodatkeRezultata(string argumenti)
        {
            Prvenstvo p1 = Prvenstvo.GetInstance();
            List<Utakmica> listaUtakmica = getUtakmice();
            List<Dogadaj> listaDogadaja = getDogadaji();
            string[] ispisTablice = argumenti.Split(' ');
            for (int i = 0; i < ispisTablice.Length; i++)
            {
                ispisTablice[i] = ispisTablice[i].Trim();
            }
            int brojKola = listaUtakmica.Max(x => x.Kolo);
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
                        if (Int32.Parse(ispisTablice[2]) > brojKola)
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

            foreach (Utakmica utakmica in listaUtakmica)
            {
                if (utakmica.Domacin == trazeniKlub || utakmica.Gost == trazeniKlub)
                {
                    if (utakmica.Kolo <= brojKola)
                    {
                        foreach (Dogadaj dogadaj in listaDogadaja)
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

        public void visitStrijelci(IspisStrijelaca ispisStrijelaca)
        {
            if (getUtakmice().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka utakmica");
                return;
            }
            if (getSastavi().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka sastava");
                return;
            }
            if (getDogadaji().Count == 0)
            {
                Console.WriteLine("Nije ucitana datoteka dogadaja");
                return;
            }
            List<ITablica> listaTablice = obradeniPodaciStrijelci(argumenti);
            if (listaTablice.Count != 0)
            {
                ispisStrijelaca.ispisiTablicu(listaTablice);
            }
        }

        private List<ITablica> obradeniPodaciStrijelci(string argumenti)
        {
            List<Utakmica> listaUtakmica = getUtakmice();
            List<Dogadaj> listaDogadaja = getDogadaji();
            string[] ispisTablice = argumenti.Split(' ');
            int brojKola = Int32.MaxValue;
            int result;

            if (ispisTablice.Length != 1)
            {
                bool uspjehKonverzije = Int32.TryParse(ispisTablice[1], out result);
                brojKola = result;

                if (!uspjehKonverzije)
                {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return null;
                }
                if (ispisTablice.Length > 2)
                {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return null;
                }
            }

            Prvenstvo p1 = Prvenstvo.GetInstance();

            List<TablicaStrijelaca> listaTabliceStrijelaca = new List<TablicaStrijelaca>();

            int brojGolova = 0;

            foreach (Klub k in p1.ListaKlubova)
            {
                List<Igrac> ListaIgraca = k.dajIgrace();

                foreach (Igrac igrac in ListaIgraca)
                {
                    foreach (Dogadaj dogadaj in listaDogadaja)
                    {
                        foreach (Utakmica utakmica in listaUtakmica)
                        {
                            brojGolova = provjeriBrojUtakmiceIDogadaja(brojKola, brojGolova, igrac, dogadaj, utakmica);
                        }
                    }
                    if (brojGolova != 0)
                    {
                        Klub klub = p1.ListaKlubova.Find(x => x.Kratica == igrac.Klub);
                        TablicaStrijelaca strijelac = new TablicaStrijelaca(igrac, brojGolova, klub);
                        listaTabliceStrijelaca.Add(strijelac);
                        brojGolova = 0;
                    }
                }
            }
            List<TablicaStrijelaca> listaTabliceStrijelacaSortirano = listaTabliceStrijelaca.OrderByDescending(x => x.BrojGolova).ToList();
            List<ITablica> konacnaTablicaStrijelaca = new List<ITablica>();
            foreach (TablicaStrijelaca ts in listaTabliceStrijelacaSortirano)
            {
                konacnaTablicaStrijelaca.Add(ts);
            }
            return konacnaTablicaStrijelaca;
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
