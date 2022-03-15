using nmuse_zadaca_1.ModeliTablice;
using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethodTablice
{
    public class IspisKlubova : IProductIspis
    {
        public void ispisiTablicu(string argumenti)
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
                    return;
                }
                if (ispisTablice.Length > 2) {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return;
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
                foreach (Utakmica utakmica in p1.ListaUtakmica)
                {
                    if (utakmica.Domacin == klub || utakmica.Gost == klub)
                    {
                        if (utakmica.Kolo <= brojKola)
                        {
                            foreach (Dogadaj dogadaj in p1.ListaDogadaja)
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
                TablicaKlubova klubZaDodati = new TablicaKlubova(klub, brojOdigranihKola, brojPobjeda, brojNerjesenih, brojPoraza, brojDanihGolova, brojPrimljenihGolova, razlikagolova, brojBodova);
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
            List<TablicaKlubova> listaTabliceKlubovaSortirana = listaTabliceKlubova.OrderByDescending(x => x.BrojBodova).ToList();

            Console.WriteLine("Tablica klubova");
            Console.WriteLine("{0,-20} {1,-20} {2,-13} {3,-16} {4,-12} {5,-18} {6,-23} {7,-15} {8,-12}", "Klub", "|Broj odigranih kola", "|Broj pobjeda", "|Broj nerješenih", "|Broj poraza", "|Broj danih golova", "|Broj primljenih golova", "|Razlika golova", "|Broj bodova");
            foreach (TablicaKlubova klub in listaTabliceKlubovaSortirana)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("{0,-20} {1,-20} {2,-13} {3,-16} {4,-12} {5,-18} {6,-23} {7,-15} {8,-12}", klub.Klub.Naziv, "|"+klub.BrojOdigranihKola, "|" + klub.BrojPobjeda, "|" + klub.BrojNerjesenih, "|" + klub.BrojPoraza, "|" + klub.BrojDanihGolova, "|" + klub.BrojPrimljenihGolova, "|" + klub.RazlikaGolova, "|" + klub.BrojBodova);
                
            }

            
        }



    }




}

