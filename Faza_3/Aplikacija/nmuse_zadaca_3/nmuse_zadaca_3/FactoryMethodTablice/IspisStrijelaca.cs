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
    class IspisStrijelaca : IProductIspis
    {
        public void accept(IVisitorObradaAktivnosti visitor)
        {
            visitor.visitStrijelci(this);
        }

        public void ispisiTablicu(List<ITablica> listaTablica)
        {
            List<TablicaStrijelaca> listaTabliceStrijelacaSortirano = new List<TablicaStrijelaca>();
            foreach (ITablica t in listaTablica)
            {
                listaTabliceStrijelacaSortirano.Add(t as TablicaStrijelaca);
            }
            int sumaGolova = 0;
            Console.WriteLine("Tablica strijelaca");
            Console.WriteLine(String.Format("|{0,-30}|{1,15}|{2,-20}", "Igrač", "Broj golova", "Klub"));
            foreach (TablicaStrijelaca strijelac in listaTabliceStrijelacaSortirano)
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine(String.Format("|{0,-30}|{1,15}|{2,-20}", strijelac.Igrac.ImePrezime, strijelac.BrojGolova, strijelac.Klub.Naziv));
                sumaGolova += strijelac.BrojGolova;
            }
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine(String.Format("|{0,-30}|{1,15}|{2,-20}", "", sumaGolova, ""));

        }
    }
}
