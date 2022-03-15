using nmuse_zadaca_1.ModeliTablice;
using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.FactoryMethodTablice
{
    class IspisKartona : IProductIspis
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
                if (ispisTablice.Length > 2)
                {
                    Console.WriteLine("Pogreška kod unosa mogućnosti.");
                    return;
                }
            }


            int brojZutihKartona = 0;
            int brojDrugihZutihKartona = 0;
            int brojCrvenihKartona = 0;
            int ukupanBrojKartona = 0;

            List<Igrac> imajuZute = new List<Igrac>();

            Prvenstvo p1 = Prvenstvo.GetInstance();

            List<TablicaKartona> listaTabliceKartona = new List<TablicaKartona>();

            foreach (Klub klub in p1.ListaKlubova)
            {
                foreach (Utakmica utakmica in p1.ListaUtakmica)
                {
                    if (utakmica.Kolo <= brojKola)
                    {
                        foreach (Dogadaj dogadaj in p1.ListaDogadaja)
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
                ukupanBrojKartona = brojZutihKartona+brojCrvenihKartona;
                TablicaKartona karton = new TablicaKartona(klub,brojZutihKartona,brojDrugihZutihKartona,brojCrvenihKartona,ukupanBrojKartona);
                listaTabliceKartona.Add(karton);
                brojZutihKartona = 0;
                brojDrugihZutihKartona = 0;
                brojCrvenihKartona = 0;
                ukupanBrojKartona = 0;
            }


            List<TablicaKartona> listaTabliceKartonaSortirano = listaTabliceKartona.OrderByDescending(x => x.UkupanBrojKartona).ToList();


            Console.WriteLine("Tablica kartona");
            Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-22} {4,-22}", "Klub", "|Broj žutih kartona", "|Broj 2. žutih", "|Broj crvenih kartona", "|Ukupan broj kartona");
            foreach (TablicaKartona karton in listaTabliceKartonaSortirano)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");

                Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-22} {4,-22}", karton.Klub.Naziv, "|" + karton.BrojZutihKartona, "|" + karton.BrojDrugihZutihKartona, "|" + karton.BrojCrvenihKartona, "|" + karton.UkupanBrojKartona);


            }
        }
    }
}
