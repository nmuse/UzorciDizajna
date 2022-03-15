using nmuse_zadaca_3.ModeliTablice;
using nmuse_zadaca_3.Models;
using nmuse_zadaca_3.VisitorAktivnosti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.FactoryMethodTablice
{
    class IspisKartona : IProductIspis
    {
        public void accept(IVisitorObradaAktivnosti visitor)
        {
            visitor.visitKartoni(this);
        }

        public void ispisiTablicu(List<ITablica> listaTablica)
        {
            List<TablicaKartona> listaTabliceKartonaSortirano = new List<TablicaKartona>();
            foreach (ITablica t in listaTablica)
            {
                listaTabliceKartonaSortirano.Add(t as TablicaKartona);
            }

            Console.WriteLine("Tablica kartona");
            Console.WriteLine(String.Format("|{0,-20}|{1,20}|{2,15}|{3,22}|{4,22}", "Klub", "Broj žutih kartona", "Broj 2. žutih", "Broj crvenih kartona", "Ukupan broj kartona"));
            int sumaZuti = 0;
            int sumaDrugiZuti = 0;
            int sumaCrveni = 0;
            int sumaSvi = 0;
            foreach (TablicaKartona karton in listaTabliceKartonaSortirano)
            {
                sumaZuti += karton.BrojZutihKartona;
                sumaDrugiZuti += karton.BrojDrugihZutihKartona;
                sumaCrveni += karton.BrojCrvenihKartona;
                sumaSvi += karton.UkupanBrojKartona;
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");

                Console.WriteLine(String.Format("|{0,-20}|{1,20}|{2,15}|{3,22}|{4,22}", karton.Klub.Naziv, karton.BrojZutihKartona, karton.BrojDrugihZutihKartona, karton.BrojCrvenihKartona,
                    karton.UkupanBrojKartona));


            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

            Console.WriteLine(String.Format("|{0,-20}|{1,20}|{2,15}|{3,22}|{4,22}", "", sumaZuti, sumaDrugiZuti, sumaCrveni, sumaSvi));
        }
    }
}
